using Servicios.Api.Cst.Core.Entities;
using Servicios.Api.Cst.Core.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Aplication.Interfaces
{
    public interface IDepartamentoAplication
    {
        Task<RespuestaOperacion<IEnumerable<DepartamentoEntity>>> ObtenerDepartamentosAsync();
        Task<RespuestaOperacion<DepartamentoEntity>> ObtenerDepartamentoAsync(string id);
        Task<RespuestaOperacion<bool>> ActualizarDepartamentoAsync(string id, DepartamentoEntity departamento);
        Task<RespuestaOperacion<bool>> RegistrarDepartamentoAsync(DepartamentoEntity departamento);
        Task<RespuestaOperacion<bool>> EliminarDepartamentoAsync(string id);
    }
}
