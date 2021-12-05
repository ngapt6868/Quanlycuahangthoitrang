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
    public partial class EditSanpham : Form
    {

        String Tensp, avatar, price, brand, soluong, Mota, Tendanhmuc;
        int masp;
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

        BLL_Sanpham bll_sanpham = new BLL_Sanpham();
        private void btnsua_Click(object sender, EventArgs e)
        {
            int gia = 0;
            if (txtProduct.Text.Trim() == "")
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
                gia = Int32.Parse(txtprice.Text);
                if (gia < 0)
                    throw new Exception("giá phải lớn hơn 0");

            }
            catch (FormatException)
            {
                MessageBox.Show("Giá phải là 1 số nguyên ");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            int soluong = Int32.Parse(nudAmount.Value.ToString());
            try
            {
                bll_sanpham.sua(masp,txtProduct.Text, txthinhanh.Text, gia, cbbthuonghieu.Text, soluong, txtmota.Text, cbCategori.Text);
                MessageBox.Show("Sửa thành công");
                this.Hide();
                sanpham sp = new sanpham();
                sp.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public EditSanpham()
        {
            InitializeComponent();
        }
        public EditSanpham(DataTable tb)
        {
            InitializeComponent();
            masp = Int32.Parse(tb.Rows[0][0].ToString());
            Tensp = tb.Rows[0][1].ToString();
            avatar = tb.Rows[0][2].ToString();
            price = tb.Rows[0][3].ToString();
            brand = tb.Rows[0][4].ToString();
            soluong = tb.Rows[0][5].ToString();
            Mota = tb.Rows[0][6].ToString();
            Tendanhmuc = tb.Rows[0][8].ToString();


        }

        private void EditSanpham_Load(object sender, EventArgs e)
        {
            cbbthuonghieu.Items.Add("a");
            cbbthuonghieu.Items.Add("b");
            cbbthuonghieu.Items.Add("c");
            DataTable tb = bll_sanpham.Selectdanhmuc();
            for (int i = 0; i < tb.Rows.Count; i++)
            {

                cbCategori.Items.Add(tb.Rows[i][0].ToString());
            }
            txtProduct.Text = Tensp;
            txthinhanh.Text = avatar;
            txtprice.Text = price;
            cbbthuonghieu.Text = brand;
            txtmota.Text = Mota;
            cbCategori.Text = Tendanhmuc;
            nudAmount.Value = Int32.Parse(soluong);
            pbavatar.ImageLocation = avatar;
        }
    }
}
