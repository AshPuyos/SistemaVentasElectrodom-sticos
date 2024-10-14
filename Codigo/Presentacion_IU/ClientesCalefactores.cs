using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL;

namespace Presentacion_IU
{
    public partial class frmClientesCalefactores : Form
    {
        public frmClientesCalefactores()
        {
            InitializeComponent();
            oBLLCliente = new BLLCliente();
            oBLLGas = new BLLGas();
            oBLLElectrica = new BLLElectrica();
        }

        private void frmClientesCalefactores_Load(object sender, EventArgs e)
        {
            CargarComboClientes();
            CargarGrillaCalefactores();
        }

        BECliente oBECliente;
        BECalefactor oBECalefactor;
        BLLCliente oBLLCliente;
        BLLGas oBLLGas;
        BLLElectrica oBLLElectrica;

        void CargarComboClientes()
        {
            cbxCliente.DataSource = oBLLCliente.ListarTodo();
            cbxCliente.ValueMember = "Codigo";
            cbxCliente.DisplayMember = "Nombre";
            cbxCliente.SelectedIndexChanged += new EventHandler(cbxCliente_SelectedIndexChanged);
        }

        void CargarGrillaCalefactores()
        {
            List<BECalefactor> calefactores = new List<BECalefactor>();
            calefactores.AddRange(oBLLGas.ListarTodo());
            calefactores.AddRange(oBLLElectrica.ListarTodo());

            foreach (var calefactor in calefactores)
            {
                calefactor.Estado = "Libre";
            }

            dgvCalefactores.DataSource = calefactores;
            dgvCalefactores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCalefactores.Columns["oBEProveedor"].HeaderText = "Proveedor";
        }

        void CargarGrillaCalefactoresCliente(int clienteCodigo)
        {
            oBECliente = oBLLCliente.ListarTodo().Find(cli => cli.Codigo == clienteCodigo);
            dgvCalefactorxCliente.DataSource = oBECliente.ListaCalefactores;
            dgvCalefactorxCliente.AutoGenerateColumns = true;
            dgvCalefactorxCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Ocultar la columna del proveedor
            if (dgvCalefactorxCliente.Columns["oBEProveedor"] != null)
            {
                dgvCalefactorxCliente.Columns["oBEProveedor"].Visible = false;
            }

            if (dgvCalefactorxCliente.Columns["Cantidad"] != null)
            {
                dgvCalefactorxCliente.Columns["Cantidad"].Visible = false;
            }
        }

