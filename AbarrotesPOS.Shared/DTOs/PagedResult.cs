namespace AbarrotesPOS.Shared.DTOs;

/// <summary>
/// Envuelve cualquier lista paginada con metadatos de navegación.
/// Es genérico para poder reutilizarlo en Clientes, Ventas, etc. en el futuro.
/// </summary>
public class PagedResult<T>
{
    public List<T> Items { get; set; }
    public int TotalRegistros { get; set; }
    public int PaginaActual { get; set; }
    public int TamañoPagina { get; set; }

    // Calculados automáticamente
    public int TotalPaginas => (int)Math.Ceiling((double)TotalRegistros / TamañoPagina);
    public bool HayPaginaAnterior => PaginaActual > 1;
    public bool HayPaginaSiguiente => PaginaActual < TotalPaginas;

    public PagedResult(List<T> items, int totalRegistros, int paginaActual, int tamañoPagina)
    {
        Items = items;
        TotalRegistros = totalRegistros;
        PaginaActual = paginaActual;
        TamañoPagina = tamañoPagina;
    }
}