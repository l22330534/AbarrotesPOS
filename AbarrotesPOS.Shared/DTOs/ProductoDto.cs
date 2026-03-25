namespace AbarrotesPOS.Shared.DTOs;

/// <summary>
/// DTO liviano para búsquedas y listas. Evita traer navegaciones
/// innecesarias (Categoria, Proveedor) cuando solo se necesitan datos básicos.
/// </summary>
public class ProductoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? CodigoBarras { get; set; }
    public decimal PrecioVenta { get; set; }
    public int Stock { get; set; }
    public string CategoriaNombre { get; set; } = string.Empty;
    public string ProveedorNombre { get; set; } = string.Empty;
}