using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb_C_
{
    public class cConductor
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("id")]
        public int IdConductor { get; set; }

        [BsonElement("Nombre")]
        public string Nombre { get; set; }

        [BsonElement("telefono")]
        public string telefono { get; set; }

        [BsonElement("id_vehiculo")]
        public int IdVehiculo { get; set; }
    
        [BsonElement("envios_entregados")]
        public int EnviosEntregados { get; set; }
    }
}
