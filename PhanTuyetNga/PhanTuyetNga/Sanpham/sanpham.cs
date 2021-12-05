using PhanTuyetNga.Sanpham;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanTuyetNga
{
    public partial class sanpham : Form
    {
        BLL_Sanpham bll_sanpham = new BLL_Sanpham();
        public sanpham()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            AddSanpham h = new AddSanpham();
            h.ShowDialog();                
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            DataTable tb = bll_sanpham.Selectmasp(masp);
            EditSanpham k = new EditSanpham(tb);
            //this.Hide();
            k.ShowDialog();
           
        }

        private void sanpham_Load(object sender, EventArgs e)
        {
            btnremove.Enabled = false;
            btnupdate.Enabled = false;
            DataTable tb = bll_sanpham.Selectsanpham();
            dgvsanpham.DataSource = tb;
        }

        int masp;

        private void dgvsanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            btnupdate.Enabled = true;
            btnremove.Enabled = true;
            try
            {
                masp = Int32.Parse(dgvsanpham.Rows[i].Cells[0].Value.ToString());
                Image image = Image.FromFile(dgvsanpham.Rows[i].Cells[2].Value.ToString());
                pchinhanh.Image = image;
                pchinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch(Exception ex)
            {
                Console.WriteLine("loi");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtsearch.Text = "";
            sanpham_Load(sender, e);
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Bạn chắc chắn muốn xóa", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
                bll_sanpham.xoa(masp);
                sanpham_Load(sender, e);
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if(txtsearch.Text.Trim() == "")
            {
                MessageBox.Show("vui lòng nhập thông tin tìm kiếm");
                return;

            }
            if(rdoid.Checked ==false  && rdosanpham.Checked ==false)
            {
                MessageBox.Show("vui lòng chọn phương thức tìm kiếm");
                return;
            }
            else if(rdoid.Checked)
            {
                int id = 0;
                try
                {
                    id = Int32.Parse(txtsearch.Text);
                }
                catch(FormatException ex)
                {
                    MessageBox.Show("nội dung tìm kiếm là số nguyên");
                }
                DataTable tb = bll_sanpham.timkiem(id);
                dgvsanpham.DataSource = tb;
            } 
            else
            {
                DataTable tb = bll_sanpham.timkiem2(txtsearch.Text);
                dgvsanpham.DataSource = tb;
            }    
            
        }
    }
}
