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

        private void UcQLLH_Load(object sender, EventArgs e)
        {
            List<LopHoc> dslh = db.LopHocs.ToList();
            dgvQLLH.DataSource = dslh;
        }
    }
}
