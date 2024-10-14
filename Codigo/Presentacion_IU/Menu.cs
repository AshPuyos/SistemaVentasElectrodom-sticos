using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion_IU
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void generosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedores ofp = new frmProveedores();
            ofp.MdiParent = this;
            ofp.Show();
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmClientes ofc = new frmClientes();
            ofc.MdiParent = this;
            ofc.Show();
        }

        private void registrarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalefactores ofc = new frmCalefactores();
            ofc.MdiParent = this;
            ofc.Show();
        }

        private void registrarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientesCalefactores ofcc = new frmClientesCalefactores();
            ofcc.MdiParent = this;
            ofcc.Show();
        }
    }
}
