using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb_C_
{
    public class cConexion
    {
        private IMongoDatabase database;
        private IMongoCollection<cEmpleado> collection;
        private IMongoCollection<cCliente> collection1;
        private IMongoCollection<cConductor> collection2;
        private IMongoCollection<cCiudad> collection3;
        private IMongoCollection<cEntrega> collection4;
        private IMongoCollection<cPedido> collection5;
        private IMongoCollection<cRuta> collection6;
        private IMongoCollection<cVehiculo> collection7;


        public cConexion()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("ProyectoBDnoEstructuradas");
            collection = database.GetCollection<cEmpleado>("Empleado");
            collection1 = database.GetCollection<cCliente>("Clientes");
            collection2 = database.GetCollection<cConductor>("Conductores");
            collection3 = database.GetCollection<cCiudad>("Ciudades");
            collection4 = database.GetCollection<cEntrega>("Entregas");
            collection5 = database.GetCollection<cPedido>("Pedidos");
            collection6 = database.GetCollection<cRuta>("Rutas");
            collection7 = database.GetCollection<cVehiculo>("Vehiculos");
        }

        public void InsertarEmpleado(cEmpleado empleado)
        {
            collection.InsertOne(empleado);
        }

        public List<cEmpleado> ObtenerTodosLosEmpleados()
        {
            return collection.Find(_ => true).ToList();
        }

        public cEmpleado ObtenerEmpleadoPorId(int id)
        {
            return collection.Find(empleado => empleado.IdEmpleado == id).FirstOrDefault();
        }

        public void ActualizarEmpleado(int id, cEmpleado empleado)
        {
            collection.ReplaceOne(e => e.IdEmpleado == id, empleado);
        }

        public DeleteResult EliminarEmpleado(int id)
        {
            var filter = Builders<cEmpleado>.Filter.Eq(emp => emp.IdEmpleado, id);
            return collection.DeleteOne(filter);
        }
        public void InsertarCliente(cCliente cliente)
        {
            collection1.InsertOne(cliente);
        }

        public List<cCliente> ObtenerTodosLosClientes()
        {
            return collection1.Find(_ => true).ToList();
        }

        public cCliente ObtenerClientesPorId(int id)
        {
            return collection1.Find(cl => cl.IdCliente == id).FirstOrDefault();
        }

        public void ActualizarClientes(int id, cCliente cliente)
        {
            collection1.ReplaceOne(e => e.IdCliente == id, cliente);
        }

        public DeleteResult EliminarCliente(int id)
        {
            var filter = Builders<cCliente>.Filter.Eq(emp => emp.IdCliente, id);
            return collection1.DeleteOne(filter);
        }

        public void InsertarConductor(cConductor conductor)
        {
            collection2.InsertOne(conductor);
        }
        public List<cConductor> ObtenerTodosLosConductores()
        {
            return collection2.Find(_ => true).ToList();
        }

        public cConductor ObtenerConductoresPorId(int id)
        {
            return collection2.Find(conductor => conductor.IdConductor == id).FirstOrDefault();
        }

        public void ActualizarConductor(int id, cConductor conductor)
        {
            collection2.ReplaceOne(e => e.IdConductor == id, conductor);
        }

        public DeleteResult EliminarConductor(int id)
        {
            var filter = Builders<cConductor>.Filter.Eq(emp => emp.IdConductor, id);
            return collection2.DeleteOne(filter);
        }
        
        public void InsertarCiudad(cCiudad ciudad)
        {
            collection3.InsertOne(ciudad);
        }
        public List<cCiudad> ObtenerTodosLasCiudades()
        {
            return collection3.Find(_ => true).ToList();
        }

        public cCiudad ObtenerCiudadesPorId(String Nombre)
        {
            return collection3.Find(conductor => conductor.Nombre == Nombre).FirstOrDefault();
        }

        public void ActualizarCiudad(String Nombre, cCiudad ciudad)
        {
            collection3.ReplaceOne(e => e.Nombre == Nombre, ciudad);
        }

        public DeleteResult EliminarCiudad(String Nombre)
        {
            var filter = Builders<cCiudad>.Filter.Eq(emp => emp.Nombre, Nombre);
            return collection3.DeleteOne(filter);
        }
        
        public void InsertarEntrega(cEntrega entrega)
        {
            collection4.InsertOne(entrega);
        }
        public List<cEntrega> ObtenerTodosLasEntregas()
        {
            return collection4.Find(_ => true).ToList();
        }

        public cEntrega ObtenerEntregasPorId(int id)
        {
            return collection4.Find(conductor => conductor.IdEntrega == id).FirstOrDefault();
        }

        public void ActualizarEntrega(int id, cEntrega entrega)
        {
            collection4.ReplaceOne(e => e.IdEntrega == id, entrega);
        }

        public DeleteResult EliminarEntrega(int id)
        {
            var filter = Builders<cEntrega>.Filter.Eq(emp => emp.IdEntrega, id);
            return collection4.DeleteOne(filter);
        }
        
        public void InsertarPedido(cPedido pedido)
        {
            collection5.InsertOne(pedido);
        }
        public List<cPedido> ObtenerTodosLosPedidos()
        {
            return collection5.Find(_ => true).ToList();
        }

        public cPedido ObtenerPedidosPorId(int id)
        {
            return collection5.Find(conductor => conductor.IdPedido == id).FirstOrDefault();
        }

        public void ActualizarPedido(int id, cPedido pedido)
        {
            collection5.ReplaceOne(e => e.IdPedido == id, pedido);
        }

        public DeleteResult EliminarPedido (int id)
        {
            var filter = Builders<cPedido>.Filter.Eq(emp => emp.IdPedido, id);
            return collection5.DeleteOne(filter);
        }
        
        public void InsertarRuta(cRuta ruta)
        {
            collection6.InsertOne(ruta);
        }
        public List<cRuta> ObtenerTodosLasRutas()
        {
            return collection6.Find(_ => true).ToList();
        }

        public cRuta ObtenerRutasPorId(int id)
        {
            return collection6.Find(conductor => conductor.IdRuta == id).FirstOrDefault();
        }

        public void ActualizarRuta(int id, cRuta ruta)
        {
            collection6.ReplaceOne(e => e.IdRuta == id, ruta);
        }

        public DeleteResult EliminarRuta(int id)
        {
            var filter = Builders<cRuta>.Filter.Eq(emp => emp.IdRuta, id);
            return collection6.DeleteOne(filter);
        }
        
        public void InsertarVehiculo(cVehiculo vehiculo)
        {
            collection7.InsertOne(vehiculo);
        }
        public List<cVehiculo> ObtenerTodosLosVehiculos()
        {
            return collection7.Find(_ => true).ToList();
        }

        public cVehiculo ObtenerVehiculoPorId(int id)
        {
            return collection7.Find(conductor => conductor.Idvehiculo == id).FirstOrDefault();
        }

        public void ActualizarVehiculo(int id, cVehiculo vehiculo)
        {
            collection7.ReplaceOne(e => e.Idvehiculo == id, vehiculo);
        }

        public DeleteResult EliminarVehiculo(int id)
        {
            var filter = Builders<cVehiculo>.Filter.Eq(emp => emp.Idvehiculo, id);
            return collection7.DeleteOne(filter);
        }
    }
}
