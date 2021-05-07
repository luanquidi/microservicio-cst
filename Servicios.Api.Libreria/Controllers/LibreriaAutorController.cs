using Microsoft.AspNetCore.Mvc;
using Servicios.Api.Libreria.Core.Entities;
using Servicios.Api.Libreria.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibreriaAutorController : ControllerBase
    {
        private readonly IMongoRepository<AutorEntity> _autorRepository;
        public LibreriaAutorController(IMongoRepository<AutorEntity> autorRepository)
        {
            _autorRepository = autorRepository;
        }

        /// <summary>
        /// Método para listar autores.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorEntity>>> Get()
        {
            var respuesta = await _autorRepository.GetAll();
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para listar un autor.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AutorEntity>> GetById(string id)
        {
            var respuesta = await _autorRepository.GetById(id);
            return Ok(respuesta);
        }

        /// <summary>
        /// Método para insertar un autor.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task Post(AutorEntity autor)
        {
            await _autorRepository.InsertDocument(autor);
        }

        /// <summary>
        /// Método para actualizar un autor.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task Put(string id, AutorEntity autor)
        {
            autor.Id = id;
            await _autorRepository.UpdateDocument(autor);
        }

        /// <summary>
        /// Método para eliminar un autor.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _autorRepository.DeleteById(id);
        }


        /// <summary>
        /// Método para la paginación de registros con sin sensitive case.
        /// </summary>
        /// <returns></returns>
        [HttpPost("pagination")]
        public async Task<ActionResult<PaginationEntity<AutorEntity>>> PostPagination(PaginationEntity<AutorEntity> pagination)
        {
            var respuesta = await _autorRepository.PaginationByFilter(
                                pagination
                                );

            return Ok(respuesta);
        }


    }
}
