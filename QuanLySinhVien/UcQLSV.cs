using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
