using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb_C_
{
    public class cPedido
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("id")]
        public int IdPedido { get; set; }

        [BsonElement("id_cliente")]
        public int IdCliente { get; set; }

        [BsonElement("fecha_del_pedido")]
        public string FechaPedido { get; set; }

        [BsonElement("tiempo_de_entrega")]
        public int TiempoEntrega { get; set; }

        [BsonElement("estado_Entrega")]
        public string EstadoEntrega { get; set; }

        [BsonElement("ciudad_de_entrega")]
        public string CiudadEntrega { get; set; }

        [BsonElement("Costo pedido")]
        public int Costo { get; set; }
    }
}
