
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Servicios.Api.Libreria.Core;
using Servicios.Api.Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Servicios.Api.Libreria.Repository
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
    {
        // Se inicializan variables globales.
        private readonly IMongoCollection<TDocument> _collection;

        // Método constructutor.
        public MongoRepository(IOptions<MongoSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            var db = client.GetDatabase(options.Value.Database);
            _collection = db.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }


        #region Métodos públicos
        /// <summary>
        /// Método para listar los documentos tratados.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TDocument>> GetAll()
        {
            return await _collection.Find(p => true).ToListAsync();
        }

        /// <summary>
        /// Método para obtener un documento en especifico por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TDocument> GetById(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Método para insertar un documento.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public async Task InsertDocument(TDocument document)
        {
            await _collection.InsertOneAsync(document);
        }

        /// <summary>
        /// Método para obtener y actualizar un documento.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public async Task UpdateDocument(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            await _collection.FindOneAndReplaceAsync(filter, document);
        }

        /// <summary>
        /// Método para eliminar un documento por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteById(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
            await _collection.FindOneAndDeleteAsync(filter);
        }

        /// <summary>
        /// Método para la paginación de documentos.
        /// </summary>
        /// <param name="filterExpression"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public async Task<PaginationEntity<TDocument>> PaginationBy(Expression<Func<TDocument, bool>> filterExpression, PaginationEntity<TDocument> pagination)
        {
            // Se establece lógica para saber si es ascendente o descendente.
            var sort = Builders<TDocument>.Sort.Ascending(pagination.Sort);
            if (pagination.SortDirection == "desc") {
                sort = Builders<TDocument>.Sort.Descending(pagination.Sort);
            }

            // Se establece la logica del filtro.
            if (string.IsNullOrEmpty(pagination.Filter))
            {
                pagination.Data = await _collection.Find(p => true)
                                   .Sort(sort)
                                   .Skip( (pagination.Page-1) * pagination.PageSize )
                                   .Limit( pagination.PageSize )
                                   .ToListAsync();
            }else
            {
                pagination.Data = await _collection.Find(filterExpression)
                                   .Sort(sort)
                                   .Skip((pagination.Page - 1) * pagination.PageSize)
                                   .Limit(pagination.PageSize)
                                   .ToListAsync();
            }

            // Se calculan los datos de la respuesta del filtro
            long totalDocuments = await _collection.CountDocumentsAsync(FilterDefinition<TDocument>.Empty);
            int totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalDocuments / pagination.PageSize)));
            pagination.PageQuantity = totalPages;
            pagination.TotalRows = Convert.ToInt32(totalDocuments);

            // Se retorna la paginación.
            return pagination;
        }

        /// <summary>
        /// Método para la paginación de documentos de forma sensitiveCase.
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public async Task<PaginationEntity<TDocument>> PaginationByFilter(PaginationEntity<TDocument> pagination)
        {
           

            // Se establece lógica para saber si es ascendente o descendente.
            var sort = Builders<TDocument>.Sort.Ascending(pagination.Sort);
            if (pagination.SortDirection == "desc")
            {
                sort = Builders<TDocument>.Sort.Descending(pagination.Sort);
            }
            // Cantidad de registros.
            var totalDocuments = 0;

            // Se establece la logica del filtro.
            if (pagination.FilterValue == null)
            {
                pagination.Data = await _collection.Find(p => true)
                                   .Sort(sort)
                                   .Skip((pagination.Page - 1) * pagination.PageSize)
                                   .Limit(pagination.PageSize)
                                   .ToListAsync();

                totalDocuments = (await _collection.Find(p => true).ToListAsync()).Count;
            }
            else
            {
                // Se inicializa el valor y propiedad a filtrar.
                var valueFilter = ".*" + pagination.FilterValue.Valor + ".*";
                var filter = Builders<TDocument>.Filter.Regex(pagination.FilterValue.Propiedad, new BsonRegularExpression(valueFilter, "i"));
                pagination.Data = await _collection.Find(filter)
                                   .Sort(sort)
                                   .Skip((pagination.Page - 1) * pagination.PageSize)
                                   .Limit(pagination.PageSize)
                                   .ToListAsync();
                totalDocuments = (await _collection.Find(filter).ToListAsync()).Count;
            }

            // Se calculan los datos de la respuesta del filtro
            //long totalDocuments = await _collection.CountDocumentsAsync(FilterDefinition<TDocument>.Empty);
            var rounded = Math.Ceiling(totalDocuments / Convert.ToDecimal(pagination.PageSize));
            int totalPages = Convert.ToInt32(rounded);
            pagination.PageQuantity = totalPages;
            pagination.TotalRows = Convert.ToInt32(totalDocuments);

            // Se retorna la paginación.
            return pagination;
        }

        #endregion

        #region Métodos privados
        /// <summary>
        /// Método para obtener el nombre de la collection de documentos.
        /// </summary>
        /// <param name="documentType"></param>
        /// <returns></returns>
        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()).CollectionName;
        }
        #endregion
    }
}