        private void cbxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCliente.SelectedItem != null)
            {
                BECliente clienteSeleccionado = (BECliente)cbxCliente.SelectedItem;
                CargarGrillaCalefactoresCliente(clienteSeleccionado.Codigo);
            }
        }

        private void btnAsociarCalefactor_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxCliente.SelectedItem != null && dgvCalefactores.CurrentRow != null)
                {
                    oBECliente = (BECliente)cbxCliente.SelectedItem;
                    oBECalefactor = (BECalefactor)dgvCalefactores.CurrentRow.DataBoundItem;

                    if (oBECalefactor.Cantidad > 0)
                    {
                        float precioConDescuento = oBECalefactor is BEGas ?
                            oBLLGas.DescuentoCalculado(oBECalefactor) :
                            oBLLElectrica.DescuentoCalculado(oBECalefactor);

                        oBECalefactor.PrecioConDescuento = precioConDescuento;
                        bool resultado = oBLLCliente.AgregarCalefactor(oBECliente, oBECalefactor);

                        if (resultado)
                        {
                            MessageBox.Show("Calefactor asociado correctamente. Precio con descuento: $" + precioConDescuento);
                            CargarGrillaCalefactoresCliente(oBECliente.Codigo);
                            CargarGrillaCalefactores();
                        }
                        else
                        {
                            MessageBox.Show("Error al asociar el calefactor.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay stock disponible para este calefactor.");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un cliente y un calefactor.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPagarCalefactor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCalefactorxCliente.CurrentRow != null)
                {
                    oBECalefactor = (BECalefactor)dgvCalefactorxCliente.CurrentRow.DataBoundItem;

                    if (oBECalefactor.Estado == "Asociado")
                    {
                        oBECalefactor.Estado = "Pagado";
                        oBLLCliente.ActualizarEstadoCalefactor(oBECliente.Codigo, oBECalefactor.Codigo, "Pagado");
                        MessageBox.Show("Calefactor pagado correctamente.");
                        CargarGrillaCalefactoresCliente(oBECliente.Codigo);
                    }
                    else
                    {
                        MessageBox.Show("El calefactor ya ha sido pagado.");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un calefactor asociado al cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDesasociar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCalefactorxCliente.CurrentRow != null)
                {
                    BECalefactor calefactorSeleccionado = (BECalefactor)dgvCalefactorxCliente.CurrentRow.DataBoundItem;
                    BECliente clienteSeleccionado = (BECliente)cbxCliente.SelectedItem;

                    bool resultado = oBLLCliente.DesasociarCalefactor(clienteSeleccionado.Codigo, calefactorSeleccionado.Codigo);

                    if (resultado)
                    {
                        MessageBox.Show("Calefactor desasociado correctamente.");
                        CargarGrillaCalefactoresCliente(clienteSeleccionado.Codigo);
                        CargarGrillaCalefactores();
                    }
                    else
                    {
                        MessageBox.Show("Error al desasociar el calefactor.");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un calefactor asociado al cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCalefactoresGasMasSolicitados_Click(object sender, EventArgs e)
        {
            List<BEGas> calefactores = oBLLGas.ObtenerCalefactoresGasMasSolicitados();
            dgvCalefactoresGasMasSolicitados.DataSource = calefactores;
            dgvCalefactoresGasMasSolicitados.Visible = true;

            foreach (DataGridViewColumn column in dgvCalefactoresGasMasSolicitados.Columns)
            {
                if (column.Name != "Nombre" && column.Name != "Codigo")
                {
                    column.Visible = false;
                }
            }
        }

        private void btnCalefactoresElectricosMenosSolicitados_Click(object sender, EventArgs e)
        {
            List<BEElectrica> calefactores = oBLLElectrica.ObtenerCalefactoresElectricosMenosSolicitados();
            dgvCalefactoresElectricosMenosSolicitados.DataSource = calefactores;
            dgvCalefactoresElectricosMenosSolicitados.Visible = true;

            
            foreach (DataGridViewColumn column in dgvCalefactoresElectricosMenosSolicitados.Columns)
            {
                if (column.Name != "Nombre" && column.Name != "Codigo")
                {
                    column.Visible = false;
                }
            }

            
            if (!dgvCalefactoresElectricosMenosSolicitados.Columns.Contains("Tipo"))
            {
                DataGridViewTextBoxColumn tipoColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Tipo",
                    HeaderText = "Tipo de Calefactor",
                    ReadOnly = true,
                    DataPropertyName = "Tipo"
                };
                dgvCalefactoresElectricosMenosSolicitados.Columns.Add(tipoColumn);

                
                foreach (DataGridViewRow row in dgvCalefactoresElectricosMenosSolicitados.Rows)
                {
                    row.Cells["Tipo"].Value = "Eléctrico";
                }
            }
        }

        private void btnMostrarDescuentos_Click(object sender, EventArgs e)
        {
            List<BECliente> clientes = oBLLCliente.ObtenerClientesConDescuentos();
            dgvDescuentosClientes.DataSource = clientes;
            dgvDescuentosClientes.Visible = true;

            
            foreach (DataGridViewColumn column in dgvDescuentosClientes.Columns)
            {
                if (column.Name != "Nombre" && column.Name != "Apellido" && column.Name != "TotalDescuento")
                {
                    column.Visible = false;
                }
            }
        }

        private void dgvCalefactoresElectricosMenosSolicitados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCalefactores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
