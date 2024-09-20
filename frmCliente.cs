using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;

namespace MongoDb_C_
{
    public partial class frmCliente : Form
    {
        cConexion cn = new cConexion();
        private IMongoCollection<cCliente> collection1;
        public frmCliente()
        {
            InitializeComponent();
            var cliente = new MongoClient("mongodb://localhost:27017");
            var database = cliente.GetDatabase("ProyectoBDnoEstructuradas");
            collection1 = database.GetCollection<cCliente>("Clientes");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            cCliente nuevoCliente = new cCliente()
            {
                IdCliente = Convert.ToInt32(txtIdCliente.Text),
                Nombre = txtNombre.Text,
                Ciudad_recidencia = txtCiudadR.Text,
                telefono = txtTelefono.Text,
                email = txtEmail.Text
            };

            cn.InsertarCliente(nuevoCliente);
        }

        private void btnListaEmpleados_Click(object sender, EventArgs e)
        {
            dtgCliente.Rows.Clear();
            int indice;
            var Clientes = cn.ObtenerTodosLosClientes();
            foreach (var cliente in Clientes)
            {
                indice = dtgCliente.Rows.Add(); // Agregar una nueva fila y obtener su índice
                dtgCliente.Rows[indice].Cells[0].Value = cliente.IdCliente;
                dtgCliente.Rows[indice].Cells[1].Value = cliente.Nombre;
                dtgCliente.Rows[indice].Cells[2].Value = cliente.Ciudad_recidencia;
                dtgCliente.Rows[indice].Cells[3].Value = cliente.telefono;
                dtgCliente.Rows[indice].Cells[4].Value = cliente.email;
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            var cliente = cn.ObtenerClientesPorId(Convert.ToInt32(txtIdCliente.Text));
            txtNombre.Text = cliente.Nombre;
            txtCiudadR.Text = cliente.Ciudad_recidencia;
            txtTelefono.Text = cliente.telefono;
            txtEmail.Text = cliente.email;
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            int idCliente;
            string nombre = txtNombre.Text;
            string ciudadR = txtCiudadR.Text;
            string Telefono = txtTelefono.Text;
            string Email = txtEmail.Text;
            if (!int.TryParse(txtIdCliente.Text, out idCliente))
            {
                MessageBox.Show("Por favor, ingrese un ID de cliente válido.");
                return;
            }
            
            var clienteActual = cn.ObtenerClientesPorId(idCliente);
            if (clienteActual == null)
            {
                MessageBox.Show("No se encontró ningún cliente con ese ID.");
                return;
            }
            var clienteActualizado = new cCliente
            {
                Id = clienteActual.Id,
                IdCliente = idCliente,
                Nombre = nombre,
                Ciudad_recidencia = ciudadR,
                telefono = Telefono,
                email = Email
            };

            try
            {
                cn.ActualizarClientes(idCliente, clienteActualizado);
                MessageBox.Show("Empleado actualizado con éxito.");
            }
            catch (MongoWriteException ex)
            {
                MessageBox.Show($"Error al actualizar el Cliente: {ex.Message}");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idCliente;
            if (!int.TryParse(txtIdCliente.Text, out idCliente))
            {
                MessageBox.Show("Por favor, ingrese un ID de Cliente válido.");
                return;
            }

            try
            {
                var result = cn.EliminarCliente(idCliente);
                if (result.DeletedCount > 0)
                {
                    MessageBox.Show("Cliente eliminado con éxito.");
                }
                else
                {
                    MessageBox.Show("No se encontró ningún Cliente con ese ID.");
                }
            }
            catch (MongoWriteException ex)
            {
                MessageBox.Show($"Error al eliminar el cliente: {ex.Message}");
            }
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {

        }

        private void dtgCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
