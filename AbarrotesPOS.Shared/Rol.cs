using System.Collections.Generic; // Necesario para ICollection
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Necesario para JsonIgnore

namespace AbarrotesPOS.Shared; // <--- IMPORTANTE: Debe coincidir con el de Usuario.cs

public class Rol
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre del rol es obligatorio")]
    public string Nombre { get; set; } = string.Empty;

    // Relación inversa para navegación (Opcional pero recomendada)
    [JsonIgnore]
    public ICollection<Usuario>? Usuarios { get; set; }
}