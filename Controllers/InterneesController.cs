using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SongsUI.Models;

namespace SongsUI.Controllers
{
    public class InterneesController : Controller
    {
        private InterneeDbContext db = new InterneeDbContext();

        // GET: Internees
        public ActionResult Index()
        {
            return View(db.intern.ToList());
        }

        // GET: Internees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Internees internees = db.intern.Find(id);
            if (internees == null)
            {
                return HttpNotFound();
            }
            return View(internees);
        }

        // GET: Internees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Internees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Age,Goal")] Internees internees)
        {
            if (ModelState.IsValid)
            {
                db.intern.Add(internees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(internees);
        }

        // GET: Internees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Internees internees = db.intern.Find(id);
            if (internees == null)
            {
                return HttpNotFound();
            }
            return View(internees);
        }

        // POST: Internees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Age,Goal")] Internees internees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(internees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(internees);
        }

        // GET: Internees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Internees internees = db.intern.Find(id);
            if (internees == null)
            {
                return HttpNotFound();
            }
            return View(internees);
        }

        // POST: Internees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Internees internees = db.intern.Find(id);
            db.intern.Remove(internees);
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
