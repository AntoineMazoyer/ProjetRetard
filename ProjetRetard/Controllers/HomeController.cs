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

        //Permet aux utilisateurs non connectés de pouvoir visualiser la page d'accueil
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        //Méthode permettant à notre utilisateur de se connecter
        [HttpPost]
        public ActionResult Index(Utilisateur utilisateur)
        {
            //On crée une variable "isValid" qui permet de savoir si un utilisateur possède une adresse mail valide sur notre site
            var isValid = db.Utilisateurs.Where(am => am.AdresseMail == utilisateur.AdresseMail).FirstOrDefault();
            //Si on a bien une adresse mail
            if (isValid != null)
            {
                //On compare le mot de passe hashé entré par l'utilisateur et le mot de passe avec lequel il s'est inscrit
                if (string.Compare(HashingPass.Hash(utilisateur.MotDePasse), isValid.MotDePasse) == 0)
                {
                    /*Méthode qui va générer un ticket d'authentification pour l'utilisateur 
                    que l'on stocke par la suite dans un cookie pour le rediriger vers la page du site*/
                    var ticket = new FormsAuthenticationTicket(utilisateur.AdresseMail, false, 525600);
                    string encrypt = FormsAuthentication.Encrypt(ticket);
                    var connexionCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypt)
                    {
                        Expires = DateTime.Now.AddMinutes(5000)
                    };
                    
                    connexionCookie.HttpOnly = true;
                    Response.Cookies.Add(connexionCookie);

                    HttpCookie idUserCookie = new HttpCookie("idUtilisateurCookie");
                    string strIdUtilisateur = UtilisateurDAL.getIdUtilisateurFromEmail(utilisateur.AdresseMail).ToString();
                    idUserCookie.Value = strIdUtilisateur;
                    idUserCookie.Expires = DateTime.Now.AddHours(1);
                    idUserCookie.HttpOnly = true;
                    Response.Cookies.Add(idUserCookie);


                    return RedirectToAction("Index", "BilletRetards");
                    //TEST
                }
                else
                {
                    ModelState.AddModelError("MotDePasse", "Votre mot de passe est incorrect");
                }
            }
            else
            {
                ModelState.AddModelError("AdresseMail", "L'adresse que vous avez renseignée n'existe pas");
            }
            return View();
        }

        //Permet aux personnes n'ayant pas encore de compte d'accéder au formulaire d'inscription
        [AllowAnonymous]
        public ActionResult Inscription()
        {
            return View();
        }

        //Méthode permettant d'enregistrer une personne dans la base de donnée
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Inscription([Bind(Include = "ID,Nom,Prenom,Classe,AdresseMail,MotDePasse")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                #region Email déjà utilisé
                var isExist = IsEmailExist(utilisateur.AdresseMail);
                if (isExist == true)
                {
                    ModelState.AddModelError("AdresseMail", "Adresse email déjà utilisée");
                    return View();
                }
                #endregion

                #region Hasher mot de passe
                utilisateur.MotDePasse = HashingPass.Hash(utilisateur.MotDePasse);
                #endregion

                //Ajout de l'utilisateur une fois les conditions remplies
                db.Utilisateurs.Add(utilisateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        //Vérifier l'exclusivité de l'adresse mail (Possibilité d'utiliser un trigger à la place ?)
        [NonAction]
        public bool IsEmailExist(string Email)
        {
            var v = db.Utilisateurs.Where(am => am.AdresseMail == Email).FirstOrDefault();
            return v != null;
        }
    }
}