using Servicios.Api.Cst.Core.Entities;
using Servicios.Api.Cst.Core.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Aplication.Interfaces
{
    public interface IHospedajeAplication
    {
        /// <summary>
        /// Método para listar los Hospedaje de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        Task<RespuestaOperacion<IEnumerable<HospedajeEntity>>> ObtenerHospedajesAsync();
        /// <summary>
        /// Método para obtener un Hospedaje por id de manera asíncrona.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RespuestaOperacion<HospedajeEntity>> ObtenerHospedajeAsync(string id);
        /// <summary>
        /// Método para actualizar un Hospedaje de manera asíncrona.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hospedaje"></param>
        /// <returns></returns>
        Task<RespuestaOperacion<bool>> ActualizarHospedajeAsync(string id, HospedajeEntity hospedaje);
        /// <summary>
        /// Método para registrar un Hospedaje de manera asíncrona.
        /// </summary>
        /// <param name="hospedaje"></param>
        /// <returns></returns>
        Task<RespuestaOperacion<bool>> RegistrarHospedajeAsync(HospedajeEntity hospedaje);
        /// <summary>
        /// Método para eliminar Hospedaje de manera asíncrona.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RespuestaOperacion<bool>> EliminarHospedajeAsync(string id);
    }
}
