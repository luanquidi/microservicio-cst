using Servicios.Api.Cst.Aplication.Interfaces;
using Servicios.Api.Cst.Core.Entities;
using Servicios.Api.Cst.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Aplication.Interfaces
{
    public interface ITransporteAplication
    {
        Task<RespuestaOperacion<IEnumerable<TransporteEntity>>> ObtenerTransportesAsync();
        Task<RespuestaOperacion<TransporteEntity>> ObtenerTransporteAsync(string id);
        Task<RespuestaOperacion<bool>> RegistrarTransporteAsync(TransporteEntity transporte);
        Task<RespuestaOperacion<bool>> ActualizarTransporteAsync(string id, TransporteEntity transporte);
        Task<RespuestaOperacion<bool>> EliminarTransporteAsync(string id);
    }
}
