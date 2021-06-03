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
    public class TipoRestauranteAplication : ITipoRestauranteAplication
    {

        // Inyección de dependencias.
        private readonly IMongoRepository<TipoRestauranteEntity> _tipoRestauranteRepository;

        // Método constructor.
        public TipoRestauranteAplication(IMongoRepository<TipoRestauranteEntity> tipoRestauranteRepository)
        {
            _tipoRestauranteRepository = tipoRestauranteRepository;
        }
        public async Task<RespuestaOperacion<bool>> ActualizarTipoRestauranteAsync(string id, TipoRestauranteEntity tipoRestaurante)
        {
            var respuesta = new RespuestaOperacion<bool>();
            tipoRestaurante.Id = id;
            try
            {
                await _tipoRestauranteRepository.UpdateDocument(tipoRestaurante);
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

        public async Task<RespuestaOperacion<bool>> EliminarTipoRestauranteAsync(string id)
        {
            var respuesta = new RespuestaOperacion<bool>();
            try
            {
                await _tipoRestauranteRepository.DeleteById(id);
                respuesta.Mensaje = "La operación se ha realizado correctamente.";
                respuesta.ResultadoExitoso = true;
            } 
            catch( Exception ex )
            {
                respuesta.ResultadoExitoso = false;
                respuesta.Mensaje = ex.Message;
            }

            return respuesta;
        }

        public async Task<RespuestaOperacion<TipoRestauranteEntity>> ObtenerTipoRestauranteAsync(string id)
        {
            var respuesta = new RespuestaOperacion<TipoRestauranteEntity>();
            try
            {
                respuesta.Datos = await _tipoRestauranteRepository.GetById(id);
                respuesta.Mensaje = "La operación se ha realizado correctamente.";
                respuesta.ResultadoExitoso = true;
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
                respuesta.ResultadoExitoso = false;
            }
            return respuesta;
        }

        public async Task<RespuestaOperacion<IEnumerable<TipoRestauranteEntity>>> ObtenerTiposRestaurantesAsync()
        {
            var respuesta = new RespuestaOperacion<IEnumerable<TipoRestauranteEntity>>();
            try
            {
                respuesta.Datos = await _tipoRestauranteRepository.GetAll();
                respuesta.Mensaje = "La operación se ha realizado correctamente.";
                respuesta.ResultadoExitoso = true;
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
                respuesta.ResultadoExitoso = false;
            }

            return respuesta;
        }

        public async Task<RespuestaOperacion<bool>> RegistrarTipoRestauranteAsync(TipoRestauranteEntity tipoRestaurante)
        {
            var respuesta = new RespuestaOperacion<bool>();
            try
            {
                await _tipoRestauranteRepository.InsertDocument(tipoRestaurante);
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
    }
}
