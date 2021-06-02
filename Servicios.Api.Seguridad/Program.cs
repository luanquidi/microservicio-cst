using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Servicios.Api.Seguridad.Core.Entitites;
using Servicios.Api.Seguridad.Core.Persistence;
using Servicios.Api.Seguridad.Core.Persistent;
using System;

namespace Servicios.Api.Seguridad
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            
            var hostServer = CreateHostBuilder(args).Build();

            using (var contexto = hostServer.Services.CreateScope())
            {
                var services = contexto.ServiceProvider;

                try
                {
                    var userManager = services.GetRequiredService<UserManager<Usuario>>();
                    var contextoEF = services.GetRequiredService<SeguridadContexto>();

                    SeguridadData.InsertarUsuario(contextoEF, userManager).Wait();
                }
                catch (Exception ex)
                {
                    var logging = services.GetRequiredService<Logger<Program>>();
                    logging.LogError(ex, "Error en el método registrar usuario");
                }
            }

            hostServer.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
