namespace Presentacion_IU
{
    partial class frmClientesCalefactores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCalefactores = new System.Windows.Forms.DataGridView();
            this.dgvCalefactorxCliente = new System.Windows.Forms.DataGridView();
            this.btnAsociarCalefactor = new System.Windows.Forms.Button();
            this.btnPagarCalefactor = new System.Windows.Forms.Button();
            this.cbxCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCalefactores = new System.Windows.Forms.GroupBox();
            this.gbCalefactorCliente = new System.Windows.Forms.GroupBox();
            this.btnDesasociar = new System.Windows.Forms.Button();
            this.btnCalefactoresGasMasSolicitados = new System.Windows.Forms.Button();
            this.dgvCalefactoresGasMasSolicitados = new System.Windows.Forms.DataGridView();
            this.btnCalefactoresElectricosMenosSolicitados = new System.Windows.Forms.Button();
            this.dgvCalefactoresElectricosMenosSolicitados = new System.Windows.Forms.DataGridView();
            this.btnMostrarDescuentos = new System.Windows.Forms.Button();
            this.dgvDescuentosClientes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalefactores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalefactorxCliente)).BeginInit();
            this.gbCalefactores.SuspendLayout();
            this.gbCalefactorCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalefactoresGasMasSolicitados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalefactoresElectricosMenosSolicitados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentosClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCalefactores
            // 
            this.dgvCalefactores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalefactores.Location = new System.Drawing.Point(22, 34);
            this.dgvCalefactores.Name = "dgvCalefactores";
            this.dgvCalefactores.Size = new System.Drawing.Size(698, 265);
            this.dgvCalefactores.TabIndex = 1;
            this.dgvCalefactores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCalefactores_CellContentClick);
            // 
            // dgvCalefactorxCliente
            // 
            this.dgvCalefactorxCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalefactorxCliente.Location = new System.Drawing.Point(18, 29);
            this.dgvCalefactorxCliente.Name = "dgvCalefactorxCliente";
            this.dgvCalefactorxCliente.Size = new System.Drawing.Size(635, 175);
            this.dgvCalefactorxCliente.TabIndex = 2;
            // 
            // btnAsociarCalefactor
            // 
            this.btnAsociarCalefactor.Location = new System.Drawing.Point(669, 76);
            this.btnAsociarCalefactor.Name = "btnAsociarCalefactor";
            this.btnAsociarCalefactor.Size = new System.Drawing.Size(85, 50);
            this.btnAsociarCalefactor.TabIndex = 6;
            this.btnAsociarCalefactor.Text = "Asociar Calefactor";
            this.btnAsociarCalefactor.UseVisualStyleBackColor = true;
            this.btnAsociarCalefactor.Click += new System.EventHandler(this.btnAsociarCalefactor_Click);
            // 
            // btnPagarCalefactor
            // 
            this.btnPagarCalefactor.Location = new System.Drawing.Point(869, 76);
            this.btnPagarCalefactor.Name = "btnPagarCalefactor";
            this.btnPagarCalefactor.Size = new System.Drawing.Size(85, 50);
            this.btnPagarCalefactor.TabIndex = 7;
            this.btnPagarCalefactor.Text = "Pagar Calefactor";
            this.btnPagarCalefactor.UseVisualStyleBackColor = true;
            this.btnPagarCalefactor.Click += new System.EventHandler(this.btnPagarCalefactor_Click);
            // 
            // cbxCliente
            // 
            this.cbxCliente.FormattingEnabled = true;
            this.cbxCliente.Location = new System.Drawing.Point(726, 40);
            this.cbxCliente.Name = "cbxCliente";
            this.cbxCliente.Size = new System.Drawing.Size(199, 21);
            this.cbxCliente.TabIndex = 8;
            this.cbxCliente.SelectedIndexChanged += new System.EventHandler(this.cbxCliente_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(681, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Cliente";
            // 
            // gbCalefactores
            // 
            this.gbCalefactores.Controls.Add(this.dgvCalefactoresElectricosMenosSolicitados);
            this.gbCalefactores.Controls.Add(this.btnCalefactoresElectricosMenosSolicitados);
            this.gbCalefactores.Controls.Add(this.dgvCalefactoresGasMasSolicitados);
            this.gbCalefactores.Controls.Add(this.btnCalefactoresGasMasSolicitados);
            this.gbCalefactores.Controls.Add(this.dgvCalefactores);
            this.gbCalefactores.Location = new System.Drawing.Point(12, 21);
            this.gbCalefactores.Name = "gbCalefactores";
            this.gbCalefactores.Size = new System.Drawing.Size(1349, 326);
            this.gbCalefactores.TabIndex = 10;
            this.gbCalefactores.TabStop = false;
            this.gbCalefactores.Text = "Calefactores";
            // 
            // gbCalefactorCliente
            // 
            this.gbCalefactorCliente.Controls.Add(this.dgvDescuentosClientes);
            this.gbCalefactorCliente.Controls.Add(this.btnMostrarDescuentos);
            this.gbCalefactorCliente.Controls.Add(this.btnDesasociar);
            this.gbCalefactorCliente.Controls.Add(this.btnAsociarCalefactor);
            this.gbCalefactorCliente.Controls.Add(this.dgvCalefactorxCliente);
            this.gbCalefactorCliente.Controls.Add(this.btnPagarCalefactor);
            this.gbCalefactorCliente.Controls.Add(this.label1);
            this.gbCalefactorCliente.Controls.Add(this.cbxCliente);
            this.gbCalefactorCliente.Location = new System.Drawing.Point(12, 412);
            this.gbCalefactorCliente.Name = "gbCalefactorCliente";
            this.gbCalefactorCliente.Size = new System.Drawing.Size(1349, 228);
            this.gbCalefactorCliente.TabIndex = 11;
            this.gbCalefactorCliente.TabStop = false;
            this.gbCalefactorCliente.Text = "Calefactores por Cliente";
            // 
            // btnDesasociar
            // 
            this.btnDesasociar.Location = new System.Drawing.Point(770, 76);
            this.btnDesasociar.Name = "btnDesasociar";
            this.btnDesasociar.Size = new System.Drawing.Size(85, 50);
            this.btnDesasociar.TabIndex = 10;
            this.btnDesasociar.Text = "Desasociar Calefactor";
            this.btnDesasociar.UseVisualStyleBackColor = true;
            this.btnDesasociar.Click += new System.EventHandler(this.btnDesasociar_Click);
            // 
            // btnCalefactoresGasMasSolicitados
            // 
            this.btnCalefactoresGasMasSolicitados.Location = new System.Drawing.Point(738, 58);
            this.btnCalefactoresGasMasSolicitados.Name = "btnCalefactoresGasMasSolicitados";
            this.btnCalefactoresGasMasSolicitados.Size = new System.Drawing.Size(216, 50);
            this.btnCalefactoresGasMasSolicitados.TabIndex = 11;
            this.btnCalefactoresGasMasSolicitados.Text = "Mostrar Calefactores a Gas más Solicitados";
            this.btnCalefactoresGasMasSolicitados.UseVisualStyleBackColor = true;
            this.btnCalefactoresGasMasSolicitados.Click += new System.EventHandler(this.btnCalefactoresGasMasSolicitados_Click);
            // 
            // dgvCalefactoresGasMasSolicitados
            // 
            this.dgvCalefactoresGasMasSolicitados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalefactoresGasMasSolicitados.Location = new System.Drawing.Point(970, 19);
            this.dgvCalefactoresGasMasSolicitados.Name = "dgvCalefactoresGasMasSolicitados";
            this.dgvCalefactoresGasMasSolicitados.Size = new System.Drawing.Size(354, 140);
            this.dgvCalefactoresGasMasSolicitados.TabIndex = 12;
            // 
            // btnCalefactoresElectricosMenosSolicitados
            // 
            this.btnCalefactoresElectricosMenosSolicitados.Location = new System.Drawing.Point(738, 205);
            this.btnCalefactoresElectricosMenosSolicitados.Name = "btnCalefactoresElectricosMenosSolicitados";
            this.btnCalefactoresElectricosMenosSolicitados.Size = new System.Drawing.Size(216, 50);
            this.btnCalefactoresElectricosMenosSolicitados.TabIndex = 13;
            this.btnCalefactoresElectricosMenosSolicitados.Text = "Mostrar Calefactores Eléctricos menos Solicitados";
            this.btnCalefactoresElectricosMenosSolicitados.UseVisualStyleBackColor = true;
            this.btnCalefactoresElectricosMenosSolicitados.Click += new System.EventHandler(this.btnCalefactoresElectricosMenosSolicitados_Click);
            // 
            // dgvCalefactoresElectricosMenosSolicitados
            // 
            this.dgvCalefactoresElectricosMenosSolicitados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalefactoresElectricosMenosSolicitados.Location = new System.Drawing.Point(970, 165);
            this.dgvCalefactoresElectricosMenosSolicitados.Name = "dgvCalefactoresElectricosMenosSolicitados";
            this.dgvCalefactoresElectricosMenosSolicitados.Size = new System.Drawing.Size(354, 140);
            this.dgvCalefactoresElectricosMenosSolicitados.TabIndex = 14;
            this.dgvCalefactoresElectricosMenosSolicitados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCalefactoresElectricosMenosSolicitados_CellContentClick);
            // 
            // btnMostrarDescuentos
            // 
            this.btnMostrarDescuentos.Location = new System.Drawing.Point(669, 143);
            this.btnMostrarDescuentos.Name = "btnMostrarDescuentos";
            this.btnMostrarDescuentos.Size = new System.Drawing.Size(285, 50);
            this.btnMostrarDescuentos.TabIndex = 15;
            this.btnMostrarDescuentos.Text = "Mostrar los Descuentos de los Clientes";
            this.btnMostrarDescuentos.UseVisualStyleBackColor = true;
            this.btnMostrarDescuentos.Click += new System.EventHandler(this.btnMostrarDescuentos_Click);
            // 
            // dgvDescuentosClientes
            // 
            this.dgvDescuentosClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDescuentosClientes.Location = new System.Drawing.Point(970, 40);
            this.dgvDescuentosClientes.Name = "dgvDescuentosClientes";
            this.dgvDescuentosClientes.Size = new System.Drawing.Size(354, 153);
            this.dgvDescuentosClientes.TabIndex = 15;
            // 
            // frmClientesCalefactores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 652);
            this.Controls.Add(this.gbCalefactorCliente);
            this.Controls.Add(this.gbCalefactores);
            this.Name = "frmClientesCalefactores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Ventas";
            this.Load += new System.EventHandler(this.frmClientesCalefactores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalefactores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalefactorxCliente)).EndInit();
            this.gbCalefactores.ResumeLayout(false);
            this.gbCalefactorCliente.ResumeLayout(false);
            this.gbCalefactorCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalefactoresGasMasSolicitados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalefactoresElectricosMenosSolicitados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentosClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCalefactores;
        private System.Windows.Forms.DataGridView dgvCalefactorxCliente;
        private System.Windows.Forms.Button btnAsociarCalefactor;
        private System.Windows.Forms.Button btnPagarCalefactor;
        private System.Windows.Forms.ComboBox cbxCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbCalefactores;
        private System.Windows.Forms.GroupBox gbCalefactorCliente;
        private System.Windows.Forms.Button btnDesasociar;
        private System.Windows.Forms.Button btnCalefactoresGasMasSolicitados;
        private System.Windows.Forms.DataGridView dgvCalefactoresGasMasSolicitados;
        private System.Windows.Forms.DataGridView dgvCalefactoresElectricosMenosSolicitados;
        private System.Windows.Forms.Button btnCalefactoresElectricosMenosSolicitados;
        private System.Windows.Forms.DataGridView dgvDescuentosClientes;
        private System.Windows.Forms.Button btnMostrarDescuentos;
    }
}
