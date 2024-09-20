using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MongoDb_C_
{
    public partial class frmEmpleado : Form
    {
        cConexion cn = new cConexion();
        private IMongoCollection<cEmpleado> collection;
        public frmEmpleado()
        {
            InitializeComponent();
            var empleado = new MongoClient("mongodb://localhost:27017");
            var database = empleado.GetDatabase("ProyectoBDnoEstructuradas");
            collection = database.GetCollection<cEmpleado>("Empleados");
        }
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            cEmpleado nuevoEmpleado = new cEmpleado()
            {
                IdEmpleado = Convert.ToInt32(txtCedula.Text),
                Nombre = txtNombre.Text,
                Salario = Convert.ToInt32(txtSalario.Text)
            };

            cn.InsertarEmpleado(nuevoEmpleado);
        }
        private void txtListaEmpleados_Click(object sender, EventArgs e)
        {
            dtgEmpleado.Rows.Clear();
            int indice;
            var empleados = cn.ObtenerTodosLosEmpleados();
            foreach (var empleado in empleados)
            {
                indice = dtgEmpleado.Rows.Add(); // Agregar una nueva fila y obtener su índice
                dtgEmpleado.Rows[indice].Cells[0].Value = empleado.IdEmpleado;
                dtgEmpleado.Rows[indice].Cells[1].Value = empleado.Nombre;
                dtgEmpleado.Rows[indice].Cells[2].Value = empleado.Salario;
            }

        }
        private void btnConsulta_Click(object sender, EventArgs e)
        {
            var empleado = cn.ObtenerEmpleadoPorId(Convert.ToInt32(txtCedula.Text));
            txtNombre.Text = empleado.Nombre;
            txtSalario.Text = (empleado.Salario.ToString());
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            int idEmpleado;
            string nombre = txtNombre.Text;
            double salario;
            if (!int.TryParse(txtCedula.Text, out idEmpleado))
            {
                MessageBox.Show("Por favor, ingrese un ID de empleado válido.");
                return;
            }
            if (!double.TryParse(txtSalario.Text, out salario))
            {
                MessageBox.Show("Por favor, ingrese un salario válido.");
                return;
            }

            var empleadoActual = cn.ObtenerEmpleadoPorId(idEmpleado);
            if (empleadoActual == null)
            {
                MessageBox.Show("No se encontró ningún empleado con ese ID.");
                return;
            }
            var empleadoActualizado = new cEmpleado
            {
                Id = empleadoActual.Id, 
                IdEmpleado = idEmpleado,
                Nombre = nombre,
                Salario = salario
            };

            try
            {
                cn.ActualizarEmpleado(idEmpleado, empleadoActualizado);
                MessageBox.Show("Empleado actualizado con éxito.");
            }
            catch (MongoWriteException ex)
            {
                MessageBox.Show($"Error al actualizar el empleado: {ex.Message}");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEmpleado;
            if (!int.TryParse(txtCedula.Text, out idEmpleado))
            {
                MessageBox.Show("Por favor, ingrese un ID de empleado válido.");
                return;
            }

            try
            {
                var result = cn.EliminarEmpleado(idEmpleado);
                if (result.DeletedCount > 0)
                {
                    MessageBox.Show("Empleado eliminado con éxito.");
                }
                else
                {
                    MessageBox.Show("No se encontró ningún empleado con ese ID.");
                }
            }
            catch (MongoWriteException ex)
            {
                MessageBox.Show($"Error al eliminar el empleado: {ex.Message}");
            }
        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {

        }
    }
    
}
