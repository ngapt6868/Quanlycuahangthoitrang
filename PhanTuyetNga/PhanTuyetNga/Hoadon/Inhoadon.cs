using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanTuyetNga.Hoadon
{
    public partial class Inhoadon : Form
    {
        bll_hoadon bll_hd = new bll_hoadon();
        String fullname, phone;
        public Inhoadon()
        {
            InitializeComponent();
        }

        private void Inhoadon_Load(object sender, EventArgs e)
        {
            HoaDonModel m = this.Tag as HoaDonModel;

            lbMaHD.Text = "HD" + int.Parse(bll_hd.Selectmaid().Rows[0][0].ToString());
            lbHoTenKH.Text = m.TenKH; //Program.tb.Rows[0][2].ToString();
            lbSDT.Text = m.SDT; //Program.tb.Rows[0][1].ToString();
            lbNgay.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            double tongtien = 0;
            foreach(SanPhamModel x in m.sanphams)
            {
                dgvBang.Rows.Add(x.MaSP, x.DonGia, x.SoLuong, x.DonGia * x.SoLuong);
                tongtien += x.DonGia * x.SoLuong;
            }
            lbTongTien.Text = tongtien.ToString();


            
        }
        private void dgvBang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            //int masp = Int32.Parse(dgvBang.Rows[i].Cells[0].Value.ToString());
            DataTable tb = bll_hd.Selectsanphammua();             
            dgvBang.DataSource = tb;
            int masp = Int32.Parse(dgvBang.Rows[i].Cells[0].Value.ToString());
        }
    }
}
