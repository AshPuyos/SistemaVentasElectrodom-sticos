using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion_IU
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
            oBLLCli = new BLLCliente();
            oBECli = new BECliente();
        }

        BECliente oBECli;
        BLLCliente oBLLCli;

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        void CargarGrilla()
        {
            this.dgvClientes.DataSource = null;
            this.dgvClientes.DataSource = oBLLCli.ListarTodo();
            this.dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            if (dgvClientes.Columns["TotalDescuento"] != null)
            {
                dgvClientes.Columns["TotalDescuento"].Visible = false;
            }
        }

        void Asignar()
        {
            try
            {
                oBECli.Codigo = string.IsNullOrEmpty(txtCodigo.Text) ? 0 : Convert.ToInt32(txtCodigo.Text);
                oBECli.Nombre = txtNombre.Text;
                oBECli.Apellido = txtApellido.Text;
                oBECli.Dni = Convert.ToInt32(txtDni.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Limpiar()
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDni.Text = string.Empty;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                Asignar();
                oBLLCli.Guardar(oBECli);
                CargarGrilla();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Asignar();
                oBLLCli.Guardar(oBECli);
                CargarGrilla();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Asignar();
                DialogResult Respuesta;
                Respuesta = MessageBox.Show("¿Confirma la eliminación del Cliente?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Respuesta == DialogResult.Yes)
                {
                    if (!oBLLCli.Baja(oBECli))
                    {
                        MessageBox.Show("Para dar de baja el Cliente no debe estar asociado a ningún Calefactor.");
                    }
                    else
                    {
                        CargarGrilla();
                        Limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            oBECli = (BECliente)this.dgvClientes.CurrentRow.DataBoundItem;
            txtCodigo.Text = oBECli.Codigo.ToString();
            txtNombre.Text = oBECli.Nombre;
            txtApellido.Text = oBECli.Apellido;
            txtDni.Text = oBECli.Dni.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
