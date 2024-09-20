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
    public partial class frmCiudad : Form
    {
        cConexion cn = new cConexion();
        private IMongoCollection<cCiudad> collection3;
        public frmCiudad()
        {
            InitializeComponent();
            var cliente = new MongoClient("mongodb://localhost:27017");
            var database = cliente.GetDatabase("ProyectoBDnoEstructuradas");
            collection3 = database.GetCollection<cCiudad>("Ciudades");
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            cCiudad nuevaCiudad = new cCiudad()
            {
                Nombre = txtNombre.Text,
                estado = txtEstado.Text,
            };

            cn.InsertarCiudad(nuevaCiudad);
        }

        private void btnListaEmpleados_Click(object sender, EventArgs e)
        {
            dtgCiudades.Rows.Clear();
            int indice;
            var Ciudades = cn.ObtenerTodosLasCiudades();
            foreach (var ciudad in Ciudades)
            {
                indice = dtgCiudades.Rows.Add(); // Agregar una nueva fila y obtener su índice
                dtgCiudades.Rows[indice].Cells[0].Value = ciudad.Nombre;
                dtgCiudades.Rows[indice].Cells[1].Value = ciudad.estado;
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            var ciudad = cn.ObtenerCiudadesPorId(txtNombre.Text);
            txtNombre.Text = ciudad.Nombre;
            txtEstado.Text = ciudad.estado;
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string Estado = txtEstado.Text;
            

            var ciudadActual = cn.ObtenerCiudadesPorId(nombre);
            if (ciudadActual == null)
            {
                MessageBox.Show("No se encontró ninguna ciudad con ese nombre.");
                return;
            }
            var ciudadActualizado = new cCiudad
            {
                Id = ciudadActual.Id,
                Nombre = nombre,
                estado = Estado
            };

            try
            {
                cn.ActualizarCiudad(nombre, ciudadActualizado);
                MessageBox.Show("ciudad actualizada con éxito.");
            }
            catch (MongoWriteException ex)
            {
                MessageBox.Show($"Error al actualizar la ciudad : {ex.Message}");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;

            try
            {
                var result = cn.EliminarCiudad(Nombre);
                if (result.DeletedCount > 0)
                {
                    MessageBox.Show("Ciudad eliminada con éxito.");
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna ciudad con ese nombre.");
                }
            }
            catch (MongoWriteException ex)
            {
                MessageBox.Show($"Error al eliminar la ciudad : {ex.Message}");
            }
        }
    }
}
