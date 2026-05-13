using AbarrotesPOS.Services; // Namespace de tu servicio
using AbarrotesPOS.Shared; // Namespace de tus modelos

namespace AbarrotesPOS.Tests
{
    public class UserSessionServiceTests
    {
        [Fact] // Indica que es una prueba unitaria[cite: 1]
        public void IniciarSesion_EstableceUsuarioActual()
        {
            // 1. Arrange (Preparar): Configuramos el escenario[cite: 1]
            var service = new UserSessionService();
            var usuario = new Usuario { Id = 1 };

            // 2. Act (Actuar): Ejecutamos la acción a probar[cite: 1]
            service.IniciarSesion(usuario);

            // 3. Assert (Afirmar): Verificamos el resultado[cite: 1]
            Assert.Equal(usuario, service.UsuarioActual);
        }

        [Fact]
        public void CerrarSesion_LimpiaUsuario()
        {
            // Arrange[cite: 1]
            var service = new UserSessionService();
            service.IniciarSesion(new Usuario());

            // Act[cite: 1]
            service.CerrarSesion();

            // Assert[cite: 1]
            Assert.Null(service.UsuarioActual);
        }

        [Fact]
        public void EsAdmin_True_SiRolesAdministrador()
        {
            // Arrange[cite: 1]
            var service = new UserSessionService();
            var usuario = new Usuario
            {
                Rol = new Rol { Nombre = "Administrador" }
            };
            service.IniciarSesion(usuario);

            // Act & Assert[cite: 1]
            Assert.True(service.EsAdmin);
        }
    }
}