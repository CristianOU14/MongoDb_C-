using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb_C_
{
    public class cCiudad
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Nombre_Ciudad")]
        public string Nombre { get; set; }
        [BsonElement("Estado")]
        public string estado { get; set; }
    }
}
