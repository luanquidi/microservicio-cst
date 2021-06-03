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
    public class TransporteAplication : ITransporteAplication
    {

        private readonly IMongoRepository<TransporteEntity> _transporte;

        public TransporteAplication(IMongoRepository<TransporteEntity> transporte)
        {
            _transporte = transporte;
        }
        public async Task<RespuestaOperacion<bool>> ActualizarTransporteAsync(string id, TransporteEntity transporte)
        {
            var respuesta = new RespuestaOperacion<bool>();
            transporte.Id = id;
            try
            {
                await _transporte.UpdateDocument(transporte);
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

        public async Task<RespuestaOperacion<bool>> EliminarTransporteAsync(string id)
        {
            var respuesta = new RespuestaOperacion<bool>();
            try
            {
                await _transporte.DeleteById(id);
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

        public async Task<RespuestaOperacion<TransporteEntity>> ObtenerTransporteAsync(string id)
        {
            var respuesta = new RespuestaOperacion<TransporteEntity>();
            try
            {
                respuesta.Datos = await _transporte.GetById(id);
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

        public async Task<RespuestaOperacion<IEnumerable<TransporteEntity>>> ObtenerTransportesAsync()
        {
            var respuesta = new RespuestaOperacion<IEnumerable<TransporteEntity>>();
            try
            {
                respuesta.Datos = await _transporte.GetAll();
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

        public async Task<RespuestaOperacion<bool>> RegistrarTransporteAsync(TransporteEntity transporte)
        {
            var respuesta = new RespuestaOperacion<bool>();
            try
            {
                await _transporte.InsertDocument(transporte);
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
    }
}
