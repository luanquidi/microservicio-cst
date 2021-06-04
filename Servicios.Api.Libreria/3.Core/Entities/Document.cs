using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Servicios.Api.Cst.Core.Entities
{
    public class Document : IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime CreatedDate => DateTime.Now;

        [BsonElement("estado")]
        public int Estado => 1;

    }
}
