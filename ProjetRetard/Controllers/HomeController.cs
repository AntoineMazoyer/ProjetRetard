using ProjetRetard.DAL;
using ProjetRetard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjetRetard.Controllers
{
    public class HomeController : Controller {

    private ProjetRetardContext db = new ProjetRetardContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Utilisateur utilisateur, string ReturnURL = "")
        {
            string message;
            var m = db.Utilisateurs.Where(am => am.AdresseMail == utilisateur.AdresseMail).FirstOrDefault();
            if (m != null)
            {
                if (string.Compare(HashingPass.Hash(utilisateur.MotDePasse), m.MotDePasse) == 0)
                {
                    var ticket = new FormsAuthenticationTicket(utilisateur.AdresseMail, false, 525600);
                    string encrypt = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypt);
                    cookie.Expires = DateTime.Now.AddMinutes(5000);

                    if (Url.IsLocalUrl(ReturnURL))
                    {
                        return Redirect(ReturnURL);
                    }
                }
                else
                {
                    message = "NUL !";
                }
            }
            else
            {
                message = "NUL !";
            }
            return View();
        }

        private bool IsValid(Utilisateur utilisateur)
        {
            return (utilisateur.AdresseMail == "lol@lol.fr" && utilisateur.MotDePasse == "lol");
        }

        [AllowAnonymous]
        public ActionResult Inscription()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Inscription([Bind(Include = "ID,Nom,Prenom,Classe,AdresseMail,MotDePasse")] Utilisateur utilisateur)
        {
            string message;
            if (ModelState.IsValid)
            {
                #region Email déjà utilisé
                var isExist = IsEmailExist(utilisateur.AdresseMail);
                if (isExist)
                {
                    ModelState.AddModelError("AdresseMail", "Adresse email déjà utilisé");
                }
                #endregion

                #region Hasher mot de passe
                utilisateur.MotDePasse = HashingPass.Hash(utilisateur.MotDePasse);
                #endregion

                db.Utilisateurs.Add(utilisateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                message = "Formulaire invalide";
                return View();
            }
        }

        [Authorize]
        public ActionResult FormulaireRetard()
        {
            return View();
        }

        [NonAction]
        public bool IsEmailExist(string Email)
        {
            var v = db.Utilisateurs.Where(am => am.AdresseMail == Email).FirstOrDefault();
            return v != null;
        }

        //[NonAction]
        //public bool IsValidUser(string Email, string Password)
        //{
        //    var mail = db.Utilisateurs.Where(m => m.AdresseMail == Email).Single();
        //    var pass = db.Utilisateurs.Where(p => p.MotDePasse == Password).Single();
        //}
    }
}