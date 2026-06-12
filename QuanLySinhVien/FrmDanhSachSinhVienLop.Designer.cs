namespace QuanLySinhVien
{
    partial class FrmDanhSachSinhVienLop
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTenLop = new System.Windows.Forms.Label();
            this.dgvSinhVienLop = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVienLop)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTenLop
            // 
            this.lblTenLop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTenLop.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenLop.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTenLop.Location = new System.Drawing.Point(12, 25);
            this.lblTenLop.Name = "lblTenLop";
            this.lblTenLop.Size = new System.Drawing.Size(1160, 45);
            this.lblTenLop.TabIndex = 1;
            this.lblTenLop.Text = "DANH SÁCH SINH VIÊN";
            this.lblTenLop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSinhVienLop
            // 
            this.dgvSinhVienLop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSinhVienLop.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSinhVienLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVienLop.Location = new System.Drawing.Point(30, 95);
            this.dgvSinhVienLop.Name = "dgvSinhVienLop";
            this.dgvSinhVienLop.RowHeadersWidth = 62;
            this.dgvSinhVienLop.RowTemplate.Height = 28;
            this.dgvSinhVienLop.Size = new System.Drawing.Size(1124, 630);
            this.dgvSinhVienLop.TabIndex = 0;
            // 
            // FrmDanhSachSinhVienLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.lblTenLop);
            this.Controls.Add(this.dgvSinhVienLop);
            this.Name = "FrmDanhSachSinhVienLop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách sinh viên theo lớp";
            this.Load += new System.EventHandler(this.FrmDanhSachSinhVienLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVienLop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.DataGridView dgvSinhVienLop;
    }
}