using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SC_601_PA_G5_M.Models.Taller
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [StringLength(50)]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio")]
        [StringLength(50)]
        public string Telefono { get; set; }
    }
}