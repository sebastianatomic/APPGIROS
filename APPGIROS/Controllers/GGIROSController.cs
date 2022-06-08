using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APPGIROS.Models;

namespace APPGIROS.Controllers
{
    public class GGIROSController : Controller
    {
        private GIROSEntities db = new GIROSEntities();

        // GET: GGIROS
        public ActionResult Index()
        {
            var gGIROS = db.GGIROS.Include(g => g.CIUDAD);
            return View(gGIROS.ToList());
        }

        // GET: GGIROS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GGIROS gGIROS = db.GGIROS.Find(id);
            if (gGIROS == null)
            {
                return HttpNotFound();
            }
            return View(gGIROS);
        }

        // GET: GGIROS/Create
        public ActionResult Create()
        {
            ViewBag.Id_Ciudad = new SelectList(db.CIUDAD, "Id_Ciudad", "Nombre_Ciudad");
            return View();
        }

        // POST: GGIROS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Giros,Nombre,Id_Ciudad")] GGIROS gGIROS)
        {
            if (ModelState.IsValid)
            {
                db.GGIROS.Add(gGIROS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Ciudad = new SelectList(db.CIUDAD, "Id_Ciudad", "Nombre_Ciudad", gGIROS.Id_Ciudad);
            return View(gGIROS);
        }

        // GET: GGIROS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GGIROS gGIROS = db.GGIROS.Find(id);
            if (gGIROS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Ciudad = new SelectList(db.CIUDAD, "Id_Ciudad", "Nombre_Ciudad", gGIROS.Id_Ciudad);
            return View(gGIROS);
        }

        // POST: GGIROS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Giros,Nombre,Id_Ciudad")] GGIROS gGIROS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gGIROS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Ciudad = new SelectList(db.CIUDAD, "Id_Ciudad", "Nombre_Ciudad", gGIROS.Id_Ciudad);
            return View(gGIROS);
        }

        // GET: GGIROS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GGIROS gGIROS = db.GGIROS.Find(id);
            if (gGIROS == null)
            {
                return HttpNotFound();
            }
            return View(gGIROS);
        }

        // POST: GGIROS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GGIROS gGIROS = db.GGIROS.Find(id);
            db.GGIROS.Remove(gGIROS);
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
