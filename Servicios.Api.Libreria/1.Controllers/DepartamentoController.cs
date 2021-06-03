using Microsoft.AspNetCore.Mvc;
using Servicios.Api.Cst.Aplication.Interfaces;
using Servicios.Api.Cst.Core.Entities;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        // Inyección de dependencias.
        private readonly IDepartamentoAplication _departamentoAplication;

        // Método constructor.
        public DepartamentoController(IDepartamentoAplication departamentoAplication)
        {
            _departamentoAplication = departamentoAplication;
        }

        #region Métodos públicos
        /// <summary>
        /// Método para listar departamento de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var respuesta = await _departamentoAplication.ObtenerDepartamentosAsync();
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para listar un departamento de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var respuesta = await _departamentoAplication.ObtenerDepartamentoAsync(id);
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para insertar un departamento de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(DepartamentoEntity departamento)
        {
            var respuesta = await _departamentoAplication.RegistrarDepartamentoAsync(departamento);
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para actualizar un departamento de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, DepartamentoEntity departamento)
        {
            var respuesta = await _departamentoAplication.ActualizarDepartamentoAsync(id, departamento);
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para eliminar un departamento de manera asíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var respuesta = await _departamentoAplication.EliminarDepartamentoAsync(id);
            return Ok(respuesta);
        }
        #endregion

    }
}
