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
    public partial class frmConductor : Form
    {
        cConexion cn = new cConexion();
        private IMongoCollection<cConductor> collection2;
        public frmConductor()
        {
            InitializeComponent();
            var cliente = new MongoClient("mongodb://localhost:27017");
            var database = cliente.GetDatabase("ProyectoBDnoEstructuradas");
            collection2 = database.GetCollection<cConductor>("Conductor");
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            cConductor nuevoConductor = new cConductor()
            {
                IdConductor = Convert.ToInt32(txtIdConductor.Text),
                Nombre = txtNombre.Text,
                IdVehiculo = Convert.ToInt32(txtIdVehiculo.Text),
                telefono = txtTelefono.Text,
                EnviosEntregados = Convert.ToInt32(txtEnviosEntregados.Text),
            };
            cn.InsertarConductor(nuevoConductor);
        }

        private void btnListaEmpleados_Click(object sender, EventArgs e)
        {
            dtgConductor.Rows.Clear();
            int indice;
            var Conductores = cn.ObtenerTodosLosConductores();
            foreach (var conductor in Conductores)
            {
                indice = dtgConductor.Rows.Add(); // Agregar una nueva fila y obtener su índice
                dtgConductor.Rows[indice].Cells[0].Value = conductor.IdConductor;
                dtgConductor.Rows[indice].Cells[1].Value = conductor.Nombre;
                dtgConductor.Rows[indice].Cells[2].Value = conductor.telefono;
                dtgConductor.Rows[indice].Cells[3].Value = conductor.IdVehiculo;
                dtgConductor.Rows[indice].Cells[4].Value = conductor.EnviosEntregados;
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            var conductor = cn.ObtenerConductoresPorId(Convert.ToInt32(txtIdConductor.Text));
            txtNombre.Text = conductor.Nombre;
            txtTelefono.Text = conductor.telefono;
            txtIdVehiculo.Text = conductor.IdVehiculo.ToString();
            txtEnviosEntregados.Text = conductor.EnviosEntregados.ToString();
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            int idConductor;
            string nombre = txtNombre.Text;
            string Telefono = txtTelefono.Text;
            int idVehi;
            int EnviosE;
            if (!int.TryParse(txtIdConductor.Text, out idConductor))
            {
                MessageBox.Show("Por favor, ingrese un ID de Conductor válido.");
                return;
            }

            if (!int.TryParse(txtIdVehiculo.Text, out idVehi))
            {
                MessageBox.Show("Por favor, ingrese un ID de Vehiculo válido.");
                return;
            }

            if (!int.TryParse(txtEnviosEntregados.Text, out EnviosE))
            {
                MessageBox.Show("Por favor, ingrese una cantidad de envios entregados válida.");
                return;
            }

            var ConductorActual = cn.ObtenerConductoresPorId(idConductor);
            if (ConductorActual == null)
            {
                MessageBox.Show("No se encontró ningún conductor con ese ID.");
                return;
            }
            var conductorActualizado = new cConductor
            {
                Id = ConductorActual.Id,
                IdConductor = idConductor,
                Nombre = nombre,
                IdVehiculo = idVehi,
                telefono = Telefono,
                EnviosEntregados = EnviosE
            };

            try
            {
                cn.ActualizarConductor(idConductor, conductorActualizado);
                MessageBox.Show("Conductor actualizado con éxito.");
            }
            catch (MongoWriteException ex)
            {
                MessageBox.Show($"Error al actualizar el Conductor: {ex.Message}");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idConductor;
            if (!int.TryParse(txtIdConductor.Text, out idConductor))
            {
                MessageBox.Show("Por favor, ingrese un ID de Conductor válido.");
                return;
            }

            try
            {
                var result = cn.EliminarConductor(idConductor);
                if (result.DeletedCount > 0)
                {
                    MessageBox.Show("Conductor eliminado con éxito.");
                }
                else
                {
                    MessageBox.Show("No se encontró ningún conductor con ese ID.");
                }
            }
            catch (MongoWriteException ex)
            {
                MessageBox.Show($"Error al eliminar el conductor: {ex.Message}");
            }
        }
    }
}
