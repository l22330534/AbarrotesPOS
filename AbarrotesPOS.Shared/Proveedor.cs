public class Proveedor
{
    public int Id { get; set; }

    // Agregar esta línea si no la tienes:
    public string? Rfc { get; set; }

    public string Nombre { get; set; } = string.Empty;
    public string? Contacto { get; set; }
    public string? Telefono { get; set; }
}