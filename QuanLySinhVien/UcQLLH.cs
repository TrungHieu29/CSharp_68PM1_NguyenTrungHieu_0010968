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
    public partial class UcQLLH : UserControl
    {
        DatabaseDataContext db = new DatabaseDataContext();
        int trangHienTai = 1;
        int soDongTrenTrang = 10;
        int tongSoTrang = 1;

        public UcQLLH()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public void LoadData()
        {
            db = new DatabaseDataContext();

            int tongSoDong = db.LopHocs.Count();

            tongSoTrang = (int)Math.Ceiling((double)tongSoDong / soDongTrenTrang);
            if (tongSoTrang == 0) tongSoTrang = 1;

            if (trangHienTai > tongSoTrang) trangHienTai = tongSoTrang;

            int soDongBoQua = (trangHienTai - 1) * soDongTrenTrang;

            List<LopHoc> dslhPhanTrang = db.LopHocs
                                           .Skip(soDongBoQua)
                                           .Take(soDongTrenTrang)
                                           .ToList();

            dgvQLLH.DataSource = dslhPhanTrang;
        }

        private void UcQLLH_Load(object sender, EventArgs e)
        {
            txtMaID.ReadOnly = true;
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLop.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Mã lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LopHoc lh = new LopHoc();
            lh.MaLop = txtMaLop.Text.Trim();
            lh.TenLop = txtTenLop.Text.Trim();
            lh.GhiChu = txtGhiChu.Text.Trim();

            try
            {
                var checkExisted = db.LopHocs.SingleOrDefault(p => p.MaLop == lh.MaLop);
                if (checkExisted != null)
                {
                    MessageBox.Show("Mã lớp học này đã tồn tại trên hệ thống!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                db.LopHocs.InsertOnSubmit(lh);
                db.SubmitChanges();

                MessageBox.Show("Thêm lớp học thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnRefresh_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm lớp học: " + ex.Message, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaID.Text.Trim(), out int maID))
            {
                MessageBox.Show("Vui lòng chọn một lớp học từ danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                LopHoc lh = db.LopHocs.SingleOrDefault(p => p.MaID == maID);

                if (lh != null)
                {
                    lh.MaLop = txtMaLop.Text.Trim();
                    lh.TenLop = txtTenLop.Text.Trim();
                    lh.GhiChu = txtGhiChu.Text.Trim();

                    db.SubmitChanges();
                    MessageBox.Show("Cập nhật thông tin lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lớp học này để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaID.Text.Trim(), out int maID))
            {
                MessageBox.Show("Vui lòng chọn một lớp học để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                LopHoc lh = db.LopHocs.SingleOrDefault(p => p.MaID == maID);

                if (lh != null)
                {
                    var coSinhVien = db.SinhViens.Any(sv => sv.MaLop == lh.MaLop);
                    if (coSinhVien)
                    {
                        MessageBox.Show("Không thể xóa lớp học này vì đang có sinh viên thuộc lớp! Vui lòng chuyển hoặc xóa sinh viên trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa lớp học có Mã ID: {maID} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        db.LopHocs.DeleteOnSubmit(lh);
                        db.SubmitChanges();

                        MessageBox.Show("Xóa lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnRefresh_Click(sender, e);
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lớp học cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa lớp học này!\nChi tiết lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaID.Clear();
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtGhiChu.Clear();

            txtMaLop.Focus();
        }

        private void dgvQLLH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvQLLH.Rows[e.RowIndex];

                txtMaID.Text = row.Cells["MaID"].Value?.ToString();
                txtMaLop.Text = row.Cells["MaLop"].Value?.ToString();
                txtTenLop.Text = row.Cells["TenLop"].Value?.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                LoadData();
                return;
            }

            try
            {
                var ketQua = db.LopHocs.Where(lh => lh.MaID.ToString().Contains(tuKhoa)
                                                 || lh.MaLop.Contains(tuKhoa)
                                                 || lh.TenLop.Contains(tuKhoa))
                                       .ToList();

                dgvQLLH.DataSource = ketQua;

                if (ketQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy lớp học nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            trangHienTai = 1;
            LoadData();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (trangHienTai > 1)
            {
                trangHienTai--;
                LoadData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (trangHienTai < tongSoTrang)
            {
                trangHienTai++;
                LoadData();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            trangHienTai = tongSoTrang;
            LoadData();
        }
    }
}