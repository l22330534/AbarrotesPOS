using Xunit;
using AbarrotesPOS.Services;
using AbarrotesPOS.Shared;

public class UserSessionServiceTests
{
    [Fact]
    public void IniciarSesion_EstableceUsuarioActual()
    {
        var service = new UserSessionService();
        var usuario = new Usuario();

        service.IniciarSesion(usuario);

        Assert.Equal(usuario, service.UsuarioActual);
    }

    [Fact]
    public void EstaLogueado_True_CuandoHayUsuario()
    {
        var service = new UserSessionService();
        var usuario = new Usuario();

        service.IniciarSesion(usuario);

        Assert.True(service.EstaLogueado);
    }

    [Fact]
    public void CerrarSesion_LimpiaUsuarioActual()
    {
        var service = new UserSessionService();
        var usuario = new Usuario();

        service.IniciarSesion(usuario);
        service.CerrarSesion();

        Assert.Null(service.UsuarioActual);
    }

    [Fact]
    public void EsAdmin_True_SiRolEsAdministrador()
    {
        var service = new UserSessionService();

        var usuario = new Usuario
        {
            Rol = new Rol { Nombre = "Administrador" }
        };

        service.IniciarSesion(usuario);

        Assert.True(service.EsAdmin);
    }

    //  MOCKS (evento OnChange)

    [Fact]
    public void IniciarSesion_DisparaEvento_OnChange()
    {
        var service = new UserSessionService();
        var usuario = new Usuario();

        bool eventoEjecutado = false;

        service.OnChange += () => eventoEjecutado = true;

        service.IniciarSesion(usuario);

        Assert.True(eventoEjecutado);
    }

    [Fact]
    public void CerrarSesion_DisparaEvento_OnChange()
    {
        var service = new UserSessionService();
        var usuario = new Usuario();

        bool eventoEjecutado = false;

        service.OnChange += () => eventoEjecutado = true;

        service.IniciarSesion(usuario);
        eventoEjecutado = false;

        service.CerrarSesion();

        Assert.True(eventoEjecutado);
    }
}