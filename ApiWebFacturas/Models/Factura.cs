using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiWebFacturas.Models
{
    public class Factura
    {
        
        public int Id { get; set; }
        [Required]
        public int Num_Factura { get; set; }
        [Required]
        public DateTime Fecha_Factura { get; set; }
        [Required]
        [StringLength(200)]
        public string Nombre_Vendedor { get; set; }
        [Required]
        [StringLength(200)]
        public string Nombre_Cliente { get; set; }
        [Required]
        public double Sub_Total_Factura { get; set; }
        [Required]
        public double IGV_Factura { get; set; }
        [Required]
        public double Total_Factura { get; set; }
        [Required]
        public Boolean Estado_Factura { get; set; }
    }
}