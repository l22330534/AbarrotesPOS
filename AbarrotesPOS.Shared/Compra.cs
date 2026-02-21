using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Compra
{
    public int Id { get; set; }
    public DateTime FechaCompra { get; set; }
    public int ProveedorId { get; set; }
    public Proveedor Proveedor { get; set; }
    public decimal Total { get; set; }
    public List<CompraDetalle> Detalles { get; set; } = new List<CompraDetalle>();
}