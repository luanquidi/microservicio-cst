using Servicios.Api.Cst.Aplication.Interfaces;
using Servicios.Api.Cst.Core.Entities;
using Servicios.Api.Cst.Core.Utils;
using Servicios.Api.Cst.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Aplication.Implementacion
{
    public class SitioTuristicoAplication : ISitioTuristicoAplication
    {
        // Inyección de dependencias.
        private readonly IMongoRepository<SitioTuristicoEntity> _sitioTuristicoRepository;

        // Método constructor.
        public SitioTuristicoAplication(IMongoRepository<SitioTuristicoEntity> sitioTuristicoRepository)
        {
            _sitioTuristicoRepository = sitioTuristicoRepository;
        }

        #region Métodos públicos

        /// <summary>
        /// Método para listar los sitios turisticos
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaOperacion<IEnumerable<SitioTuristicoEntity>>> ObtenerSitiosTuristicoAsync()
        {
            var respuesta = new RespuestaOperacion<IEnumerable<SitioTuristicoEntity>>();

            try
            {
                respuesta.Datos = await _sitioTuristicoRepository.GetAll();
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
        /// Método para obtener un sitio turistico por id de manera asíncrona.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RespuestaOperacion<SitioTuristicoEntity>> ObtenerSitioTuristicoAsync(string id)
        {
            var respuesta = new RespuestaOperacion<SitioTuristicoEntity>();

            try
            {
                respuesta.Datos = await _sitioTuristicoRepository.GetById(id);
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
        /// Método para actualizar un sitio turistico de manera asíncrona.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public async Task<RespuestaOperacion<bool>> ActualizarSitioTuristicoAsync(string id, SitioTuristicoEntity sitioTuristico)
        {
            var respuesta = new RespuestaOperacion<bool>();
            sitioTuristico.Id = id;
            try
            {
                await _sitioTuristicoRepository.UpdateDocument(sitioTuristico);
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
        /// Método para registrar un sitio turistico de manera asíncrona.
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public async Task<RespuestaOperacion<bool>> RegistrarSitioTuristicoAsync(SitioTuristicoEntity sitioTuristico)
        {
            var respuesta = new RespuestaOperacion<bool>();
            try
            {
                await _sitioTuristicoRepository.InsertDocument(sitioTuristico);
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
        /// Método para eliminar sitio turistico de manera asíncrona.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RespuestaOperacion<bool>> EliminarSitioTuristicoAsync(string id)
        {
            var respuesta = new RespuestaOperacion<bool>();
            try
            {
                await _sitioTuristicoRepository.DeleteById(id);
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
