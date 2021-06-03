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
    public class RestauranteController : Controller   
    {
        // Inyección de dependencias.
        private readonly IRestauranteAplication _restauranteAplication;

        // Método constructor.
        public RestauranteController(IRestauranteAplication restauranteAplication)
        {
            _restauranteAplication = restauranteAplication;
        }
        
        //Obtener todos los restaurantes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var respuesta = await _restauranteAplication.ObtenerRestaurantesAsync();
            return Ok(respuesta);
        }

        //Obtener un restaurante en especifico
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var respuesta = await _restauranteAplication.ObtenerRestauranteAsync(id);
            return Ok(respuesta);
        }

        //Crear nuevo restaurante
        [HttpPost]
        public async Task<IActionResult> Post(RestauranteEntity restaurante)
        {
            var respuesta = await _restauranteAplication.RegistrarRestauranteAsync(restaurante);
            return Ok(respuesta);
        }

        //Editar restaurante
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, RestauranteEntity restaurante)
        {
            var respuesta = await _restauranteAplication.ActualizarRestauranteAsync(id, restaurante);
            return Ok(respuesta);
        }

        //Eliminar restaurante
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var respuesta = await _restauranteAplication.EliminarRestauranteAsync(id);
            return Ok(respuesta);
        }

    }
}
