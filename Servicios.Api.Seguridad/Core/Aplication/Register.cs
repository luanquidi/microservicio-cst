using MediatR;
using Servicios.Api.Seguridad.Core.DTO;

namespace Servicios.Api.Seguridad.Core.Aplication
{
    public class Register
    {
        public class UsuarioRegisterCommand : IRequest<UsuarioDTO>
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }

        }
    }
}
