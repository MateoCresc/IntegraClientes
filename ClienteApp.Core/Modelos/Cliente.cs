using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteApp.Core.Models
{
    public class Cliente
    {
        public string cuit { get; set; }
        public string razonSocial { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public bool activo { get; set; }

    }
}