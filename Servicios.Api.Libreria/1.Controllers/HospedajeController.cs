using Microsoft.AspNetCore.Mvc;
using Servicios.Api.Cst.Aplication.Interfaces;
using Servicios.Api.Cst.Core.Entities;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospedajeController : ControllerBase
    {
        // Inyección de dependencias.
        private readonly IHospedajeAplication _hospedajeAplication;

        // Método constructor.
        public HospedajeController(IHospedajeAplication hospedajeAplication)
        {
            _hospedajeAplication = hospedajeAplication;
        }

        #region Métodos públicos
        /// <summary>
        /// Método para listar departamento de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var respuesta = await _hospedajeAplication.ObtenerHospedajesAsync();
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para listar un departamento de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var respuesta = await _hospedajeAplication.ObtenerHospedajeAsync(id);
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para insertar un departamento de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(HospedajeEntity hospedaje)
        {
            if(string.IsNullOrEmpty(hospedaje.Nombre) || string.IsNullOrEmpty(hospedaje.Direccion) || string.IsNullOrEmpty(hospedaje.Nit) || string.IsNullOrEmpty(hospedaje.Informacion))
            {
                return BadRequest("Todos los campos son obligatoríos.");
            }
            var respuesta = await _hospedajeAplication.RegistrarHospedajeAsync(hospedaje);
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para actualizar un departamento de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, HospedajeEntity hospedaje)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(hospedaje.Nombre) || string.IsNullOrEmpty(hospedaje.Direccion) || string.IsNullOrEmpty(hospedaje.Nit) || string.IsNullOrEmpty(hospedaje.Informacion))
            {
                return BadRequest("Todos los campos son obligatoríos.");
            }
            var respuesta = await _hospedajeAplication.ActualizarHospedajeAsync(id, hospedaje);
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para eliminar un departamento de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var respuesta = await _hospedajeAplication.EliminarHospedajeAsync(id);
            return Ok(respuesta);
        }
        #endregion

    }
}
