using Servicios.Api.Cst.Aplication.Interfaces;
using Servicios.Api.Cst.Core.Entities;
using Servicios.Api.Cst.Core.Utils;
using Servicios.Api.Cst.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Aplication.Implementacion
{
    public class MunicipioAplication : IMunicipioAplication
    {
        // Inyección de dependencias.
        private readonly IMongoRepository<MunicipioEntity> _municipioRepository;

        // Método constructor.
        public MunicipioAplication(IMongoRepository<MunicipioEntity> municipioRepository)
        {
            _municipioRepository = municipioRepository;
        }

        #region Métodos públicos

        /// <summary>
        /// Método para listar los municipios de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaOperacion<IEnumerable<MunicipioEntity>>> ObtenerMunicipiosAsync()
        {
            var respuesta = new RespuestaOperacion<IEnumerable<MunicipioEntity>>();

            try
            {
                respuesta.Datos = await _municipioRepository.GetAll();
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
        /// Método para obtener un municipio por id de manera asíncrona.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RespuestaOperacion<MunicipioEntity>> ObtenerMunicipioAsync(string id)
        {
            var respuesta = new RespuestaOperacion<MunicipioEntity>();

            try
            {
                respuesta.Datos = await _municipioRepository.GetById(id);
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
        /// Método para actualizar un municipio de manera asíncrona.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public async Task<RespuestaOperacion<bool>> ActualizarMunicipioAsync(string id, MunicipioEntity municipio)
        {
            var respuesta = new RespuestaOperacion<bool>();
            municipio.Id = id;
            try
            {
                await _municipioRepository.UpdateDocument(municipio);
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
        /// Método para registrar un municipio de manera asíncrona.
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public async Task<RespuestaOperacion<bool>> RegistrarMunicipioAsync(MunicipioEntity municipio)
        {
            var respuesta = new RespuestaOperacion<bool>();
            try
            {
                await _municipioRepository.InsertDocument(municipio);
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
        /// Método para eliminar municipio de manera asíncrona.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RespuestaOperacion<bool>> EliminarMunicipioAsync(string id)
        {
            var respuesta = new RespuestaOperacion<bool>();
            try
            {
                await _municipioRepository.DeleteById(id);
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
