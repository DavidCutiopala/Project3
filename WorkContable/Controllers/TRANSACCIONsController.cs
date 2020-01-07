using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkContable.Models.Base;

namespace WorkContable.Controllers
{
    public class TRANSACCIONsController : Controller
    {
        private Entities db = new Entities();

        // GET: TRANSACCIONs
        public ActionResult Index()
        {
            var tRANSACCION = db.TRANSACCION.Include(t => t.RUBRO);
            return View(tRANSACCION.ToList());
        }

        // GET: TRANSACCIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACCION tRANSACCION = db.TRANSACCION.Find(id);
            if (tRANSACCION == null)
            {
                return HttpNotFound();
            }
            return View(tRANSACCION);
        }

        // GET: TRANSACCIONs/Create
        public ActionResult Create()
        {
            ViewBag.RUB_ID = new SelectList(db.RUBRO, "ID", "NOMBRE");
            return View();
        }

        // POST: TRANSACCIONs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RUB_ID,TIPO,FECHA,SUBTOTAL,IMPUESTO,TOTAL")] TRANSACCION tRANSACCION)
        {
            if (ModelState.IsValid)
            {
                db.TRANSACCION.Add(tRANSACCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RUB_ID = new SelectList(db.RUBRO, "ID", "NOMBRE", tRANSACCION.RUB_ID);
            return View(tRANSACCION);
        }

        // GET: TRANSACCIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACCION tRANSACCION = db.TRANSACCION.Find(id);
            if (tRANSACCION == null)
            {
                return HttpNotFound();
            }
            ViewBag.RUB_ID = new SelectList(db.RUBRO, "ID", "NOMBRE", tRANSACCION.RUB_ID);
            return View(tRANSACCION);
        }

        // POST: TRANSACCIONs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RUB_ID,TIPO,FECHA,SUBTOTAL,IMPUESTO,TOTAL")] TRANSACCION tRANSACCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRANSACCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RUB_ID = new SelectList(db.RUBRO, "ID", "NOMBRE", tRANSACCION.RUB_ID);
            return View(tRANSACCION);
        }

        // GET: TRANSACCIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACCION tRANSACCION = db.TRANSACCION.Find(id);
            if (tRANSACCION == null)
            {
                return HttpNotFound();
            }
            return View(tRANSACCION);
        }

        // POST: TRANSACCIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRANSACCION tRANSACCION = db.TRANSACCION.Find(id);
            db.TRANSACCION.Remove(tRANSACCION);
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
