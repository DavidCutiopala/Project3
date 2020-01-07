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
    public class PRESUPUESTOesController : Controller
    {
        private Entities db = new Entities();

        // GET: PRESUPUESTOes
        public ActionResult Index()
        {
            var pRESUPUESTO = db.PRESUPUESTO.Include(p => p.USUARIO);
            return View(pRESUPUESTO.ToList());
        }

        // GET: PRESUPUESTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRESUPUESTO pRESUPUESTO = db.PRESUPUESTO.Find(id);
            if (pRESUPUESTO == null)
            {
                return HttpNotFound();
            }
            return View(pRESUPUESTO);
        }

        // GET: PRESUPUESTOes/Create
        public ActionResult Create()
        {
            ViewBag.USU_ID = new SelectList(db.USUARIO, "ID", "NOMBRE_USUARIO");
            return View();
        }

        // POST: PRESUPUESTOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,USU_ID,FECHA_INICIO,FECHA_FIN,VALOR_PRE,TOTAL_GASTOS")] PRESUPUESTO pRESUPUESTO)
        {
            if (ModelState.IsValid)
            {
                db.PRESUPUESTO.Add(pRESUPUESTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.USU_ID = new SelectList(db.USUARIO, "ID", "NOMBRE_USUARIO", pRESUPUESTO.USU_ID);
            return View(pRESUPUESTO);
        }

        // GET: PRESUPUESTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRESUPUESTO pRESUPUESTO = db.PRESUPUESTO.Find(id);
            if (pRESUPUESTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.USU_ID = new SelectList(db.USUARIO, "ID", "NOMBRE_USUARIO", pRESUPUESTO.USU_ID);
            return View(pRESUPUESTO);
        }

        // POST: PRESUPUESTOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,USU_ID,FECHA_INICIO,FECHA_FIN,VALOR_PRE,TOTAL_GASTOS")] PRESUPUESTO pRESUPUESTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRESUPUESTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USU_ID = new SelectList(db.USUARIO, "ID", "NOMBRE_USUARIO", pRESUPUESTO.USU_ID);
            return View(pRESUPUESTO);
        }

        // GET: PRESUPUESTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRESUPUESTO pRESUPUESTO = db.PRESUPUESTO.Find(id);
            if (pRESUPUESTO == null)
            {
                return HttpNotFound();
            }
            return View(pRESUPUESTO);
        }

        // POST: PRESUPUESTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRESUPUESTO pRESUPUESTO = db.PRESUPUESTO.Find(id);
            db.PRESUPUESTO.Remove(pRESUPUESTO);
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
