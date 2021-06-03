using Microsoft.AspNetCore.Mvc;
using Servicios.Api.Cst.Aplication.Interfaces;
using Servicios.Api.Cst.Core.Entities;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        // Inyección de dependencias.
        private readonly IMunicipioAplication _municipioAplication;

        // Método constructor.
        public MunicipioController(IMunicipioAplication municipioAplication)
        {
            _municipioAplication = municipioAplication;
        }

        #region Métodos públicos
        /// <summary>
        /// Método para listar municipios de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var respuesta = await _municipioAplication.ObtenerMunicipiosAsync();
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para listar un municipio de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var respuesta = await _municipioAplication.ObtenerMunicipioAsync(id);
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para insertar un municipio de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(MunicipioEntity municipio)
        {
            var respuesta = await _municipioAplication.RegistrarMunicipioAsync(municipio);
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para actualizar un municipio de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, MunicipioEntity municipio)
        {
            var respuesta = await _municipioAplication.ActualizarMunicipioAsync(id, municipio);
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para eliminar un municipio de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var respuesta = await _municipioAplication.EliminarMunicipioAsync(id);
            return Ok(respuesta);
        }
        #endregion
    }
}
