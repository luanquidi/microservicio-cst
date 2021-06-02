using Microsoft.AspNetCore.Identity;
using Servicios.Api.Seguridad.Core.Entitites;
using Servicios.Api.Seguridad.Core.Persistent;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Api.Seguridad.Core.Persistence
{
    public class SeguridadData
    {
        public static async Task InsertarUsuario(SeguridadContexto context, UserManager<Usuario> usuarioManager)
        {
            if (!usuarioManager.Users.Any())
            {
                var usuario = new Usuario
                {
                    Nombre = "Luis",
                    Apellido = "Quiñones Diaz",
                    Direccion = "Calle 69 # 27 A 100",
                    UserName = "luanquidi",
                    Email = "luanquidi1@hotmaiil.com"
                };

               await usuarioManager.CreateAsync(usuario, "8246557Ll.");
            }
        }
    }
}
