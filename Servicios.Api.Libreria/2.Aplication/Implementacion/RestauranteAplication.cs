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
    public class RestauranteAplication : IRestauranteAplication
    {
        // Inyección de dependencias.
        private readonly IMongoRepository<RestauranteEntity> _restauranteRepository;

        // Método constructor.
        public RestauranteAplication(IMongoRepository<RestauranteEntity> restauranteRepository)
        {
            _restauranteRepository = restauranteRepository;
        }
        public async Task<RespuestaOperacion<bool>> ActualizarRestauranteAsync(string id, RestauranteEntity restaurante)
        {
            var respuesta = new RespuestaOperacion<bool>();
            restaurante.Id = id;
            try
            {
                await _restauranteRepository.UpdateDocument(restaurante);
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

        public async Task<RespuestaOperacion<bool>> EliminarRestauranteAsync(string id)
        {
            var respuesta = new RespuestaOperacion<bool>();
            try
            {
                await _restauranteRepository.DeleteById(id);
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

        public async Task<RespuestaOperacion<RestauranteEntity>> ObtenerRestauranteAsync(string id)
        {
            var respuesta = new RespuestaOperacion<RestauranteEntity>();
            try
            {
                respuesta.Datos = await _restauranteRepository.GetById(id);
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

        public async Task<RespuestaOperacion<IEnumerable<RestauranteEntity>>> ObtenerRestaurantesAsync()
        {
            var respuesta = new RespuestaOperacion<IEnumerable<RestauranteEntity>>();
            try
            {
                respuesta.Datos = await _restauranteRepository.GetAll();
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

        public async Task<RespuestaOperacion<bool>> RegistrarRestauranteAsync(RestauranteEntity restaurante)
        {
            var respuesta = new RespuestaOperacion<bool>();
            try
            {
                await _restauranteRepository.InsertDocument(restaurante);
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
