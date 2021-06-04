using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Servicios.Api.Cst.Core.Entities
{

    [BsonCollection("Departamento")]
    public class DepartamentoEntity : Document
    {
       
        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("historia")]
        public string Historia { get; set; }

        [BsonElement("fechaFundacion")]
        public DateTime? FechaFundacion { get; set; }

        
    }
}
