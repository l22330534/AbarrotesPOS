namespace AbarrotesPOS.Shared;

/// <summary>
/// Representa una línea de artículo individual dentro de una Venta.
/// </summary>
public class VentaDetalle
{
    public int Id { get; set; }
    public int Cantidad { get; set; }

    /// <summary>
    /// El precio del producto en el momento de la venta. Se almacena aquí 
    /// para mantener un registro histórico preciso, incluso si el precio del producto cambia después.
    /// </summary>
    public decimal PrecioVenta { get; set; }

    // Foreign Key para la venta a la que pertenece este detalle
    public int VentaId { get; set; }

    // Foreign Key para el producto vendido
    public int ProductoId { get; set; }
    public Producto Producto { get; set; }
}

