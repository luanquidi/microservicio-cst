using Servicios.Api.Cst.Core.Entities;
using Servicios.Api.Cst.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Aplication.Interfaces
{
    public interface ISitioTuristicoAplication
    {
        Task<RespuestaOperacion<IEnumerable<SitioTuristicoEntity>>> ObtenerSitiosTuristicoAsync();
        Task<RespuestaOperacion<SitioTuristicoEntity>> ObtenerSitioTuristicoAsync(string id);
        Task<RespuestaOperacion<bool>> ActualizarSitioTuristicoAsync(string id, SitioTuristicoEntity sitioTuristico);
        Task<RespuestaOperacion<bool>> RegistrarSitioTuristicoAsync(SitioTuristicoEntity sitioTuristico);
        Task<RespuestaOperacion<bool>> EliminarSitioTuristicoAsync(string id);
    }
}
