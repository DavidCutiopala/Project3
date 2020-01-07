using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkContable.Models;
using WorkContable.Models.Base;

namespace WorkContable.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (Entities db=new Entities()) 
                {
                    var lst = from d in db.USUARIO
                              where d.NOMBRE_USUARIO == user && d.PASSWORD == password
                              select d;
                    if (lst.Count() > 0)
                    {
                        //validacion sesion
                        USUARIO oUsuario = lst.First();
                        Session["User"] = oUsuario;
                        return Content("1");
                    }else
                    {
                        return Content("Usuario Invalido");
                    }
                }
                
            }
            catch(Exception ex)
            {
                return Content("error"+ex.Message);
            }
        }
    }
}