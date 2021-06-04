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
    public class SitioTuristicoController : Controller
    {
        // Inyección de dependencias.
        private readonly ISitioTuristicoAplication _sitioTuristicoAplication;

        // Método constructor.
        public SitioTuristicoController(ISitioTuristicoAplication sitioTuristicoAplication)
        {
            _sitioTuristicoAplication = sitioTuristicoAplication;
        }

        #region Métodos públicos
        /// <summary>
        /// Método para listar sitios turisticos de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var respuesta = await _sitioTuristicoAplication.ObtenerSitiosTuristicoAsync();
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para listar un sitio turistico de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var respuesta = await _sitioTuristicoAplication.ObtenerSitioTuristicoAsync(id);
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para insertar un sitio turistico de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(SitioTuristicoEntity sitioTuristico)
        {
            if (string.IsNullOrEmpty(sitioTuristico.Nit) || string.IsNullOrEmpty(sitioTuristico.Nombre) || string.IsNullOrEmpty(sitioTuristico.Informacion) || string.IsNullOrEmpty(sitioTuristico.Direccion) || sitioTuristico.Municipio is null || string.IsNullOrEmpty(sitioTuristico.ActividadPrincipal)
                || string.IsNullOrEmpty(sitioTuristico.Contacto) || string.IsNullOrEmpty(sitioTuristico.Correo) || string.IsNullOrEmpty(sitioTuristico.Telefono) || string.IsNullOrEmpty(sitioTuristico.Zona) || string.IsNullOrEmpty(sitioTuristico.NombreRepresentanteLegal) || string.IsNullOrEmpty(sitioTuristico.NumeroRegistro))
            {
                return BadRequest("Todos los campos son obligatoríos.");
            }
            var respuesta = await _sitioTuristicoAplication.RegistrarSitioTuristicoAsync(sitioTuristico);
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para actualizar un sitio turistico de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, SitioTuristicoEntity sitioTuristico)
        {
            if (string.IsNullOrEmpty(sitioTuristico.Nit) || string.IsNullOrEmpty(sitioTuristico.Nombre) || string.IsNullOrEmpty(sitioTuristico.Informacion) || string.IsNullOrEmpty(sitioTuristico.Direccion) || sitioTuristico.Municipio is null || string.IsNullOrEmpty(sitioTuristico.ActividadPrincipal)
                || string.IsNullOrEmpty(sitioTuristico.Contacto) || string.IsNullOrEmpty(sitioTuristico.Correo) || string.IsNullOrEmpty(sitioTuristico.Telefono) || string.IsNullOrEmpty(sitioTuristico.Zona) || string.IsNullOrEmpty(sitioTuristico.NombreRepresentanteLegal) || string.IsNullOrEmpty(sitioTuristico.NumeroRegistro))
            {
                return BadRequest("Todos los campos son obligatoríos.");
            }
            var respuesta = await _sitioTuristicoAplication.ActualizarSitioTuristicoAsync(id, sitioTuristico);
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para eliminar un sitio turistico de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var respuesta = await _sitioTuristicoAplication.EliminarSitioTuristicoAsync(id);
            return Ok(respuesta);
        }
        #endregion
    }
}
