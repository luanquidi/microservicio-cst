using Servicios.Api.Cst.Core.Entities;
using Servicios.Api.Cst.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Aplication.Interfaces
{
    public interface ITipoRestauranteAplication
    {
        Task<RespuestaOperacion<IEnumerable<TipoRestauranteEntity>>> ObtenerTiposRestaurantesAsync();
        Task<RespuestaOperacion<TipoRestauranteEntity>> ObtenerTipoRestauranteAsync(string id);
        Task<RespuestaOperacion<bool>> ActualizarTipoRestauranteAsync(string id, TipoRestauranteEntity restaurante);
        Task<RespuestaOperacion<bool>> RegistrarTipoRestauranteAsync(TipoRestauranteEntity restaurante);
        Task<RespuestaOperacion<bool>> EliminarTipoRestauranteAsync(string id);
    }
}
