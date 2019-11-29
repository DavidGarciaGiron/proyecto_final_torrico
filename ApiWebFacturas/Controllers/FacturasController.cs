using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using ApiWebFacturas.Models;
using ApiWebFacturas.Request;

namespace ApiWebFacturas.Controllers
{
    public class FacturasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Facturas
        [HttpGet]
        public IQueryable<Factura> GetFacturas()
        {
            return db.Facturas;
        }

        // GET: api/Facturas/{{id}}
        [ResponseType(typeof(Factura))]
        public JsonResult<Factura> GetFacturaId(int id)
        {
            //List<Factura> facturas = new List<Factura>();
            Factura factura = new Factura();
            factura = db.Facturas.Where(x => x.Id == id && x.Estado_Factura == true).FirstOrDefault();
            if (factura == null)
            {
                return Json(factura);
            }

            return Json(factura);
        }
        
        // GET: api/Facturas/{{fecha_inicio}}&{{fecha_fin}}
        [ResponseType(typeof(Factura))]
        public IHttpActionResult GetFacturaFecha(string fecha_inicio, string fecha_final)
        {
            DateTime fecha_ini = Convert.ToDateTime(fecha_inicio);
            DateTime fecha_fin = Convert.ToDateTime(fecha_final);
            List<Factura> facturas = new List<Factura>();
             facturas = db.Facturas.Where(x => x.Fecha_Factura < fecha_fin && x.Fecha_Factura > fecha_ini && x.Estado_Factura == true).ToList();
            if (facturas == null)
            {
                return NotFound();
            }

            return Ok(facturas);
        }

        

        // GET: api/Facturas/{{Nombre_Cliente}}
        [ResponseType(typeof(Factura))]
        public IHttpActionResult GetFacturaNombreCliente(string nombre_cliente)
        {
            List<Factura> facturas = new List<Factura>();
            facturas = db.Facturas.Where(x => x.Nombre_Cliente == nombre_cliente && x.Estado_Factura == true).ToList();
            if (facturas == null)
            {
                return NotFound();
            }

            return Ok(facturas);
        }

        

        // GET: api/Facturas/{{Nombre_Vendedor}}
        [ResponseType(typeof(Factura))]
        public IHttpActionResult GetFacturaNombreVendedor(string nombre_vendedor)
        {
            List<Factura> facturas = new List<Factura>();
            facturas = db.Facturas.Where(x => x.Nombre_Vendedor == nombre_vendedor && x.Estado_Factura == true).ToList();
            if (facturas == null)
            {
                return NotFound();
            }

            return Ok(facturas);
        }

        // GET: api/Facturas/{{Num_Factura}}
        [ResponseType(typeof(Factura))]
        public IHttpActionResult GetFacturaNombreNumFactura(int num_factura)
        {
            List<Factura> facturas = new List<Factura>();
            facturas = db.Facturas.Where(x => x.Num_Factura == num_factura && x.Estado_Factura == true).ToList();
            if (facturas == null)
            {
                return NotFound();
            }

            return Ok(facturas);
        }

        // GET: api/Facturas/{{estado}}
        [ResponseType(typeof(Factura))]
        public IHttpActionResult GetFacturaNombreNumEstado(Boolean estado)
        {
            List<Factura> facturas = new List<Factura>();
            facturas = db.Facturas.Where(x => x.Estado_Factura == estado && x.Estado_Factura == true).ToList();
            if (facturas == null)
            {
                return NotFound();
            }

            return Ok(facturas);
        }

        

        // PUT: api/Facturas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFactura(int id, Factura factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != factura.Id)
            {
                return BadRequest();
            }

            db.Entry(factura).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        
        // POST: api/Facturas
        [ResponseType(typeof(Factura))]
        public IHttpActionResult PostFactura(Factura factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Facturas.Add(factura);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = factura.Id }, factura);
        }

        // DELETE: api/Facturas/5
        [ResponseType(typeof(Factura))]
        public IHttpActionResult PostEliminar([FromBody] Factura_Request_v1 request)
        {
            
            Factura factura = db.Facturas.Find(3);
            if (factura == null)
            {
                return NotFound();
            }

            db.Facturas.Remove(factura);
           // db.SaveChanges();

            return Ok(factura);
        }
        
        //[HttpDelete]
        //public bool Eliminar(int id)
        //{
        //    return true;
        //}
        //// PUT: api/factura/0/1/2/3/4/5/6/etc
        //[ResponseType(typeof(Factura))]
        //public IEnumerable<string> GetIds()
        //{
        //    var listar = db.Facturas;
        //    var n = listar.Count();

        //    string[] array = new string[n + 1];
        //    int i = 0;
        //    foreach (var ofactura in listar)
        //    {
        //        array[i] = ofactura.Estado_Factura.ToString();
        //        i = i++;
        //    }

        //    return array;
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        private bool FacturaExists(int id)
        {
            return db.Facturas.Count(e => e.Id == id) > 0;
        }
    }
}