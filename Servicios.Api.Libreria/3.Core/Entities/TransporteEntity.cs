using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Core.Entities
{
    [BsonCollection("Transporte")]

    public class TransporteEntity : Document
    {
        [BsonElement("nit")]
        public string Nit { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("direccion")]
        public string Direccion { get; set; }

        [BsonElement("municipio")]
        public MunicipioEntity Municipio { get; set; }

        [BsonElement("informacion")]
        public string Informacion { get; set; }
        
    }
}
