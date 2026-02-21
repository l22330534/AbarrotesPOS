using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbarrotesPOS.Shared
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        public string? Telefono { get; set; }

        public string? Correo { get; set; }

        // Sistema de Puntos
        public int Puntos { get; set; } = 0;
    }
}