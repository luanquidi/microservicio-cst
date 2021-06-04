using Servicios.Api.Cst.Aplication.Interfaces;
using Servicios.Api.Cst.Core.Entities;
using Servicios.Api.Cst.Core.Utils;
using Servicios.Api.Cst.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Aplication.Implementacion
{
    public class HospedajeAplication : IHospedajeAplication
    {
        // Inyección de dependencias.
        private readonly IMongoRepository<HospedajeEntity> _hospedajeRepository;

        // Método constructor.
        public HospedajeAplication(IMongoRepository<HospedajeEntity> hospedajeRepository)
        {
            _hospedajeRepository = hospedajeRepository;
        }

        #region Métodos públicos

        /// <summary>
        /// Método para listar los Hospedaje de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaOperacion<IEnumerable<HospedajeEntity>>> ObtenerHospedajesAsync()
        {
            var respuesta = new RespuestaOperacion<IEnumerable<HospedajeEntity>>();

            try
            {
                respuesta.Datos = await _hospedajeRepository.GetAll();
                respuesta.Mensaje = "La operación se ha realizado correctamente.";
                respuesta.ResultadoExitoso = true;
            }
            catch (Exception ex)
            {
                respuesta.ResultadoExitoso = false;
                respuesta.Mensaje = ex.Message;
            }

            return respuesta;
        }

        /// <summary>
        /// Método para obtener un Hospedaje por id de manera asíncrona.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RespuestaOperacion<HospedajeEntity>> ObtenerHospedajeAsync(string id)
        {
            var respuesta = new RespuestaOperacion<HospedajeEntity>();

            try
            {
                respuesta.Datos = await _hospedajeRepository.GetById(id);
                respuesta.Mensaje = "La operación se ha realizado correctamente.";
                respuesta.ResultadoExitoso = true;
            }
            catch (Exception ex)
            {
                respuesta.ResultadoExitoso = false;
                respuesta.Mensaje = ex.Message;
            }

            return respuesta;
        }

        /// <summary>
        /// Método para actualizar un Hospedaje de manera asíncrona.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hospedaje"></param>
        /// <returns></returns>
        public async Task<RespuestaOperacion<bool>> ActualizarHospedajeAsync(string id, HospedajeEntity hospedaje)
        {
            var respuesta = new RespuestaOperacion<bool>();
            hospedaje.Id = id;
            try
            {
                await _hospedajeRepository.UpdateDocument(hospedaje);
                respuesta.Mensaje = "La operación se ha realizado correctamente.";
                respuesta.ResultadoExitoso = true;
            }
            catch (Exception ex)
            {
                respuesta.ResultadoExitoso = false;
                respuesta.Mensaje = ex.Message;
            }

            return respuesta;
        }


        /// <summary>
        /// Método para registrar un Hospedaje de manera asíncrona.
        /// </summary>
        /// <param name="hospedaje"></param>
        /// <returns></returns>
        public async Task<RespuestaOperacion<bool>> RegistrarHospedajeAsync(HospedajeEntity hospedaje)
        {
            var respuesta = new RespuestaOperacion<bool>();
            try
            {
                await _hospedajeRepository.InsertDocument(hospedaje);
                respuesta.Mensaje = "La operación se ha realizado correctamente.";
                respuesta.ResultadoExitoso = true;
            }
            catch (Exception ex)
            {
                respuesta.ResultadoExitoso = false;
                respuesta.Mensaje = ex.Message;
            }

            return respuesta;
        }


        /// <summary>
        /// Método para eliminar Hospedaje de manera asíncrona.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RespuestaOperacion<bool>> EliminarHospedajeAsync(string id)
        {
            var respuesta = new RespuestaOperacion<bool>();
            try
            {
                await _hospedajeRepository.DeleteById(id);
                respuesta.Mensaje = "La operación se ha realizado correctamente.";
                respuesta.ResultadoExitoso = true;
            }
            catch (Exception ex)
            {
                respuesta.ResultadoExitoso = false;
                respuesta.Mensaje = ex.Message;
            }

            return respuesta;
        }
        #endregion
    }
}
