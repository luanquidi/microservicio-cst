using MongoDB.Bson.Serialization.Attributes;
using Servicios.Api.Cst.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Core.Entities
{
    [BsonCollection("TipoRestaurante")]
    public class TipoRestauranteEntity : Document
    {
        [BsonElement("nombre")]
        public string Nombre { get; set; }
    }
}
