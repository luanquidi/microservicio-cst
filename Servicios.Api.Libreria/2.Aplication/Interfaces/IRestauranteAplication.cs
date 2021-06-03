using Servicios.Api.Cst.Core.Entities;
using Servicios.Api.Cst.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Aplication.Interfaces
{
    public interface IRestauranteAplication
    {
        Task<RespuestaOperacion<IEnumerable<RestauranteEntity>>> ObtenerRestaurantesAsync();
        Task<RespuestaOperacion<RestauranteEntity>> ObtenerRestauranteAsync(string id);
        Task<RespuestaOperacion<bool>> ActualizarRestauranteAsync(string id, RestauranteEntity restaurante);
        Task<RespuestaOperacion<bool>> RegistrarRestauranteAsync(RestauranteEntity restaurante);
        Task<RespuestaOperacion<bool>> EliminarRestauranteAsync(string id);
    }
}
