using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanTuyetNga.Admin.Doanhthu
{
    public partial class Doanhthu : Form
    {
        bll_Doanhthu bll_DT = new bll_Doanhthu();
        private int id_hoadon;

        public Doanhthu()
        {
            InitializeComponent();
        }

        private void Doanhthu_Load(object sender, EventArgs e)
        {

            //cbbThongke.Items.Add("Tất cả");
            //cbbThongke.Items.Add("Theo Ngày");
            //cbbThongke.Items.Add("Theo Tháng");
            //cbbThongke.Items.Add("Theo Năm");
            cbbThongke.SelectedIndex = 0;
            DataTable tb =  bll_DT.Selecthoadon(0);
            dgvHoadon.DataSource = tb;                    
        }

        private void dgvHoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            int mahd = Int32.Parse( dgvHoadon.Rows[i].Cells[0].Value.ToString());
            DataTable tb = bll_DT.Selectchitietdon(mahd);
            dataGridView2.DataSource = tb;
            id_hoadon = Int32.Parse(dgvHoadon.Rows[i].Cells[0].Value.ToString());
        }

        private void cbbThongke_SelectedIndexChanged(object sender, EventArgs e)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            if (cbbThongke.Text == "Tất cả")
            {              
                DataTable tb = bll_DT.Selecthoadon(0);
                dgvHoadon.DataSource = tb;
                int doanhthu = 0;
               for(int i = 0; i<tb.Rows.Count; i++)
                {
                    doanhthu += Int32.Parse(tb.Rows[i][4].ToString());
                }
                txtDanhThu.Text = doanhthu.ToString("#,###", cul.NumberFormat);
                
            }
            if (cbbThongke.Text == "Theo Ngày")
            {
                txtDanhThu.Text = bll_DT.DoanhThu(1).ToString("#,###", cul.NumberFormat);

                DataTable tb = bll_DT.Selecthoadon(1);
                dgvHoadon.DataSource = tb;
            }
            else if (cbbThongke.Text == "Theo Tháng")
            {
                txtDanhThu.Text = bll_DT.DoanhThu(2).ToString("#,###", cul.NumberFormat);
                DataTable tb = bll_DT.Selecthoadon(2);
                dgvHoadon.DataSource = tb;
            }
            else if (cbbThongke.Text == "Theo Năm")
            {
                txtDanhThu.Text = bll_DT.DoanhThu(3).ToString("#,###", cul.NumberFormat);
                DataTable tb = bll_DT.Selecthoadon(3);
                dgvHoadon.DataSource = tb;
               
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cbbThongke.Text = "";
            Doanhthu_Load(sender, e);
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Bạn chắc chắn muốn xóa", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Result == DialogResult.Yes)
            {
               
                bll_DT.xoachitiethd(id_hoadon);
                bll_DT.xoahd(id_hoadon);
                cbbThongke.Text = "";
                Doanhthu_Load(sender, e);
            }
          
        }

        
    }
}
