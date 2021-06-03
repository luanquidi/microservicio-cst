using Servicios.Api.Cst.Core.Entities;
using Servicios.Api.Cst.Core.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Aplication.Interfaces
{
    public interface IMunicipioAplication
    {
        Task<RespuestaOperacion<IEnumerable<MunicipioEntity>>> ObtenerMunicipiosAsync();
        Task<RespuestaOperacion<MunicipioEntity>> ObtenerMunicipioAsync(string id);
        Task<RespuestaOperacion<bool>> ActualizarMunicipioAsync(string id, MunicipioEntity departamento);
        Task<RespuestaOperacion<bool>> RegistrarMunicipioAsync(MunicipioEntity departamento);
        Task<RespuestaOperacion<bool>> EliminarMunicipioAsync(string id);
    }
}
