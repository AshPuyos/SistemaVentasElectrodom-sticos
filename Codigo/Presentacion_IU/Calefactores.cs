using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using BLL;

namespace Presentacion_IU
{
    public partial class frmCalefactores : Form
    {
        public frmCalefactores()
        {
            InitializeComponent();
            oBLLGas = new BLLGas();
            oBLLEle = new BLLElectrica();
            oBLLPro = new BLLProveedor();
            cmbElectricaGas.SelectedIndexChanged += new System.EventHandler(this.cmbElectricaGas_SelectedIndexChanged);
        }

        BLLElectrica oBLLEle;
        BLLGas oBLLGas;
        BLLProveedor oBLLPro;
        BECalefactor oBECal;

        private void frmCalefactores_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            CargarComboProveedor();
            CargarComboTipoCalefactor();
        }

        void CargarComboProveedor()
        {
            cmbProveedor.DataSource = oBLLPro.ListarTodo();
            cmbProveedor.ValueMember = "Codigo";
            cmbProveedor.DisplayMember = "RazonSocial";
        }

        void CargarComboTipoCalefactor()
        {
            cmbElectricaGas.Items.Clear();
            cmbElectricaGas.Items.Add("Gas");
            cmbElectricaGas.Items.Add("Eléctrico");
            cmbElectricaGas.SelectedIndex = 0;
        }

