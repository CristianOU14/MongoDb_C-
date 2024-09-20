using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb_C_
{
    public class cVehiculo
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("id")]
        public int Idvehiculo { get; set; }

        [BsonElement("marca")]
        public string Marca { get; set; }

        [BsonElement("modelo")]
        public string modelo { get; set; }

        [BsonElement("placa")]
        public string Placa { get; set; }

        [BsonElement("capacidad")]
        public int Capacidad { get; set; }

        [BsonElement("estado")]
        public string Estado { get; set; }

        [BsonElement("Distancia_recorrida_X_Hora")]
        public string DistanciaHora { get; set; }
    }
}
