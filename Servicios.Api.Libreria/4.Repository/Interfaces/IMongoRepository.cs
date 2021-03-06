using Servicios.Api.Cst.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Repository
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        Task<IEnumerable<TDocument>> GetAll();
        Task<TDocument> GetById(string id);
        Task InsertDocument(TDocument document);
        Task UpdateDocument(TDocument document);
        //Task HideDocument(TDocument document);
        Task DeleteById(string id);
    }
}
