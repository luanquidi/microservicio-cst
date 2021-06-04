using MongoDB.Bson.Serialization.Attributes;

namespace Servicios.Api.Cst.Core.Entities
{
    [BsonCollection("SitioTuristico")]

    public class SitioTuristicoEntity : Document
    {
        [BsonElement("nit")]
        public string Nit { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("direccion")]
        public string Direccion { get; set; }

        [BsonElement("numeroRegistro")]
        public string NumeroRegistro { get; set; }

        [BsonElement("contacto")]
        public string Contacto { get; set; }

        [BsonElement("correo")]
        public string Correo { get; set; }

        [BsonElement("descripcion")]
        public string Descripcion { get; set; }

        [BsonElement("zona")]
        public string Zona { get; set; }

        [BsonElement("municipio")]
        public MunicipioEntity Municipio { get; set; }

        [BsonElement("telefono")]
        public string Telefono { get; set; }

        [BsonElement("nombreRepresentanteLegal")]
        public string NombreRepresentanteLegal { get; set; }

        [BsonElement("numeroEmpleados")]
        public string NumeroEmpleados { get; set; }

        [BsonElement("actividadPrincipal")]
        public string ActividadPrincipal { get; set; }

        [BsonElement("informacion")]
        public string Informacion { get; set; }

    }
}
