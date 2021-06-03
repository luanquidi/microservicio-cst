using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Servicios.Api.Cst.Core.Entities
{
    [BsonCollection("Municipio")]
    public class MunicipioEntity : Document
    {
        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("historia")]
        public string Historia { get; set; }

        [BsonElement("fechaFundacion")]
        public DateTime? FechaFundacion { get; set; }

        [BsonElement("cultura")]
        public string Cultura { get; set; }

        [BsonElement("departamento")]
        public DepartamentoEntity Departamento { get; set; }


    }

}
