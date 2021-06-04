
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Servicios.Api.Cst.Core;
using Servicios.Api.Cst.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Repository
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
            var filter = Builders<TDocument>.Filter.Eq(x => x.Estado, 1);
            return await _collection.Find(filter).ToListAsync();
            //return await _collection.Find(p => true).ToListAsync();
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
        /// Método para obtener y ocultar un documento.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public async Task DeleteById(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
            var update = Builders<TDocument>.Update.Set("estado", 0);
            await _collection.UpdateOneAsync(filter, update);
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
