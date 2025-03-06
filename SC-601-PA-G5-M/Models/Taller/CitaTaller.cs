using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SC_601_PA_G5_M.Models.Taller
{
    public class CitaTaller
    {
        [Key]
        public int IdCita { get; set; }

        [ForeignKey("Usuario")]

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Fecha de la cita")]
        public DateTime FechaCita { get; set; }

        [Required(ErrorMessage = "La descripcion del servicio es obligatorio")]
        [StringLength(100)]
        public string DescripcionServicio { get; set; }

        [Required(ErrorMessage = "El estado de la cita es obligatorio")]
        [StringLength(50)]
        public string EstadoCita { get; set; }
    }
}