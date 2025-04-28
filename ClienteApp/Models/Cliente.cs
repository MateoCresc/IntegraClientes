using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClienteApp.Models
{
    public class Cliente
    {
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El CUIT debe tener 11 caracteres")]
        public string Cuit { get; set; }

        [Required]
        [Display(Name = "Razón Social")]
        public string RazonSocial { get; set; }

        [Required]
        [Phone]
        public string Telefono { get; set; }

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }

        public bool Activo { get; set; }

    }
}