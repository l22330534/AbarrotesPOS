using AbarrotesPOS.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace AbarrotesPOS.App.Components.Base;

/// <summary>
/// Clase base genérica que centraliza la lógica CRUD repetida en Categorias, 
/// Proveedores y otras páginas simples. Las páginas que la heredan solo necesitan
/// implementar CloneEntidad() para su lógica específica.
/// </summary>
public abstract class CrudBaseComponent<T> : ComponentBase where T : class, new()
{
    [Inject] protected AppDbContext DbContext { get; set; } = default!;

    protected List<T>? listaEntidades;
    protected T entidadActual = new();
    protected bool mostrarModal = false;
    protected string mensajeError = string.Empty;

    // ─── Ciclo de vida ───────────────────────────────────────────────────────

    protected override async Task OnInitializedAsync()
    {
        await CargarDatos();
    }

    // ─── Métodos virtuales que las subclases pueden sobreescribir ────────────

    /// <summary>
    /// Carga la lista desde la BD. Las subclases pueden sobreescribir esto
    /// para agregar .Include() o filtros (como hace Productos).
    /// </summary>
    protected virtual async Task CargarDatos()
    {
        listaEntidades = await DbContext.Set<T>().ToListAsync();
    }

    /// <summary>
    /// Crea una copia de la entidad para editar sin afectar la lista original.
    /// Las subclases DEBEN implementar esto con los campos propios de su tipo.
    /// </summary>
    protected abstract T CloneEntidad(T original);

    // ─── Lógica de modal ─────────────────────────────────────────────────────

    protected void AbrirModalParaCrear()
    {
        entidadActual = new T();
        mensajeError = string.Empty;
        mostrarModal = true;
    }

    protected virtual void AbrirModalParaEditar(T entidad)
    {
        entidadActual = CloneEntidad(entidad);
        mensajeError = string.Empty;
        mostrarModal = true;
    }

    protected void CerrarModal()
    {
        mostrarModal = false;
        mensajeError = string.Empty;
    }

    // ─── Guardar: detecta Insert o Update usando reflexión sobre "Id" ────────

    protected virtual async Task Guardar()
    {
        mensajeError = string.Empty;
        try
        {
            var keyProperty = typeof(T).GetProperty("Id");
            var idValue = keyProperty?.GetValue(entidadActual);

            if (idValue is int id && id == 0)
            {
                // INSERT
                DbContext.Set<T>().Add(entidadActual);
            }
            else
            {
                // UPDATE
                var entidadEnDb = await DbContext.Set<T>().FindAsync(idValue);
                if (entidadEnDb != null)
                {
                    DbContext.Entry(entidadEnDb).CurrentValues.SetValues(entidadActual);
                }
            }

            await DbContext.SaveChangesAsync();
            await CargarDatos();
            CerrarModal();
        }
        catch (Exception ex)
        {
            mensajeError = $"Error al guardar: {ex.InnerException?.Message ?? ex.Message}";
        }
    }

    protected virtual async Task Eliminar(T entidad)
    {
        mensajeError = string.Empty;
        try
        {
            DbContext.Set<T>().Remove(entidad);
            await DbContext.SaveChangesAsync();
            await CargarDatos();
        }
        catch (Exception ex)
        {
            mensajeError = $"No se puede eliminar: {ex.InnerException?.Message ?? ex.Message}";
        }
    }
}