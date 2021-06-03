using Microsoft.AspNetCore.Mvc;
using Servicios.Api.Cst.Aplication.Interfaces;
using Servicios.Api.Cst.Core.Entities;
using Servicios.Api.Cst.Core.Utils;
using Servicios.Api.Cst.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Aplication
{
    public class DepartamentoAplication : IDepartamentoAplication
    {
        // Inyección de dependencias.
        private readonly IMongoRepository<DepartamentoEntity> _departamentoRepository;

        // Método constructor.
        public DepartamentoAplication(IMongoRepository<DepartamentoEntity> departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        #region Métodos públicos

        /// <summary>
        /// Método para listar los departamentos de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaOperacion<IEnumerable<DepartamentoEntity>>> ObtenerDepartamentosAsync()
        {
            var respuesta = new RespuestaOperacion<IEnumerable<DepartamentoEntity>>();

            try
            {
                respuesta.Datos =  await _departamentoRepository.GetAll();
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
        /// Método para obtener un departamento por id de manera asíncrona.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RespuestaOperacion<DepartamentoEntity>> ObtenerDepartamentoAsync(string id)
        {
            var respuesta = new RespuestaOperacion<DepartamentoEntity>();

            try
            {
                respuesta.Datos = await _departamentoRepository.GetById(id);
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
        /// Método para actualizar un departamento de manera asíncrona.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public async Task<RespuestaOperacion<bool>> ActualizarDepartamentoAsync(string id, DepartamentoEntity departamento)
        {
            var respuesta = new RespuestaOperacion<bool>();
            departamento.Id = id;
            try
            {
                await _departamentoRepository.UpdateDocument(departamento);
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
        /// Método para registrar un departamento de manera asíncrona.
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public async Task<RespuestaOperacion<bool>> RegistrarDepartamentoAsync(DepartamentoEntity departamento)
        {
            var respuesta = new RespuestaOperacion<bool>();
            try
            {
                await _departamentoRepository.InsertDocument(departamento);
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
        /// Método para eliminar departamento de manera asíncrona.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RespuestaOperacion<bool>> EliminarDepartamentoAsync(string id)
        {
            var respuesta = new RespuestaOperacion<bool>();
            try
            {
                await _departamentoRepository.DeleteById(id);
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
