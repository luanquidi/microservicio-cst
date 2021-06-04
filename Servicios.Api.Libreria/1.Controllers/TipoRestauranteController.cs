using Microsoft.AspNetCore.Mvc;
using Servicios.Api.Cst.Aplication.Interfaces;
using Servicios.Api.Cst.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoRestauranteController : Controller
    {
        // Inyección de dependencias.
        private readonly ITipoRestauranteAplication _tipoRestauranteAplication;

        // Método constructor.
        public TipoRestauranteController(ITipoRestauranteAplication tipoRestauranteAplication)
        {
            _tipoRestauranteAplication = tipoRestauranteAplication;
        }

        //Obtener todos los tipos de restaurantes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var respuesta = await _tipoRestauranteAplication.ObtenerTiposRestaurantesAsync();
            return Ok(respuesta);
        }

        //Obtener un tipo de restaurante en especifico
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var respuesta = await _tipoRestauranteAplication.ObtenerTipoRestauranteAsync(id);
            return Ok(respuesta);
        }

        //Crear nuevo tipo restaurante
        [HttpPost]
        public async Task<IActionResult> Post(TipoRestauranteEntity tipoRestaurante)
        {
            if (string.IsNullOrEmpty(tipoRestaurante.Nombre))
            {
                return BadRequest("Todos los campos son obligatoríos.");
            }
            var respuesta = await _tipoRestauranteAplication.RegistrarTipoRestauranteAsync(tipoRestaurante);
            return Ok(respuesta);
        }

        //Editar tipo de restaurante
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, TipoRestauranteEntity tipoRestaurante)
        {
            if (string.IsNullOrEmpty(tipoRestaurante.Nombre))
            {
                return BadRequest("Todos los campos son obligatoríos.");
            }
            var respuesta = await _tipoRestauranteAplication.ActualizarTipoRestauranteAsync(id, tipoRestaurante);
            return Ok(respuesta);
        }

        //Eliminar restaurante
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var respuesta = await _tipoRestauranteAplication.EliminarTipoRestauranteAsync(id);
            return Ok(respuesta);
        }
    }
}
