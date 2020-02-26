using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjetRetard.DAL;
using ProjetRetard.Models;

namespace ProjetRetard.Controllers
{
    public class BilletRetardsController : Controller
    {
        private ProjetRetardContext db = new ProjetRetardContext();

        // GET: BilletRetards
        [Authorize]
        public ActionResult Index()
        {
            return View(db.BilletsRetards.ToList());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            if (Request.Cookies["idUtilisateurCookie"] != null)
            {
                Response.Cookies["idUtilisateurCookie"].Expires = DateTime.Now.AddDays(-1);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: BilletRetards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BilletRetard billetRetard = db.BilletsRetards.Find(id);
            if (billetRetard == null)
            {
                return HttpNotFound();
            }
            return View(billetRetard);
        }

        // GET: BilletRetards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BilletRetards/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Motif,Justificatif")] BilletRetard billetRetard)
        {
            if (billetRetard.Motif != null)
            {
                if(billetRetard.Justificatif == null)
                {
                    billetRetard.Justificatif = "Aucun";
                }
                billetRetard.DateHeure = DateTime.Now;
                billetRetard.Score = 0;
                int idUtilisateur = Int32.Parse(Request.Cookies["idUtilisateurCookie"]["idUtilisateur"]);
                billetRetard.Utilisateur = UtilisateurDAL.getUtilisateurFromId(idUtilisateur);
                db.BilletsRetards.Add(billetRetard);
                db.SaveChanges();
                return RedirectToAction("Index", "BilletRetards");
            }

            return View(billetRetard);
        }

        // GET: BilletRetards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BilletRetard billetRetard = db.BilletsRetards.Find(id);
            if (billetRetard == null)
            {
                return HttpNotFound();
            }
            return View(billetRetard);
        }

        // POST: BilletRetards/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Motif,Justificatif,DateHeure")] BilletRetard billetRetard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billetRetard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(billetRetard);
        }

        // GET: BilletRetards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BilletRetard billetRetard = db.BilletsRetards.Find(id);
            if (billetRetard == null)
            {
                return HttpNotFound();
            }
            return View(billetRetard);
        }

        // POST: BilletRetards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BilletRetard billetRetard = db.BilletsRetards.Find(id);
            db.BilletsRetards.Remove(billetRetard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
