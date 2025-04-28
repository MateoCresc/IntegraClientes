using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClienteApp.Data.Models
{
    public class Cliente
    {
        public string Cuit { get; set; }

        public string RazonSocial { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public bool Activo { get; set; }

    }
}