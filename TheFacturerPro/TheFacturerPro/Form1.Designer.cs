namespace TheFacturerPro
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabClients = new System.Windows.Forms.TabPage();
            this.tabProductes = new System.Windows.Forms.TabPage();
            this.tabFactures = new System.Windows.Forms.TabPage();
            this.tabFacturesDetall = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.bExportar = new System.Windows.Forms.Button();
            this.bImportar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(662, 476);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabClients);
            this.tabControl1.Controls.Add(this.tabProductes);
            this.tabControl1.Controls.Add(this.tabFactures);
            this.tabControl1.Controls.Add(this.tabFacturesDetall);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(556, 470);
            this.tabControl1.TabIndex = 0;
            // 
            // tabClients
            // 
            this.tabClients.Location = new System.Drawing.Point(4, 22);
            this.tabClients.Name = "tabClients";
            this.tabClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabClients.Size = new System.Drawing.Size(548, 444);
            this.tabClients.TabIndex = 0;
            this.tabClients.Text = "Clients";
            this.tabClients.UseVisualStyleBackColor = true;
            // 
            // tabProductes
            // 
            this.tabProductes.Location = new System.Drawing.Point(4, 22);
            this.tabProductes.Name = "tabProductes";
            this.tabProductes.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductes.Size = new System.Drawing.Size(483, 432);
            this.tabProductes.TabIndex = 1;
            this.tabProductes.Text = "Productes";
            this.tabProductes.UseVisualStyleBackColor = true;
            // 
            // tabFactures
            // 
            this.tabFactures.Location = new System.Drawing.Point(4, 22);
            this.tabFactures.Name = "tabFactures";
            this.tabFactures.Size = new System.Drawing.Size(483, 432);
            this.tabFactures.TabIndex = 2;
            this.tabFactures.Text = "Factures";
            this.tabFactures.UseVisualStyleBackColor = true;
            // 
            // tabFacturesDetall
            // 
            this.tabFacturesDetall.Location = new System.Drawing.Point(4, 22);
            this.tabFacturesDetall.Name = "tabFacturesDetall";
            this.tabFacturesDetall.Size = new System.Drawing.Size(483, 432);
            this.tabFacturesDetall.TabIndex = 3;
            this.tabFacturesDetall.Text = "Factures detall";
            this.tabFacturesDetall.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.bExportar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.bImportar, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(565, 25);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 25, 3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(94, 139);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // bExportar
            // 
            this.bExportar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bExportar.Location = new System.Drawing.Point(10, 10);
            this.bExportar.Margin = new System.Windows.Forms.Padding(10);
            this.bExportar.Name = "bExportar";
            this.bExportar.Size = new System.Drawing.Size(74, 26);
            this.bExportar.TabIndex = 0;
            this.bExportar.Text = "Exportar";
            this.bExportar.UseVisualStyleBackColor = true;
            // 
            // bImportar
            // 
            this.bImportar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bImportar.Location = new System.Drawing.Point(10, 56);
            this.bImportar.Margin = new System.Windows.Forms.Padding(10);
            this.bImportar.Name = "bImportar";
            this.bImportar.Size = new System.Drawing.Size(74, 26);
            this.bImportar.TabIndex = 1;
            this.bImportar.Text = "Importar";
            this.bImportar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 476);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabClients;
        private System.Windows.Forms.TabPage tabProductes;
        private System.Windows.Forms.TabPage tabFactures;
        private System.Windows.Forms.TabPage tabFacturesDetall;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button bExportar;
        private System.Windows.Forms.Button bImportar;
    }
}

