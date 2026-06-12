using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class FrmDanhSachSinhVienLop : Form
    {
        DatabaseDataContext db = new DatabaseDataContext();
        private string _maLop;

        public FrmDanhSachSinhVienLop(string maLop)
        {
            InitializeComponent();
            _maLop = maLop;
        }

        private void FrmDanhSachSinhVienLop_Load(object sender, EventArgs e)
        {
            lblTenLop.Text = "DANH SÁCH SINH VIÊN LỚP: " + _maLop;
            LoadSinhVienTheoLop();
        }

        private void LoadSinhVienTheoLop()
        {
            try
            {
                db = new DatabaseDataContext();

                var dsSinhVien = db.SinhViens.Where(sv => sv.MaLop == _maLop).ToList();

                dgvSinhVienLop.DataSource = dsSinhVien;

                if (dsSinhVien.Count == 0)
                {
                    MessageBox.Show("Lớp học này hiện tại chưa có sinh viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}