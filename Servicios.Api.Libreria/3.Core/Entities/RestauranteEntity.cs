using MongoDB.Bson.Serialization.Attributes;
using Servicios.Api.Cst.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Api.Cst.Core.Entities
{
    [BsonCollection("Restaurante")]

    public class RestauranteEntity : Document
    {
        [BsonElement("nit")]
        public string Nit { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("direccion")]
        public string Direccion { get; set; }

        [BsonElement("municipio")]
        public MunicipioEntity Municipio { get; set; }

        [BsonElement("tipoRestaurante")]
        public TipoRestauranteEntity TipoRestaurante { get; set; }

        [BsonElement("cantidadEstrellas")]
        public int CantidadEstrellas { get; set; }

        [BsonElement("informacion")]
        public string Informacion { get; set; }

        [BsonElement("descripcion")]
        public string Descripcion { get; set; }

    }
}
