using Microsoft.AspNetCore.Mvc;
using Servicios.Api.Cst.Aplication.Interfaces;
using Servicios.Api.Cst.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransporteController : Controller
    {
        private readonly ITransporteAplication _transporte;

         public TransporteController(ITransporteAplication transporte)
        {
            _transporte = transporte;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var respuesta = await _transporte.ObtenerTransportesAsync();
            return Ok(respuesta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var respuesta = await _transporte.ObtenerTransporteAsync(id);
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TransporteEntity transporte)
        {
            if (string.IsNullOrEmpty(transporte.Nit) || string.IsNullOrEmpty(transporte.Nombre) || string.IsNullOrEmpty(transporte.Informacion) || string.IsNullOrEmpty(transporte.Direccion) || transporte.Municipio is null)
            {
                return BadRequest("Todos los campos son obligatoríos.");
            }
            var respuesta = await _transporte.RegistrarTransporteAsync(transporte);
            return Ok(respuesta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, TransporteEntity transporte)
        {
            if (string.IsNullOrEmpty(transporte.Nit) || string.IsNullOrEmpty(transporte.Nombre) || string.IsNullOrEmpty(transporte.Informacion) || string.IsNullOrEmpty(transporte.Direccion) || transporte.Municipio is null)
            {
                return BadRequest("Todos los campos son obligatoríos.");
            }
            var respuesta = await _transporte.ActualizarTransporteAsync(id,transporte);
            return Ok(respuesta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var respuesta = await _transporte.EliminarTransporteAsync(id);
            return Ok(respuesta);
        }

    }
}
