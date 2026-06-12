using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLySinhVien
{
    public partial class UcQLSV : UserControl
    {
        DatabaseDataContext db = new DatabaseDataContext();
        public UcQLSV()
        {
            InitializeComponent();
        }

        private void QLSV_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDSLH4CBX();
        }

        public void LoadData()
        {
            List<SinhVien> dssv = db.SinhViens.ToList();
            dgvQLSV.DataSource = dssv;
        }

        public void LoadDSLH4CBX()
        {
            List<LopHoc> dslh = db.LopHocs.ToList();
            cboMaLop.DataSource = dslh;
            cboMaLop.DisplayMember = "TenLop";
            cboMaLop.ValueMember = "MaLop";
            cboMaLop.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.MaSV = txtMaSV.Text;
            sv.HoTen = txtHoTen.Text;
            sv.NgaySinh = DateTime.Parse(dtpNgaySinh.Text);
            sv.GioiTinh = cboGioiTinh.Text;
            sv.MaLop = cboMaLop.SelectedValue.ToString();
            try
            {
                db.SinhViens.InsertOnSubmit(sv);
                db.SubmitChanges();
                MessageBox.Show("Thêm sinh viên thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgvQLSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvQLSV.Rows[e.RowIndex];

                txtMaSV.Text = row.Cells["MaSV"].Value?.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();

                if (row.Cells["NgaySinh"].Value != null && row.Cells["NgaySinh"].Value != DBNull.Value)
                {
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                }

                if (row.Cells["GioiTinh"].Value != null)
                {
                    cboGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                }

                if (row.Cells["MaLop"].Value != null)
                {
                    cboMaLop.SelectedValue = row.Cells["MaLop"].Value.ToString();
                }
                else
                {
                    cboMaLop.SelectedIndex = -1;
                }

                txtMaSV.ReadOnly = true; 
            }
        }

       

        private void cboGioiTinh_DropDownStyleChanged(object sender, EventArgs e)
        {
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
