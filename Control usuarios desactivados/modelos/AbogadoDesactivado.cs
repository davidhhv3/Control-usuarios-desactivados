using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados.modelos
{
    public class AbogadoDesactivado
    {
        [BsonElement("IdAbogado")]
        public string IdAbogado { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("FechaDesactivacion")]
        public string FechaDesactivacion { get; set; }

        [BsonElement("Reactivado")]
        public bool Reactivado { get; set; }

        [BsonElement("FechaReactivado")]
        public string FechaReactivado { get; set; }

        [BsonElement("UltimaFechaConsultaReactiva")]
        public string UltimaFechaConsultaReactiva { get; set; }

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id_particular { get; set; }
    }
}
