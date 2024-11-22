namespace TheCave
{
    partial class Reportes
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
            this.buttonRFN2 = new System.Windows.Forms.Button();
            this.ButtonRFN1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRFN2
            // 
            this.buttonRFN2.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonRFN2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonRFN2.FlatAppearance.BorderSize = 0;
            this.buttonRFN2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRFN2.Font = new System.Drawing.Font("hooge 05_53", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRFN2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRFN2.Location = new System.Drawing.Point(243, 50);
            this.buttonRFN2.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRFN2.Name = "buttonRFN2";
            this.buttonRFN2.Size = new System.Drawing.Size(163, 63);
            this.buttonRFN2.TabIndex = 11;
            this.buttonRFN2.Text = "Generar Reporte Productos";
            this.buttonRFN2.UseVisualStyleBackColor = false;
            this.buttonRFN2.Click += new System.EventHandler(this.buttonRFN2_Click);
            // 
            // ButtonRFN1
            // 
            this.ButtonRFN1.BackColor = System.Drawing.Color.LimeGreen;
            this.ButtonRFN1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ButtonRFN1.FlatAppearance.BorderSize = 0;
            this.ButtonRFN1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonRFN1.Font = new System.Drawing.Font("hooge 05_53", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRFN1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonRFN1.Location = new System.Drawing.Point(34, 50);
            this.ButtonRFN1.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonRFN1.Name = "ButtonRFN1";
            this.ButtonRFN1.Size = new System.Drawing.Size(163, 63);
            this.ButtonRFN1.TabIndex = 12;
            this.ButtonRFN1.Text = "Generar Reporte Alquileres";
            this.ButtonRFN1.UseVisualStyleBackColor = false;
            this.ButtonRFN1.Click += new System.EventHandler(this.ButtonRFN1_Click);
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(480, 209);
            this.Controls.Add(this.ButtonRFN1);
            this.Controls.Add(this.buttonRFN2);
            this.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.Name = "Reportes";
            this.Text = "Reportes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRFN2;
        private System.Windows.Forms.Button ButtonRFN1;
    }
}