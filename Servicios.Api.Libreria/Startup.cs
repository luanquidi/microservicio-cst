using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Servicios.Api.Cst.Aplication;
using Servicios.Api.Cst.Aplication.Implementacion;
using Servicios.Api.Cst.Aplication.Interfaces;
using Servicios.Api.Cst.Core;
using Servicios.Api.Cst.Repository;

namespace Servicios.Api.Cst
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Se configura la conexión a la base de datos (MongoDb - Corriendo en contenedor de Docker).
            services.Configure<MongoSettings>(
            options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoDb:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoDb:Database").Value;
            }
            );// Fin configuración.

            // Se implementa patrón singletón.
            services.AddSingleton<MongoSettings>();

            // Se implementa inyección de dependencias.
            services.AddTransient<IDepartamentoAplication, DepartamentoAplication>();
            services.AddTransient<IMunicipioAplication, MunicipioAplication>();
            services.AddTransient<ISitioTuristicoAplication, SitioTuristicoAplication>();
            services.AddTransient<IRestauranteAplication, RestauranteAplication>();
            services.AddTransient<ITipoRestauranteAplication, TipoRestauranteAplication>();

            // Se implementa inyección de dependencias para mongo con documentos genericos.
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Servicios.Api.Cst", Version = "v1" });
            });

            // Se establece politica de Cors.
            services.AddCors(options =>
            {
                options.AddPolicy("CorsRule", rule =>
                {
                    rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Servicios.Api.Cst v1"));
            }

            app.UseRouting();
            app.UseCors("CorsRule");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
