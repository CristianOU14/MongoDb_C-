using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb_C_
{
    public class cCliente
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("id_cliente")]
        public int IdCliente { get; set; }

        [BsonElement("Nombre")]
        public string Nombre { get; set; }

        [BsonElement("Ciudad_recidencia")]
        public string Ciudad_recidencia { get; set; }

        [BsonElement("telefono")]
        public string telefono { get; set; }
        [BsonElement("email")]
        public string email { get; set; }
    }
}
