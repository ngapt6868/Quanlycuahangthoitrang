using PhanTuyetNga.Admin.Doanhthu;
using PhanTuyetNga.Hoadon;
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
    
    public partial class hoadon : Form
    {
        bll_hoadon bll_hd = new bll_hoadon();
        List<String> masp = new List<String>();
        List<String> gia = new List<String>();
        
        public object AgeNumericUpDown { get; private set; }

        public hoadon()
        {
            InitializeComponent();
        }

        private void hoadon_Load(object sender, EventArgs e)
        {
            DataTable tb = bll_hd.Selectsanpham();
            for (int i = 0; i < tb.Rows.Count; i++)
            {

               cnbMasp.Items.Add(tb.Rows[i][0].ToString());
                masp.Add(tb.Rows[i][0].ToString());
                gia.Add(tb.Rows[i][1].ToString());
            }
            bll_hd.xoabangtam();
           
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtten.Text.Trim() == "")
            {
                MessageBox.Show("Họ tên không được để trống");
                return;
            }
            else if (txtten.Text.Trim() == "")
            {
                MessageBox.Show("SĐT không được để trống");
                return;
            }
            
            int soluong = Int32.Parse(txtsoluong.Value.ToString());
            try
            {              
                //MessageBox.Show("In hóa đơn thành công");
               

                Doanhthu dt = new Doanhthu();
                String a = "";
                if (rdothe.Checked)
                {
                   a = "Bằng thẻ"; 
                }
                else if (rdotien.Checked)
                {
                    a = "Tiền mặt";
                }
                bll_hd.inhd(txtten.Text, txtsdt.Text, txtnote.Text,int.Parse(txtTongtien.Text), a);
                for(int i = 0; i < dataGridView1.Rows.Count ; i++)
                {
                    bll_hd.chitietdon(int.Parse(bll_hd.Selectmaid().Rows[0][0].ToString()), int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()), 
                        int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()), int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()), int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()));
                }
                for (int i = 0; i < dataGridView1.Rows.Count ; i++)
                {
                    bll_hd.updatesoluong(int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()), int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                }
                //this.Hide();
                Inhoadon d = new Inhoadon();
                HoaDonModel m = new HoaDonModel()
                {
                    SDT = txtsdt.Text,
                    TenKH = txtten.Text

                };
                m.sanphams = new List<SanPhamModel>();
                foreach (DataGridViewRow x in dataGridView1.Rows)
                {
                    SanPhamModel s = new SanPhamModel();
                    s.MaSP = x.Cells[0].Value.ToString();
                    s.DonGia = double.Parse(x.Cells[1].Value.ToString());
                    s.SoLuong = int.Parse(x.Cells[2].Value.ToString());
                    m.sanphams.Add(s);

                }
                d.Tag = m; // thẻ tag để truyền giá trị qua lại giữa 2 form 
                d.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void load_sanpham()
        {
            DataTable tb = bll_hd.Selectsanphammua();
            dataGridView1.DataSource = tb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cnbMasp.Text.Trim() == "")
            {
                MessageBox.Show("Mã sản phẩm không được để trống");
                return;
            }
            DataTable tb = bll_hd.Selectslsanpham(Int32.Parse(cnbMasp.Text));
            int sl = Int32.Parse(tb.Rows[0][0].ToString());
            if (sl < Int32.Parse(txtsoluong.Value.ToString()))
            {
                MessageBox.Show("Số lượng không đủ");
                return;
              
            }
            bll_hd.luu(Int32.Parse(cnbMasp.Text), Int32.Parse(txtdongia.Text), Int32.Parse(txtsoluong.Value.ToString()), Int32.Parse(
                txtThanhtien.Text));
            load_sanpham();
            int tongtien = 0;
            for (int i = 0;i<dataGridView1.Rows.Count; i++)
            {
                tongtien += int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            }
            txtTongtien.Text = tongtien.ToString();
            Xoatextbox();

            
        }

        private void Xoatextbox()
        {
            cnbMasp.Text = "";
            txtThanhtien.Clear();
            txtdongia.Clear();
            txtsoluong.Value = 0;

        }
        private void cnbMasp_SelectedIndexChanged(object sender, EventArgs e)
        {
            int temp = -1;
            for(int i = 0; i<masp.Count; i++)
            {
                if(cnbMasp.Text == masp[i])
                {
                    temp = i;
                    break;
                }
            }
           if(temp != -1)
            txtdongia.Text = gia[temp];

        }

        private void txtsoluong_ValueChanged(object sender, EventArgs e)
        {
            if(txtdongia.Text!= "" && (int)txtsoluong.Value != 0)
            {
                int tt = Int32.Parse(txtsoluong.Value.ToString()) * Int32.Parse(txtdongia.Text);
                txtThanhtien.Text = tt.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(id == 0)
            {
                MessageBox.Show("chọn 1 dòng để xóa");
                return;
            }
            bll_hd.huy(id);
            load_sanpham();
            int tongtien = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                tongtien += Int32.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            }
            txtTongtien.Text = tongtien.ToString();
            Xoatextbox();
        }

      
        int id = 0;
      

        private void dataGridView1_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {

            int i = e.RowIndex;
            cnbMasp.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtdongia.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtsoluong.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtThanhtien.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            id = Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
           
        }
    }
}
