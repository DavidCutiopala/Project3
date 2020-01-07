using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WorkContable.Models.Base;

namespace WorkContable.Models.ViewModels
{
    public class PresupuestoViewModel
    {

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inicio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_inicio { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Fin")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_fin { get; set; }
        public decimal  valor { get; set; }
        public decimal totalGastos { get; set; }
        public virtual USUARIO USUARIO { get; set; }
        public virtual REG_DET_PRESUPUESTOS REGTRANPRE { get; set; }
        public List<Transacciones> transacciones { get; set; }

    }

    public class Transacciones
    {
       public String tipo { get; set; }
        public DateTime fecha { get; set; }
        public decimal subtotal { get; set; }
        public decimal impuesto { get; set; }
        public String rubro { get; set; }
        public decimal total { get; set; }
 
    }



   
}