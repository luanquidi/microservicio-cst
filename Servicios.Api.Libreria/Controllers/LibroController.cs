using Microsoft.AspNetCore.Mvc;
using Servicios.Api.Libreria.Core.Entities;
using Servicios.Api.Libreria.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IMongoRepository<LibroEntity> _libroRepository;
        public LibroController(IMongoRepository<LibroEntity> libroRepository)
        {
            _libroRepository = libroRepository;
        }

        /// <summary>
        /// Método para listar libros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroEntity>>> Get()
        {
            var respuesta = await _libroRepository.GetAll();
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para listar un libro.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<LibroEntity>> GetById(string id)
        {
            var respuesta = await _libroRepository.GetById(id);
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para insertar un libro.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task Post(LibroEntity libro)
        {
            await _libroRepository.InsertDocument(libro);
        }

        /// <summary>
        /// Método para actualizar un libro.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task Put(string id, LibroEntity libro)
        {
            libro.Id = id;
            await _libroRepository.UpdateDocument(libro);
        }

        /// <summary>
        /// Método para eliminar un libro.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _libroRepository.DeleteById(id);
        }


        /// <summary>
        /// Método para la paginación de registros con sin sensitive case.
        /// </summary>
        /// <returns></returns>
        [HttpPost("pagination")]
        public async Task<ActionResult<PaginationEntity<LibroEntity>>> PostPagination(PaginationEntity<LibroEntity> pagination)
        {
            var respuesta = await _libroRepository.PaginationByFilter(
                                pagination
                                );

            return Ok(respuesta);
        }
    }
}
