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
    public class CIUDADsController : Controller
    {
        private GIROSEntities db = new GIROSEntities();

        // GET: CIUDADs
        public ActionResult Index()
        {
            var cIUDAD = db.CIUDAD.Include(c => c.PAIS);
            return View(cIUDAD.ToList());
        }

        // GET: CIUDADs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CIUDAD cIUDAD = db.CIUDAD.Find(id);
            if (cIUDAD == null)
            {
                return HttpNotFound();
            }
            return View(cIUDAD);
        }

        // GET: CIUDADs/Create
        public ActionResult Create()
        {
            ViewBag.Id_Pais = new SelectList(db.PAIS, "Id_Pais", "Nombre_Pais");
            return View();
        }

        // POST: CIUDADs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Ciudad,Nombre_Ciudad,Id_Pais")] CIUDAD cIUDAD)
        {
            if (ModelState.IsValid)
            {
                db.CIUDAD.Add(cIUDAD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Pais = new SelectList(db.PAIS, "Id_Pais", "Nombre_Pais", cIUDAD.Id_Pais);
            return View(cIUDAD);
        }

        // GET: CIUDADs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CIUDAD cIUDAD = db.CIUDAD.Find(id);
            if (cIUDAD == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Pais = new SelectList(db.PAIS, "Id_Pais", "Nombre_Pais", cIUDAD.Id_Pais);
            return View(cIUDAD);
        }

        // POST: CIUDADs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Ciudad,Nombre_Ciudad,Id_Pais")] CIUDAD cIUDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cIUDAD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Pais = new SelectList(db.PAIS, "Id_Pais", "Nombre_Pais", cIUDAD.Id_Pais);
            return View(cIUDAD);
        }

        // GET: CIUDADs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CIUDAD cIUDAD = db.CIUDAD.Find(id);
            if (cIUDAD == null)
            {
                return HttpNotFound();
            }
            return View(cIUDAD);
        }

        // POST: CIUDADs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CIUDAD cIUDAD = db.CIUDAD.Find(id);
            db.CIUDAD.Remove(cIUDAD);
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
