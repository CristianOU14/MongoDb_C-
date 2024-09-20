using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MongoDb_C_
{
    public class cEmpleado
    {
            [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("id_empleado")]
    public int IdEmpleado { get; set; }
    
    [BsonElement("nombre")]
    public string Nombre { get; set; }
    
    [BsonElement("salario")]
    public double Salario { get; set; }


    }
}
