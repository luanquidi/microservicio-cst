using Microsoft.AspNetCore.Mvc;
using Servicios.Api.Libreria.Core.Entities;
using Servicios.Api.Libreria.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibreriaServicioController : ControllerBase
    {
        // Definición de variables.
        private readonly IAutorRepository _autorRepository;
        private readonly IMongoRepository<AutorEntity> _autorGenericoRepository;
        private readonly IMongoRepository<EmpleadoEntity> _empleadoGenericoRepository;

        // Método constructor.
        public LibreriaServicioController(IAutorRepository autorRepository, IMongoRepository<AutorEntity> autorGenericoRepository, IMongoRepository<EmpleadoEntity> empleadoGenericoRepository)
        {
            _autorRepository = autorRepository;
            _autorGenericoRepository = autorGenericoRepository;
            _empleadoGenericoRepository = empleadoGenericoRepository;
        }

        /// <summary>
        /// Método para listar los autores con método generico.
        /// </summary>
        /// <returns></returns>
        [HttpGet("autorGenerico")]
        public async Task<ActionResult<IEnumerable<AutorEntity>>> GetAutoresGenericos ()
        {
            var respuesta = await _autorGenericoRepository.GetAll();
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para listar los empleados con método generico.
        /// </summary>
        /// <returns></returns>
        [HttpGet("empleadoGenerico")]
        public async Task<ActionResult<IEnumerable<EmpleadoEntity>>> GetEmpleadosGenericos()
        {
            var respuesta = await _empleadoGenericoRepository.GetAll();
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para listar los autores.
        /// </summary>
        /// <returns></returns>
        [HttpGet("autores")]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            var respuesta = await _autorRepository.GetAutores();
            return Ok(respuesta);
        }

    }
}
