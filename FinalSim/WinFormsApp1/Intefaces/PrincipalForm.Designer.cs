namespace WinFormsApp1
{
    partial class PrincipalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            superiorPanel = new Panel();
            panel6 = new Panel();
            btnMinimize = new Button();
            btnMaximize = new Button();
            btnClose = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            panel1 = new Panel();
            pnlConsumicion = new Panel();
            txtDesviacion = new TextBox();
            label6 = new Label();
            label4 = new Label();
            txtMediaConsumicion = new TextBox();
            label5 = new Label();
            pnlMozo = new Panel();
            txtEntregaPedido = new TextBox();
            label7 = new Label();
            label8 = new Label();
            txtTomaPedido = new TextBox();
            label9 = new Label();
            pnlPedido = new Panel();
            label15 = new Label();
            txtProbabilidadM2 = new TextBox();
            label14 = new Label();
            txtProbabilidadM1 = new TextBox();
            label13 = new Label();
            txtPreparacionM2 = new TextBox();
            label10 = new Label();
            label11 = new Label();
            txtPreparacionM1 = new TextBox();
            label12 = new Label();
            panel5 = new Panel();
            pnResultados = new Panel();
            pnlParametros = new TableLayoutPanel();
            pnlClientes = new Panel();
            label19 = new Label();
            txtLlegadaClientes = new TextBox();
            txtDesde = new TextBox();
            label21 = new Label();
            label17 = new Label();
            label16 = new Label();
            txtCantIteraciones = new TextBox();
            btnGenerateSimulation = new Button();
            superiorPanel.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            pnlConsumicion.SuspendLayout();
            pnlMozo.SuspendLayout();
            pnlPedido.SuspendLayout();
            panel5.SuspendLayout();
            pnlParametros.SuspendLayout();
            pnlClientes.SuspendLayout();
            SuspendLayout();
            // 
            // superiorPanel
            // 
            superiorPanel.BackColor = Color.FromArgb(95, 43, 79);
            superiorPanel.Controls.Add(panel6);
            superiorPanel.Controls.Add(pictureBox1);
            superiorPanel.Controls.Add(label1);
            superiorPanel.Dock = DockStyle.Top;
            superiorPanel.Location = new Point(0, 0);
            superiorPanel.Name = "superiorPanel";
            superiorPanel.Size = new Size(1533, 56);
            superiorPanel.TabIndex = 0;
            superiorPanel.Paint += superiorPanel_Paint;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel6.Controls.Add(btnMinimize);
            panel6.Controls.Add(btnMaximize);
            panel6.Controls.Add(btnClose);
            panel6.Location = new Point(1387, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(143, 49);
            panel6.TabIndex = 5;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.None;
            btnMinimize.BackColor = Color.FromArgb(241, 196, 15);
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Location = new Point(3, 8);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(40, 34);
            btnMinimize.TabIndex = 1;
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnMaximize
            // 
            btnMaximize.Anchor = AnchorStyles.None;
            btnMaximize.BackColor = Color.FromArgb(46, 204, 113);
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.Location = new Point(49, 8);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new Size(38, 34);
            btnMaximize.TabIndex = 2;
            btnMaximize.UseVisualStyleBackColor = false;
            btnMaximize.Click += btnMaximize_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.None;
            btnClose.BackColor = Color.FromArgb(231, 76, 60);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(93, 8);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(38, 34);
            btnClose.TabIndex = 3;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = FinalSim.Properties.Resources.png_winform;
            pictureBox1.Location = new Point(0, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 44);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("PP Radio Grotesk Black", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(633, 13);
            label1.Name = "label1";
            label1.Size = new Size(219, 33);
            label1.TabIndex = 0;
            label1.Text = "Final Simulacion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("PP Radio Grotesk Black", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(224, 224, 224);
            label2.Location = new Point(18, 14);
            label2.Name = "label2";
            label2.Size = new Size(118, 33);
            label2.TabIndex = 1;
            label2.Text = "Clientes";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("PP Radio Grotesk", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(18, 58);
            label3.Name = "label3";
            label3.Size = new Size(276, 28);
            label3.TabIndex = 2;
            label3.Text = "Tiempo llegada de clientes";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(312, 61);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(1591, 204);
            panel1.Name = "panel1";
            panel1.Size = new Size(458, 119);
            panel1.TabIndex = 4;
            // 
            // pnlConsumicion
            // 
            pnlConsumicion.BorderStyle = BorderStyle.Fixed3D;
            pnlConsumicion.Controls.Add(txtDesviacion);
            pnlConsumicion.Controls.Add(label6);
            pnlConsumicion.Controls.Add(label4);
            pnlConsumicion.Controls.Add(txtMediaConsumicion);
            pnlConsumicion.Controls.Add(label5);
            pnlConsumicion.Dock = DockStyle.Fill;
            pnlConsumicion.Location = new Point(3, 193);
            pnlConsumicion.Name = "pnlConsumicion";
            pnlConsumicion.Size = new Size(495, 173);
            pnlConsumicion.TabIndex = 5;
            // 
            // txtDesviacion
            // 
            txtDesviacion.Anchor = AnchorStyles.None;
            txtDesviacion.Location = new Point(353, 117);
            txtDesviacion.Name = "txtDesviacion";
            txtDesviacion.Size = new Size(125, 27);
            txtDesviacion.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("PP Radio Grotesk", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.Silver;
            label6.Location = new Point(18, 114);
            label6.Name = "label6";
            label6.Size = new Size(327, 28);
            label6.TabIndex = 4;
            label6.Text = "Desviacion consumicion pedido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("PP Radio Grotesk Black", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(224, 224, 224);
            label4.Location = new Point(18, 26);
            label4.Name = "label4";
            label4.Size = new Size(274, 33);
            label4.TabIndex = 1;
            label4.Text = "Consumicion Pedido";
            // 
            // txtMediaConsumicion
            // 
            txtMediaConsumicion.Anchor = AnchorStyles.None;
            txtMediaConsumicion.Location = new Point(353, 73);
            txtMediaConsumicion.Name = "txtMediaConsumicion";
            txtMediaConsumicion.Size = new Size(125, 27);
            txtMediaConsumicion.TabIndex = 3;
            txtMediaConsumicion.KeyPress += txtMediaConsumicion_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("PP Radio Grotesk", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Silver;
            label5.Location = new Point(18, 73);
            label5.Name = "label5";
            label5.Size = new Size(280, 28);
            label5.TabIndex = 2;
            label5.Text = "Media consumicion pedido";
            // 
            // pnlMozo
            // 
            pnlMozo.BorderStyle = BorderStyle.Fixed3D;
            pnlMozo.Controls.Add(txtEntregaPedido);
            pnlMozo.Controls.Add(label7);
            pnlMozo.Controls.Add(label8);
            pnlMozo.Controls.Add(txtTomaPedido);
            pnlMozo.Controls.Add(label9);
            pnlMozo.Dock = DockStyle.Fill;
            pnlMozo.Location = new Point(3, 3);
            pnlMozo.Name = "pnlMozo";
            pnlMozo.Size = new Size(495, 184);
            pnlMozo.TabIndex = 6;
            // 
            // txtEntregaPedido
            // 
            txtEntregaPedido.Anchor = AnchorStyles.None;
            txtEntregaPedido.Location = new Point(353, 105);
            txtEntregaPedido.Name = "txtEntregaPedido";
            txtEntregaPedido.Size = new Size(125, 27);
            txtEntregaPedido.TabIndex = 5;
            txtEntregaPedido.KeyPress += txtEntregaPedido_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("PP Radio Grotesk", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.Silver;
            label7.Location = new Point(18, 102);
            label7.Name = "label7";
            label7.Size = new Size(242, 28);
            label7.TabIndex = 4;
            label7.Text = "Tiempo entrega pedido";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("PP Radio Grotesk Black", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.FromArgb(224, 224, 224);
            label8.Location = new Point(18, 14);
            label8.Name = "label8";
            label8.Size = new Size(84, 33);
            label8.TabIndex = 1;
            label8.Text = "Mozo";
            // 
            // txtTomaPedido
            // 
            txtTomaPedido.Anchor = AnchorStyles.None;
            txtTomaPedido.Location = new Point(353, 61);
            txtTomaPedido.Name = "txtTomaPedido";
            txtTomaPedido.Size = new Size(125, 27);
            txtTomaPedido.TabIndex = 3;
            txtTomaPedido.KeyPress += txtTomaPedido_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("PP Radio Grotesk", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.Silver;
            label9.Location = new Point(18, 61);
            label9.Name = "label9";
            label9.Size = new Size(216, 28);
            label9.TabIndex = 2;
            label9.Text = "Tiempo toma pedido";
            // 
            // pnlPedido
            // 
            pnlPedido.BorderStyle = BorderStyle.Fixed3D;
            pnlPedido.Controls.Add(label15);
            pnlPedido.Controls.Add(txtProbabilidadM2);
            pnlPedido.Controls.Add(label14);
            pnlPedido.Controls.Add(txtProbabilidadM1);
            pnlPedido.Controls.Add(label13);
            pnlPedido.Controls.Add(txtPreparacionM2);
            pnlPedido.Controls.Add(label10);
            pnlPedido.Controls.Add(label11);
            pnlPedido.Controls.Add(txtPreparacionM1);
            pnlPedido.Controls.Add(label12);
            pnlPedido.Dock = DockStyle.Fill;
            pnlPedido.Location = new Point(504, 3);
            pnlPedido.Name = "pnlPedido";
            pnlParametros.SetRowSpan(pnlPedido, 2);
            pnlPedido.Size = new Size(484, 363);
            pnlPedido.TabIndex = 6;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("PP Radio Grotesk Black", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = Color.FromArgb(224, 224, 224);
            label15.Location = new Point(11, 216);
            label15.Name = "label15";
            label15.Size = new Size(254, 33);
            label15.TabIndex = 10;
            label15.Text = "Probabilidad Menu";
            // 
            // txtProbabilidadM2
            // 
            txtProbabilidadM2.Anchor = AnchorStyles.None;
            txtProbabilidadM2.Location = new Point(342, 307);
            txtProbabilidadM2.Name = "txtProbabilidadM2";
            txtProbabilidadM2.Size = new Size(125, 27);
            txtProbabilidadM2.TabIndex = 9;
            txtProbabilidadM2.KeyPress += txtProbabilidadM2_KeyPress;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("PP Radio Grotesk", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label14.ForeColor = Color.Silver;
            label14.Location = new Point(14, 304);
            label14.Name = "label14";
            label14.Size = new Size(215, 28);
            label14.TabIndex = 8;
            label14.Text = "Probabilidad menu 2";
            // 
            // txtProbabilidadM1
            // 
            txtProbabilidadM1.Anchor = AnchorStyles.None;
            txtProbabilidadM1.Location = new Point(342, 260);
            txtProbabilidadM1.Name = "txtProbabilidadM1";
            txtProbabilidadM1.Size = new Size(125, 27);
            txtProbabilidadM1.TabIndex = 7;
            txtProbabilidadM1.KeyPress += txtProbabilidadM1_KeyPress;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("PP Radio Grotesk", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label13.ForeColor = Color.Silver;
            label13.Location = new Point(14, 260);
            label13.Name = "label13";
            label13.Size = new Size(210, 28);
            label13.TabIndex = 6;
            label13.Text = "Probabilidad menu 1";
            // 
            // txtPreparacionM2
            // 
            txtPreparacionM2.Anchor = AnchorStyles.None;
            txtPreparacionM2.Location = new Point(342, 112);
            txtPreparacionM2.Name = "txtPreparacionM2";
            txtPreparacionM2.Size = new Size(125, 27);
            txtPreparacionM2.TabIndex = 5;
            txtPreparacionM2.KeyPress += txtPreparacionM2_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("PP Radio Grotesk", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.Silver;
            label10.Location = new Point(14, 111);
            label10.Name = "label10";
            label10.Size = new Size(289, 28);
            label10.TabIndex = 4;
            label10.Text = "Tiempo preparacion menu 2";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("PP Radio Grotesk Black", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.FromArgb(224, 224, 224);
            label11.Location = new Point(11, 13);
            label11.Name = "label11";
            label11.Size = new Size(261, 33);
            label11.TabIndex = 1;
            label11.Text = "Preparacion Pedido";
            // 
            // txtPreparacionM1
            // 
            txtPreparacionM1.Anchor = AnchorStyles.None;
            txtPreparacionM1.Location = new Point(342, 63);
            txtPreparacionM1.Name = "txtPreparacionM1";
            txtPreparacionM1.Size = new Size(125, 27);
            txtPreparacionM1.TabIndex = 3;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("PP Radio Grotesk", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.Silver;
            label12.Location = new Point(14, 65);
            label12.Name = "label12";
            label12.Size = new Size(284, 28);
            label12.TabIndex = 2;
            label12.Text = "Tiempo preparacion menu 1";
            // 
            // panel5
            // 
            panel5.Controls.Add(pnResultados);
            panel5.Controls.Add(pnlParametros);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 56);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(10);
            panel5.Size = new Size(1533, 791);
            panel5.TabIndex = 8;
            // 
            // pnResultados
            // 
            pnResultados.Dock = DockStyle.Fill;
            pnResultados.Location = new Point(10, 379);
            pnResultados.Name = "pnResultados";
            pnResultados.Size = new Size(1513, 402);
            pnResultados.TabIndex = 9;
            // 
            // pnlParametros
            // 
            pnlParametros.ColumnCount = 3;
            pnlParametros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.11302F));
            pnlParametros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.3859863F));
            pnlParametros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.4187469F));
            pnlParametros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            pnlParametros.Controls.Add(pnlMozo, 0, 0);
            pnlParametros.Controls.Add(pnlConsumicion, 0, 1);
            pnlParametros.Controls.Add(pnlClientes, 2, 0);
            pnlParametros.Controls.Add(pnlPedido, 1, 0);
            pnlParametros.Controls.Add(btnGenerateSimulation, 2, 1);
            pnlParametros.Dock = DockStyle.Top;
            pnlParametros.Location = new Point(10, 10);
            pnlParametros.Name = "pnlParametros";
            pnlParametros.RowCount = 2;
            pnlParametros.RowStyles.Add(new RowStyle(SizeType.Percent, 51.4905167F));
            pnlParametros.RowStyles.Add(new RowStyle(SizeType.Percent, 48.5094833F));
            pnlParametros.Size = new Size(1513, 369);
            pnlParametros.TabIndex = 8;
            // 
            // pnlClientes
            // 
            pnlClientes.BorderStyle = BorderStyle.Fixed3D;
            pnlClientes.Controls.Add(label19);
            pnlClientes.Controls.Add(txtLlegadaClientes);
            pnlClientes.Controls.Add(txtDesde);
            pnlClientes.Controls.Add(label21);
            pnlClientes.Controls.Add(label17);
            pnlClientes.Controls.Add(label16);
            pnlClientes.Controls.Add(txtCantIteraciones);
            pnlClientes.Dock = DockStyle.Fill;
            pnlClientes.Location = new Point(994, 3);
            pnlClientes.Name = "pnlClientes";
            pnlClientes.Size = new Size(516, 184);
            pnlClientes.TabIndex = 12;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("PP Radio Grotesk Black", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point);
            label19.ForeColor = Color.FromArgb(224, 224, 224);
            label19.Location = new Point(12, 14);
            label19.Name = "label19";
            label19.Size = new Size(384, 33);
            label19.TabIndex = 10;
            label19.Text = "Llegada Clientes - Simulacion";
            // 
            // txtLlegadaClientes
            // 
            txtLlegadaClientes.Anchor = AnchorStyles.None;
            txtLlegadaClientes.Location = new Point(343, 58);
            txtLlegadaClientes.Name = "txtLlegadaClientes";
            txtLlegadaClientes.Size = new Size(125, 27);
            txtLlegadaClientes.TabIndex = 7;
            txtLlegadaClientes.KeyPress += txtLlegadaClientes_KeyPress;
            // 
            // txtDesde
            // 
            txtDesde.Anchor = AnchorStyles.None;
            txtDesde.Location = new Point(343, 141);
            txtDesde.Name = "txtDesde";
            txtDesde.Size = new Size(125, 27);
            txtDesde.TabIndex = 14;
            txtDesde.KeyPress += txtDesde_KeyPress;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("PP Radio Grotesk", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label21.ForeColor = Color.Silver;
            label21.Location = new Point(12, 63);
            label21.Name = "label21";
            label21.Size = new Size(234, 28);
            label21.TabIndex = 6;
            label21.Text = "Tiempo llegada cliente";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("PP Radio Grotesk", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label17.ForeColor = Color.Silver;
            label17.Location = new Point(12, 141);
            label17.Name = "label17";
            label17.Size = new Size(161, 28);
            label17.TabIndex = 13;
            label17.Text = "Mostrar Desde";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("PP Radio Grotesk", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label16.ForeColor = Color.Silver;
            label16.Location = new Point(12, 102);
            label16.Name = "label16";
            label16.Size = new Size(248, 28);
            label16.TabIndex = 11;
            label16.Text = "Cantidad de iteraciones";
            // 
            // txtCantIteraciones
            // 
            txtCantIteraciones.Anchor = AnchorStyles.None;
            txtCantIteraciones.Location = new Point(343, 102);
            txtCantIteraciones.Name = "txtCantIteraciones";
            txtCantIteraciones.Size = new Size(125, 27);
            txtCantIteraciones.TabIndex = 12;
            txtCantIteraciones.KeyPress += txtCantIteraciones_KeyPress;
            // 
            // btnGenerateSimulation
            // 
            btnGenerateSimulation.BackColor = Color.FromArgb(63, 28, 53);
            btnGenerateSimulation.Dock = DockStyle.Fill;
            btnGenerateSimulation.Font = new Font("PP Radio Grotesk", 22.1999989F, FontStyle.Regular, GraphicsUnit.Point);
            btnGenerateSimulation.ForeColor = SystemColors.Window;
            btnGenerateSimulation.Location = new Point(994, 193);
            btnGenerateSimulation.Name = "btnGenerateSimulation";
            btnGenerateSimulation.Size = new Size(516, 173);
            btnGenerateSimulation.TabIndex = 13;
            btnGenerateSimulation.Text = "Generar Simulacion";
            btnGenerateSimulation.UseVisualStyleBackColor = false;
            btnGenerateSimulation.Click += btnGenerateSimulation_Click_1;
            // 
            // PrincipalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1533, 847);
            Controls.Add(panel5);
            Controls.Add(panel1);
            Controls.Add(superiorPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PrincipalForm";
            Text = "PrincipalForm";
            Load += PrincipalForm_Load;
            superiorPanel.ResumeLayout(false);
            superiorPanel.PerformLayout();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlConsumicion.ResumeLayout(false);
            pnlConsumicion.PerformLayout();
            pnlMozo.ResumeLayout(false);
            pnlMozo.PerformLayout();
            pnlPedido.ResumeLayout(false);
            pnlPedido.PerformLayout();
            panel5.ResumeLayout(false);
            pnlParametros.ResumeLayout(false);
            pnlClientes.ResumeLayout(false);
            pnlClientes.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel superiorPanel;
        private Button btnClose;
        private Button btnMaximize;
        private Button btnMinimize;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private Panel panel1;
        private Panel pnlConsumicion;
        private TextBox txtDesviacion;
        private Label label6;
        private Label label4;
        private TextBox txtMediaConsumicion;
        private Label label5;
        private Panel pnlMozo;
        private TextBox txtEntregaPedido;
        private Label label7;
        private Label label8;
        private TextBox txtTomaPedido;
        private Label label9;
        private Panel pnlPedido;
        private TextBox txtProbabilidadM2;
        private Label label14;
        private TextBox txtProbabilidadM1;
        private Label label13;
        private TextBox txtPreparacionM2;
        private Label label10;
        private Label label11;
        private TextBox txtPreparacionM1;
        private Label label12;
        private Label label15;
        private Label label1;
        private PictureBox pictureBox1;
        private TableLayoutPanel pnlParametros;
        private Panel pnlClientes;
        private Label label19;
        private TextBox txtLlegadaClientes;
        private Label label21;
        private Panel panel5;
        private Panel panel6;
        private TextBox txtCantIteraciones;
        private Label label16;
        private TextBox txtDesde;
        private Label label17;
        private Button btnGenerateSimulation;
        private Panel pnResultados;
    }
}