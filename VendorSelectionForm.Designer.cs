using System;
using System.Drawing;
using System.Windows.Forms;

namespace AMD_DWORD_Viewer
{
    partial class VendorSelectionForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnAMD;
        private Button btnNvidia;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnAMD = new Button();
            this.btnNvidia = new Button();
            this.lblTitle = new Label();
            this.SuspendLayout();
            
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(0, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(400, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Select your GPU";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            
            this.btnAMD.BackColor = Color.FromArgb(40, 40, 40);
            this.btnAMD.FlatStyle = FlatStyle.Flat;
            this.btnAMD.FlatAppearance.BorderColor = Color.FromArgb(220, 0, 0);
            this.btnAMD.FlatAppearance.BorderSize = 2;
            this.btnAMD.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 0, 0);
            this.btnAMD.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.btnAMD.ForeColor = Color.FromArgb(220, 0, 0);
            this.btnAMD.Location = new Point(40, 90);
            this.btnAMD.Name = "btnAMD";
            this.btnAMD.Size = new Size(150, 70);
            this.btnAMD.TabIndex = 1;
            this.btnAMD.Text = "AMD";
            this.btnAMD.UseVisualStyleBackColor = false;
            this.btnAMD.Click += new EventHandler(this.btnAMD_Click);
            this.btnAMD.Cursor = Cursors.Hand;
            
            this.btnNvidia.BackColor = Color.FromArgb(40, 40, 40);
            this.btnNvidia.FlatStyle = FlatStyle.Flat;
            this.btnNvidia.FlatAppearance.BorderColor = Color.FromArgb(118, 185, 0);
            this.btnNvidia.FlatAppearance.BorderSize = 2;
            this.btnNvidia.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 60, 0);
            this.btnNvidia.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.btnNvidia.ForeColor = Color.FromArgb(118, 185, 0);
            this.btnNvidia.Location = new Point(210, 90);
            this.btnNvidia.Name = "btnNvidia";
            this.btnNvidia.Size = new Size(150, 70);
            this.btnNvidia.TabIndex = 2;
            this.btnNvidia.Text = "Nvidia";
            this.btnNvidia.UseVisualStyleBackColor = false;
            this.btnNvidia.Click += new EventHandler(this.btnNvidia_Click);
            this.btnNvidia.Cursor = Cursors.Hand;
            
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Black;
            this.ClientSize = new Size(400, 200);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAMD);
            this.Controls.Add(this.btnNvidia);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VendorSelectionForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "GPU Selection";
            this.ResumeLayout(false);
        }
    }
}
