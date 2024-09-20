using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb_C_
{
    public class cEntrega
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("id")]
        public int IdEntrega { get; set; }

        [BsonElement("id_pedido")]
        public int IdPedido { get; set; }

        [BsonElement("id_vehiculo")]
        public int IdVehiculo { get; set; }

        [BsonElement("ruta_id")]
        public int IdRuta { get; set; }
        
    }
}
