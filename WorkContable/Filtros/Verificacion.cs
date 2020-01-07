using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkContable.Models.Base;
using WorkContable.Controllers;

namespace WorkContable.Filtros
{
    public class Verificacion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUsuario = (USUARIO)HttpContext.Current.Session["User"];
            if (oUsuario == null)
            {
                if(filterContext.Controller is UsuarioController == false){
                    filterContext.HttpContext.Response.Redirect("~/Usuario/Index");
                }
            }
            else
            {
                if(filterContext.Controller is UsuarioController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}