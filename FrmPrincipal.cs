using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoDb_C_
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmEmpleado Empleado = new frmEmpleado();
            Empleado.TopLevel = false;
            Empleado.FormBorderStyle = FormBorderStyle.None;
            Empleado.Dock = DockStyle.Fill;
            panel1.Controls.Add(Empleado);
            panel1.Tag = Empleado;
            Empleado.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmCliente cliente = new frmCliente();
            cliente.TopLevel = false;
            cliente.FormBorderStyle = FormBorderStyle.None;
            cliente.Dock = DockStyle.Fill;
            panel1.Controls.Add(cliente);
            panel1.Tag = cliente;
            cliente.Show();
        }

        private void ciudadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmCiudad ciudad = new frmCiudad();
            ciudad.TopLevel = false;
            ciudad.FormBorderStyle = FormBorderStyle.None;
            ciudad.Dock = DockStyle.Fill;
            panel1.Controls.Add(ciudad);
            panel1.Tag = ciudad;
            ciudad.Show();
        }

        private void conductorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmConductor Conductor = new frmConductor();
            Conductor.TopLevel = false;
            Conductor.FormBorderStyle = FormBorderStyle.None;
            Conductor.Dock = DockStyle.Fill;
            panel1.Controls.Add(Conductor);
            panel1.Tag = Conductor;
            Conductor.Show();
        }

        private void entregaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmCliente cliente = new frmCliente();
            cliente.TopLevel = false;
            cliente.FormBorderStyle = FormBorderStyle.None;
            cliente.Dock = DockStyle.Fill;
            panel1.Controls.Add(cliente);
            panel1.Tag = cliente;
            cliente.Show();
        }

        private void pedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmCliente cliente = new frmCliente();
            cliente.TopLevel = false;
            cliente.FormBorderStyle = FormBorderStyle.None;
            cliente.Dock = DockStyle.Fill;
            panel1.Controls.Add(cliente);
            panel1.Tag = cliente;
            cliente.Show();
        }

        private void rutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmCliente cliente = new frmCliente();
            cliente.TopLevel = false;
            cliente.FormBorderStyle = FormBorderStyle.None;
            cliente.Dock = DockStyle.Fill;
            panel1.Controls.Add(cliente);
            panel1.Tag = cliente;
            cliente.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void vehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmCliente cliente = new frmCliente();
            cliente.TopLevel = false;
            cliente.FormBorderStyle = FormBorderStyle.None;
            cliente.Dock = DockStyle.Fill;
            panel1.Controls.Add(cliente);
            panel1.Tag = cliente;
            cliente.Show();
        }
    }
}
