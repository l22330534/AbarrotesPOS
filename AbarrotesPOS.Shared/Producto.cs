namespace AbarrotesPOS.Shared;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string? CodigoBarras { get; set; }
    public decimal PrecioVenta { get; set; }
    public int Stock { get; set; }

    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
    public int StockMinimo { get; set; } = 5;

    public int ProveedorId { get; set; }
    public Proveedor Proveedor { get; set; }
}