        private void cmbElectricaGas_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isElectric = cmbElectricaGas.SelectedItem.ToString() == "Eléctrico";
            label9.Visible = isElectric;
            txtEficiencia.Visible = isElectric;
            cboxTiroBalanceado.Visible = !isElectric;
        }

        void CargarGrilla()
        {
            List<BECalefactor> calefactores = new List<BECalefactor>();
            calefactores.AddRange(oBLLGas.ListarTodo());
            calefactores.AddRange(oBLLEle.ListarTodo());

            dgvCalefactores.DataSource = calefactores;
            dgvCalefactores.AutoGenerateColumns = true;
            dgvCalefactores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Configurar la columna PrecioConDescuento
            if (dgvCalefactores.Columns["PrecioConDescuento"] == null)
            {
                DataGridViewTextBoxColumn descuentoColumna = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Precio con Descuento",
                    Name = "PrecioConDescuento",
                    DataPropertyName = "PrecioConDescuento"
                };
                dgvCalefactores.Columns.Add(descuentoColumna);
            }

            if (dgvCalefactores.Columns["TipoCalefactor"] == null)
            {
                DataGridViewTextBoxColumn tipoCalefactorColumna = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Tipo Calefactor",
                    Name = "TipoCalefactor",
                    DataPropertyName = "TipoCalefactor"
                };
                dgvCalefactores.Columns.Add(tipoCalefactorColumna);
            }

            this.dgvCalefactores.Columns["oBEProveedor"].HeaderText = "Proveedor";
            dgvCalefactores.CellFormatting += dgvCalefactores_CellFormatting;
        }

        private void dgvCalefactores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCalefactores.Columns[e.ColumnIndex].Name == "TipoCalefactor")
            {
                var calefactor = dgvCalefactores.Rows[e.RowIndex].DataBoundItem as BECalefactor;
                if (calefactor != null)
                {
                    if (calefactor is BEGas)
                    {
                        e.Value = "Gas";
                    }
                    else if (calefactor is BEElectrica)
                    {
                        e.Value = "Eléctrico";
                    }
                }
            }
        }

        private void dgvCalefactores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCalefactores.CurrentRow.DataBoundItem is BEElectrica)
            {
                CargarDatosCalefactor(dgvCalefactores.CurrentRow.DataBoundItem as BEElectrica);
            }
            else if (dgvCalefactores.CurrentRow.DataBoundItem is BEGas)
            {
                CargarDatosCalefactor(dgvCalefactores.CurrentRow.DataBoundItem as BEGas);
            }
        }

        private void CargarDatosCalefactor(BEElectrica electrica)
        {
            txtCodigo.Text = electrica.Codigo.ToString();
            txtNombre.Text = electrica.Nombre;
            txtCalorias.Text = electrica.Calorias.ToString();
            txtModelo.Text = electrica.Modelo;
            txtCantidad.Text = electrica.Cantidad.ToString();
            txtEstado.Text = electrica.Estado;
            txtPrecio.Text = electrica.Precio.ToString();
            cmbProveedor.SelectedValue = electrica.oBEProveedor.Codigo;
            cmbElectricaGas.SelectedItem = "Eléctrico";
            txtEficiencia.Text = electrica.Eficiencia;
            label9.Visible = true;
            txtEficiencia.Visible = true;
            cboxTiroBalanceado.Visible = false;
        }

        private void CargarDatosCalefactor(BEGas gas)
        {
            txtCodigo.Text = gas.Codigo.ToString();
            txtNombre.Text = gas.Nombre;
            txtCalorias.Text = gas.Calorias.ToString();
            txtModelo.Text = gas.Modelo;
            txtCantidad.Text = gas.Cantidad.ToString();
            txtEstado.Text = gas.Estado;
            txtPrecio.Text = gas.Precio.ToString();
            cmbProveedor.SelectedValue = gas.oBEProveedor.Codigo;
            cmbElectricaGas.SelectedItem = "Gas";
            cboxTiroBalanceado.Checked = gas.TiroBalanceado;
            label9.Visible = false;
            txtEficiencia.Visible = false;
            cboxTiroBalanceado.Visible = true;
        }

        void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtCalorias.Text = "";
            txtModelo.Text = "";
            txtCantidad.Text = "";
            txtEstado.Text = "";
            txtPrecio.Text = "";
            txtEficiencia.Text = "";
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbElectricaGas.SelectedItem.ToString() == "Gas")
                {
                    oBECal = new BEGas
                    {
                        TiroBalanceado = cboxTiroBalanceado.Checked
                    };
                }
                else if (cmbElectricaGas.SelectedItem.ToString() == "Eléctrico")
                {
                    oBECal = new BEElectrica
                    {
                        Eficiencia = txtEficiencia.Text
                    };
                }

                SetCalefactorCommonFields(oBECal);

                if (oBECal is BEGas gas)
                {
                    oBLLGas.Guardar(gas);
                }
                else if (oBECal is BEElectrica electrica)
                {
                    oBLLEle.Guardar(electrica);
                }

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
                BECalefactor calefactorOriginal = (BECalefactor)dgvCalefactores.CurrentRow.DataBoundItem;
                BECalefactor calefactorModificado;

                if (cmbElectricaGas.SelectedItem.ToString() == "Eléctrico")
                {
                    if (calefactorOriginal is BEGas)
                    {
                        oBLLGas.Baja((BEGas)calefactorOriginal);
                        calefactorModificado = new BEElectrica();
                    }
                    else
                    {
                        calefactorModificado = calefactorOriginal;
                    }
                    ((BEElectrica)calefactorModificado).Eficiencia = txtEficiencia.Text;
                }
                else if (cmbElectricaGas.SelectedItem.ToString() == "Gas")
                {
                    if (calefactorOriginal is BEElectrica)
                    {
                        oBLLEle.Baja((BEElectrica)calefactorOriginal);
                        calefactorModificado = new BEGas();
                    }
                    else
                    {
                        calefactorModificado = calefactorOriginal;
                    }
                    ((BEGas)calefactorModificado).TiroBalanceado = cboxTiroBalanceado.Checked;
                }
                else
                {
                    MessageBox.Show("Seleccione un tipo válido de calefactor.");
                    return;
                }

                SetCalefactorCommonFields(calefactorModificado);

                if (calefactorModificado is BEElectrica electrica)
                {
                    oBLLEle.Guardar(electrica);
                }
                else if (calefactorModificado is BEGas gas)
                {
                    oBLLGas.Guardar(gas);
                }

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
                if (dgvCalefactores.CurrentRow.DataBoundItem is BEElectrica electrica)
                {
                    oBLLEle.Baja(electrica);
                }
                else if (dgvCalefactores.CurrentRow.DataBoundItem is BEGas gas)
                {
                    oBLLGas.Baja(gas);
                }

                CargarGrilla();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void SetCalefactorCommonFields(BECalefactor calefactor)
        {
            calefactor.Nombre = txtNombre.Text;
            calefactor.Calorias = Convert.ToInt32(txtCalorias.Text);
            calefactor.Modelo = txtModelo.Text;
            calefactor.Cantidad = Convert.ToInt32(txtCantidad.Text);
            calefactor.Estado = txtEstado.Text;
            calefactor.Precio = Convert.ToInt32(txtPrecio.Text);
            calefactor.oBEProveedor = (BEProveedor)cmbProveedor.SelectedItem;
        }
    }
}
