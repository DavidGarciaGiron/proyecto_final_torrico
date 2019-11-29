using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiWebFacturas.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("MyContextDB")
        {

        }

        public DbSet<Factura> Facturas { get; set; }
    }
}