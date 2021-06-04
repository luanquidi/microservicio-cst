using MongoDB.Bson.Serialization.Attributes;

namespace Servicios.Api.Cst.Core.Entities
{

    [BsonCollection("Hospedaje")]
    public class HospedajeEntity : Document
    {

        //[BsonRequired]
        [BsonElement("nombre")]
        public string Nombre { get; set; }

        //[BsonRequired]
        [BsonElement("nit")]
        public string Nit { get; set; }

        //[BsonRequired]
        [BsonElement("direccion")]
        public string Direccion { get; set; }

        //[BsonRequired]
        [BsonElement("municipio")]
        public MunicipioEntity Municipio { get; set; }

        //[BsonRequired]
        [BsonElement("cantidadEstrellas")]
        public int CantidadEstrellas { get; set; }

        //[BsonRequired]
        [BsonElement("informacion")]
        public string Informacion { get; set; }

    }
}
