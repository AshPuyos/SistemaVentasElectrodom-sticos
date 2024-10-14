using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BE;
using BLL;

namespace Presentacion_IU
{
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
            oBLLPro = new BLLProveedor();
            oBEPro = new BEProveedor();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        BLLProveedor oBLLPro;
        BEProveedor oBEPro;

        void CargarGrilla()
        {
            this.dgvProveedores.DataSource = null;
            this.dgvProveedores.DataSource = oBLLPro.ListarTodo();
            this.dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                oBEPro = new BEProveedor
                {
                    RazonSocial = txtRazonSocial.Text,
                    Cuit = Convert.ToInt32(txtCuit.Text)
                };

                oBLLPro.Guardar(oBEPro);
                CargarGrilla();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Asignar()
        {
            oBEPro.Codigo = Convert.ToInt32(txtCodigo.Text);
            oBEPro.RazonSocial = txtRazonSocial.Text;
            oBEPro.Cuit = Convert.ToInt32(txtCuit.Text);
        }

        void Limpiar()
        {
            txtCodigo.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtCuit.Text = string.Empty;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Asignar();
            DialogResult Respuesta;
            Respuesta = MessageBox.Show("¿Confirma la eliminación del Proveedor?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Respuesta == DialogResult.Yes)
            {
                if (oBLLPro.Baja(oBEPro) == false)
                {
                    MessageBox.Show("Para dar de baja el Proveedor no debe estar asociado a ningún Calefactor asociado");
                }
                else
                {
                    CargarGrilla();
                    Limpiar();
                }
            }
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            oBEPro = (BEProveedor)this.dgvProveedores.CurrentRow.DataBoundItem;
            txtCodigo.Text = oBEPro.Codigo.ToString();
            txtRazonSocial.Text = oBEPro.RazonSocial;
            txtCuit.Text = oBEPro.Cuit.ToString();
        }
    }
}
