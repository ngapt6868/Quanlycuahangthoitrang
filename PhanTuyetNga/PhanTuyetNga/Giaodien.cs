using PhanTuyetNga.Admin.Doanhthu;
using PhanTuyetNga.Taikhoan;
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
    public partial class Giaodien : Form
    {
        public Boolean check = false;
        public Giaodien()
        {
            InitializeComponent();
        }
       

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Danhmuc h= new Danhmuc();
            h.MdiParent = this;
            // h.TopLevel = false;
            h.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(h);
            h.FormBorderStyle = FormBorderStyle.None;
            h.BringToFront();
            h.Show();
        }
 
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Giaodien n =  new Giaodien();
            n.Show();
            this.Hide();*/
            pictureBox1.BringToFront();
        }

        private void sảnPhẩmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            sanpham h = new sanpham();
            h.MdiParent = this;
            // h.TopLevel = false;
            h.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(h);
            h.FormBorderStyle = FormBorderStyle.None;
            h.BringToFront();
            h.Show();
        }
        
        
        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hoadon h = new hoadon();
            h.MdiParent = this;
            // h.TopLevel = false;
            h.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(h);
            h.FormBorderStyle = FormBorderStyle.None;
            h.BringToFront();
            h.Show();
        }

       
       
        private void doanhThuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Doanhthu h = new Doanhthu();
            h.MdiParent = this;
            // h.TopLevel = false;
            h.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(h);
            h.FormBorderStyle = FormBorderStyle.None;
            h.BringToFront();
            h.Show();
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thongtintaikhoan h = new Thongtintaikhoan();
            h.MdiParent = this;
            // h.TopLevel = false;
            h.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(h);
            h.FormBorderStyle = FormBorderStyle.None;
            h.BringToFront();
            h.Show();
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Dangnhap h = new Dangnhap();
            this.Hide();
            h.Show();
        }
    }
}
