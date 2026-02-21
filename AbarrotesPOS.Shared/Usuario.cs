using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbarrotesPOS.Shared;

public class Usuario
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string? PasswordHash { get; set; }
    public bool Activo { get; set; } = true;

 
    [Required]
    public int RolId { get; set; }

    [ForeignKey("RolId")]
    public Rol? Rol { get; set; }
}