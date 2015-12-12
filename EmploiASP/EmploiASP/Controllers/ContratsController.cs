using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmploiASP;

namespace EmploiASP.Controllers
{
    public class ContratsController : Controller
    {
        private EmploiEntities db = new EmploiEntities();

        // GET: Contrats
        public ActionResult Index()
        {
            var contrat = db.Contrat.Include(c => c.EntrepriseClient).Include(c => c.ContratTravailleurNonSoumis).Include(c => c.ContratTravailleurSoumis).Include(c => c.Profession).Include(c => c.Travailleur);
            return View(contrat.ToList());
        }

        // GET: Contrats/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrat contrat = db.Contrat.Find(id);
            if (contrat == null)
            {
                return HttpNotFound();
            }
            return View(contrat);
        }

        // GET: Contrats/Create
        public ActionResult Create()
        {
            ViewBag.NomEntreprise = new SelectList(db.EntrepriseClient.Include("TraductionEntreprise"), "numero", "denomination");
            ViewBag.idContrat = new SelectList(db.ContratTravailleurNonSoumis, "idContrat", "idContrat");
            ViewBag.idContrat = new SelectList(db.ContratTravailleurSoumis, "idContrat", "numDossierMedical");
            ViewBag.codeAlphabetique = new SelectList(db.Profession, "codeAlphabetique", "codeAlphabetique");
            ViewBag.idTravailleur = new SelectList(db.Travailleur, "idTravailleur", "nom");
            return View();
        }

        // POST: Contrats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idContrat,dateEntree,idTravailleur,numero,dateSortie,codeAlphabetique")] Contrat contrat)
        {
            if (ModelState.IsValid)
            {
                db.Contrat.Add(contrat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.numero = new SelectList(db.EntrepriseClient, "numero", "denomination", contrat.numero);
            ViewBag.idContrat = new SelectList(db.ContratTravailleurNonSoumis, "idContrat", "idContrat", contrat.idContrat);
            ViewBag.idContrat = new SelectList(db.ContratTravailleurSoumis, "idContrat", "numDossierMedical", contrat.idContrat);
            ViewBag.codeAlphabetique = new SelectList(db.Profession, "codeAlphabetique", "codeAlphabetique", contrat.codeAlphabetique);
            ViewBag.idTravailleur = new SelectList(db.Travailleur, "idTravailleur", "nom", contrat.idTravailleur);
            return View(contrat);
        }

        // GET: Contrats/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrat contrat = db.Contrat.Find(id);
            if (contrat == null)
            {
                return HttpNotFound();
            }
            ViewBag.numero = new SelectList(db.EntrepriseClient, "numero", "denomination", contrat.numero);
            ViewBag.idContrat = new SelectList(db.ContratTravailleurNonSoumis, "idContrat", "idContrat", contrat.idContrat);
            ViewBag.idContrat = new SelectList(db.ContratTravailleurSoumis, "idContrat", "numDossierMedical", contrat.idContrat);
            ViewBag.codeAlphabetique = new SelectList(db.Profession, "codeAlphabetique", "codeAlphabetique", contrat.codeAlphabetique);
            ViewBag.idTravailleur = new SelectList(db.Travailleur, "idTravailleur", "nom", contrat.idTravailleur);
            return View(contrat);
        }

        // POST: Contrats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idContrat,dateEntree,idTravailleur,numero,dateSortie,codeAlphabetique")] Contrat contrat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.numero = new SelectList(db.EntrepriseClient, "numero", "denomination", contrat.numero);
            ViewBag.idContrat = new SelectList(db.ContratTravailleurNonSoumis, "idContrat", "idContrat", contrat.idContrat);
            ViewBag.idContrat = new SelectList(db.ContratTravailleurSoumis, "idContrat", "numDossierMedical", contrat.idContrat);
            ViewBag.codeAlphabetique = new SelectList(db.Profession, "codeAlphabetique", "codeAlphabetique", contrat.codeAlphabetique);
            ViewBag.idTravailleur = new SelectList(db.Travailleur, "idTravailleur", "nom", contrat.idTravailleur);
            return View(contrat);
        }

        // GET: Contrats/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrat contrat = db.Contrat.Find(id);
            if (contrat == null)
            {
                return HttpNotFound();
            }
            return View(contrat);
        }

        // POST: Contrats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Contrat contrat = db.Contrat.Find(id);
            db.Contrat.Remove(contrat);
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
