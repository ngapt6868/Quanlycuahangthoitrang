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
    public partial class AddSanpham : Form
    {
        BLL_Sanpham bll_sanpham = new BLL_Sanpham();
        public AddSanpham()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int price = 0;
            if(txtProduct.Text.Trim() =="")
            {
                MessageBox.Show("Tên sản phẩm không được để trống");
                return;
            }
            else if (txtprice.Text.Trim() == "")
            {
                MessageBox.Show("Giá không được để trống");
                return;
            }
            else if (txthinhanh.Text.Trim() == "")
            {
                MessageBox.Show("Đường dẫn không được để trống");
                return;
            }
            else if (txtmota.Text.Trim() == "")
            {
                MessageBox.Show("Mô tả không được để trống");
                return;
            }
            else if (cbbthuonghieu.Text.Trim() == "")
            {
                MessageBox.Show("Thương hiệu không được để trống");
                return;
            }
            else if (cbCategori.Text.Trim() == "")
            {
                MessageBox.Show("Danh mục không được để trống");
                return;
            }
            try
            {
                price = Int32.Parse(txtprice.Text);
                if (price < 0)
                    throw new Exception("giá phải lớn hơn 0");
                
            }
            catch(FormatException)
            {
                MessageBox.Show("Giá phải là 1 số nguyên ");
                return;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            int soluong = Int32.Parse(nudAmount.Value.ToString());
            try
            {
                bll_sanpham.them(txtProduct.Text, txthinhanh.Text, price, cbbthuonghieu.Text, soluong, txtmota.Text, cbCategori.Text);
                MessageBox.Show("Thêm thành công");
                this.Close();
                
                
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog a = new OpenFileDialog();
                a.Filter = a.Filter = "JPG file(*.jpg)|*jpg|All files(*.*)|*.*";
                a.FilterIndex = 1;
                a.RestoreDirectory = true;
                if (a.ShowDialog() == DialogResult.OK)
                {
                    pbavatar.ImageLocation = a.FileName;
                    txthinhanh.Text = a.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex);
            }
        }

        private void AddSanpham_Load(object sender, EventArgs e)
        {
            cbbthuonghieu.Items.Add("Chanel");
            cbbthuonghieu.Items.Add("Prada");
            cbbthuonghieu.Items.Add("Dior");
            cbbthuonghieu.Items.Add("Gucci");
            cbbthuonghieu.Items.Add("D&G");
            cbbthuonghieu.Items.Add("Local brand;");
            DataTable tb = bll_sanpham.Selectdanhmuc();
            for(int i = 0; i<tb.Rows.Count; i ++)
            {

                cbCategori.Items.Add(tb.Rows[i][0].ToString());
            }
        }

        
    }
}
