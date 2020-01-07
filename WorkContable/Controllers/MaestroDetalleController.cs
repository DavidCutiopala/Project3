using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkContable.Models.Base;
using WorkContable.Models.ViewModels;

namespace WorkContable.Controllers
{
    public class MaestroDetalleController : Controller
    {
        // GET: MaestroDetalle
        public ActionResult Add ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(PresupuestoViewModel model)
        {
            try
            {
                using (Entities db=new Entities())
                {
                    USUARIO currentUser = (USUARIO)Session["User"];
                    PRESUPUESTO oPresupuesto = new PRESUPUESTO();

                    foreach (var oC in model.transacciones)
                    {
                        TRANSACCION otransaccion = new TRANSACCION();

                     
                        var lst = from d in db.RUBRO
                                  where d.NOMBRE == oC.rubro
                              select d;

                        RUBRO oRubro = lst.First();

                        otransaccion.RUB_ID = oRubro.ID;
                        var tipTra=0;
                        if (oC.tipo == "ingreso"){
                            tipTra = 1;
                        }
                        else {
                            tipTra = 2;
                         }

                        otransaccion.TIPO = tipTra;
                        otransaccion.FECHA = oC.fecha;
                        otransaccion.SUBTOTAL = oC.subtotal;
                        otransaccion.IMPUESTO = oC.impuesto;
                        otransaccion.TOTAL = oC.total;
                        db.TRANSACCION.Add(otransaccion);
            
                        db.SaveChanges();
                    }
                   
                    oPresupuesto.USU_ID = currentUser.ID;
                    oPresupuesto.VALOR_PRE = model.valor;
                    oPresupuesto.FECHA_INICIO = model.fecha_inicio;
                    oPresupuesto.FECHA_FIN = model.fecha_fin;
                    oPresupuesto.TOTAL_GASTOS = model.totalGastos;
                    db.PRESUPUESTO.Add(oPresupuesto);

                    db.SaveChanges();
                }
                ViewBag.Message = "Presupuesto ingresado";
                return View();
            }
            catch (Exception )
            {

                return View();
            }
        }
    }
}