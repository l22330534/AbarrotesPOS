using System; // <--- Necesario para 'Action'
using AbarrotesPOS.Shared;

namespace AbarrotesPOS.Services;

public class UserSessionService
{
    public Usuario? UsuarioActual { get; private set; }

    // VVV ESTE ES EL EVENTO QUE TE FALTA VVV
    public event Action? OnChange;

    public bool EstaLogueado => UsuarioActual != null;

    public bool EsAdmin
    {
        get
        {
            if (UsuarioActual?.Rol == null) return false;

            string nombreRol = UsuarioActual.Rol.Nombre.Trim();

            return string.Equals(nombreRol, "Administrador", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(nombreRol, "Admin", StringComparison.OrdinalIgnoreCase);
        }
    }

    public void IniciarSesion(Usuario usuario)
    {
        UsuarioActual = usuario;
        NotifyStateChanged(); // <--- Avisamos al menú
    }

    public void CerrarSesion()
    {
        UsuarioActual = null;
        NotifyStateChanged(); // <--- Avisamos al menú
    }

    // Método privado que dispara el evento
    private void NotifyStateChanged() => OnChange?.Invoke();
}