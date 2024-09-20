using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb_C_
{
    public class cRuta
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("id")]
        public int IdRuta { get; set; }

        [BsonElement("ciudad_origen")]
        public string CiudadOrigen { get; set; }

        [BsonElement("destino")]
        public string Destino { get; set; }

        [BsonElement("distancia_km")]
        public int Distancia { get; set; }

        [BsonElement("pedidos_pasados")]
        public int PedidosPasados { get; set; }
    }
}
