using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace PhanTuyetNga
{
    public partial class Danhmuc : Form
    {
        BLL_danhmuc bll_danhmuc = new BLL_danhmuc();
        public Danhmuc()
        {
            InitializeComponent();
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDanhmuc.Text.Trim() == "")
                {
                    MessageBox.Show("vui lòng nhập tên danh mục ! ");
                    return;
                }
                else if (txtMota.Text.Trim() == "")
                {
                    MessageBox.Show("vui lòng nhập mô tả ! ");
                    return;
                }
                bll_danhmuc.them(txtDanhmuc.Text, txtMota.Text);
                Danhmuc_Load(sender, e);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Tên danh mục bị trùng ", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Xoatextbox();
        }

        private void Danhmuc_Load(object sender, EventArgs e)
        {
            dgvdanhmuc.DefaultCellStyle.ForeColor = Color.Black;
            DataTable dt = new DataTable();
            dt = bll_danhmuc.Selectdanhmuc();
            dgvdanhmuc.DataSource = dt;
        }
        private void Xoatextbox()
        {
            txtDanhmuc.Clear();
           txtMota.Clear();
            txtTimkiem.Clear();         
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDanhmuc.Text.Trim() == "")
                {
                    MessageBox.Show("vui lòng nhập tên danh mục ! ");
                    return;
                }
                else if (txtMota.Text.Trim() == "")
                {
                    MessageBox.Show("vui lòng nhập mô tả ! ");
                    return;
                }
                bll_danhmuc.sua(txtDanhmuc.Text, txtMota.Text);
                dgvdanhmuc.DataSource = bll_danhmuc.Selectdanhmuc();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Tên danh mục bị trùng ", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Xoatextbox();
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Ban chac chan muon xoa", "Xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
                bll_danhmuc.xoa(txtDanhmuc.Text);
                Danhmuc_Load(sender, e);
            }
            Xoatextbox();
        }

        private void dgvdanhmuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtDanhmuc.Text = dgvdanhmuc.Rows[i].Cells[0].Value.ToString();
            txtMota.Text = dgvdanhmuc.Rows[i].Cells[1].Value.ToString();

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (txtTimkiem.Text.Trim() == "")
            {
                MessageBox.Show("vui long nhap thong tin tim kiem");
                return;
            }
            DataTable tb = new DataTable();
            tb = bll_danhmuc.timkiem(txtTimkiem.Text);
            dgvdanhmuc.DataSource = tb;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Danhmuc_Load(sender, e);
        }

        
    }
}
