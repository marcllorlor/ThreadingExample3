namespace Practica3
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpBotonsCotxes = new System.Windows.Forms.GroupBox();
            this.btnCrearCotxe = new System.Windows.Forms.Button();
            this.rbExtra = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbBasic = new System.Windows.Forms.RadioButton();
            this.pnlCotxesTotals = new System.Windows.Forms.Panel();
            this.gpBotonsCotxes.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpBotonsCotxes
            // 
            this.gpBotonsCotxes.Controls.Add(this.btnCrearCotxe);
            this.gpBotonsCotxes.Controls.Add(this.rbExtra);
            this.gpBotonsCotxes.Controls.Add(this.rbNormal);
            this.gpBotonsCotxes.Controls.Add(this.rbBasic);
            this.gpBotonsCotxes.Location = new System.Drawing.Point(12, 12);
            this.gpBotonsCotxes.Name = "gpBotonsCotxes";
            this.gpBotonsCotxes.Size = new System.Drawing.Size(221, 239);
            this.gpBotonsCotxes.TabIndex = 0;
            this.gpBotonsCotxes.TabStop = false;
            // 
            // btnCrearCotxe
            // 
            this.btnCrearCotxe.Location = new System.Drawing.Point(6, 176);
            this.btnCrearCotxe.Name = "btnCrearCotxe";
            this.btnCrearCotxe.Size = new System.Drawing.Size(209, 57);
            this.btnCrearCotxe.TabIndex = 3;
            this.btnCrearCotxe.Text = "Crear Cotxe";
            this.btnCrearCotxe.UseVisualStyleBackColor = true;
            this.btnCrearCotxe.Click += new System.EventHandler(this.btnCrearCotxe_Click);
            // 
            // rbExtra
            // 
            this.rbExtra.AutoSize = true;
            this.rbExtra.Location = new System.Drawing.Point(52, 124);
            this.rbExtra.Name = "rbExtra";
            this.rbExtra.Size = new System.Drawing.Size(58, 20);
            this.rbExtra.TabIndex = 2;
            this.rbExtra.Text = "Extra";
            this.rbExtra.UseVisualStyleBackColor = true;
            this.rbExtra.CheckedChanged += new System.EventHandler(this.rbBasic_CheckedChanged);
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(52, 74);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(72, 20);
            this.rbNormal.TabIndex = 1;
            this.rbNormal.Text = "Normal";
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.CheckedChanged += new System.EventHandler(this.rbBasic_CheckedChanged);
            // 
            // rbBasic
            // 
            this.rbBasic.AutoSize = true;
            this.rbBasic.Checked = true;
            this.rbBasic.Location = new System.Drawing.Point(52, 29);
            this.rbBasic.Name = "rbBasic";
            this.rbBasic.Size = new System.Drawing.Size(62, 20);
            this.rbBasic.TabIndex = 0;
            this.rbBasic.TabStop = true;
            this.rbBasic.Text = "Basic";
            this.rbBasic.UseVisualStyleBackColor = true;
            this.rbBasic.CheckedChanged += new System.EventHandler(this.rbBasic_CheckedChanged);
            // 
            // pnlCotxesTotals
            // 
            this.pnlCotxesTotals.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCotxesTotals.Location = new System.Drawing.Point(879, 86);
            this.pnlCotxesTotals.Name = "pnlCotxesTotals";
            this.pnlCotxesTotals.Size = new System.Drawing.Size(600, 600);
            this.pnlCotxesTotals.TabIndex = 13;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 683);
            this.Controls.Add(this.pnlCotxesTotals);
            this.Controls.Add(this.gpBotonsCotxes);
            this.Name = "FrmMain";
            this.Text = "Practica 3";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.gpBotonsCotxes.ResumeLayout(false);
            this.gpBotonsCotxes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpBotonsCotxes;
        private System.Windows.Forms.Button btnCrearCotxe;
        private System.Windows.Forms.RadioButton rbExtra;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbBasic;
        private System.Windows.Forms.Panel pnlCotxesTotals;
    }
}

