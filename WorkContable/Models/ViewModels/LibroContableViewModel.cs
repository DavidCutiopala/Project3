using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkContable.Models.ViewModels
{
    public class LibroContableViewModel
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
        public decimal totalIngresos { get; set; }
        public decimal totalGastos { get; set; }
        public List<Transacciones> transacciones { get; set; }

    }
}