using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWebFacturas.Request
{
    public class Factura_Request_v1
    {
        public string Name { get; set; }
        public int[] Ids { get; set; }
    }
}