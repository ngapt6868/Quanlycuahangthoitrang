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

namespace PhanTuyetNga.Taikhoan
{
    public partial class Suataikoan : Form
    {
        String username, fullname,  avatar, phone,  email;

       

        BLL_taikhoan bll_tk = new BLL_taikhoan();
       

        private void BtnChonanh_Click(object sender, EventArgs e)
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
                    txtDuongdan.Text = a.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtHoten.Text.Trim() == "")
            {
                MessageBox.Show("Họ tên không được để trống");
                return;
            }
            else if (txtTaikhoan.Text.Trim() == "")
            {
                MessageBox.Show("Tên tài khoản không được để trống");
                return;
            }
            else if (txtPhone.Text.Trim() == "")
            {
                MessageBox.Show("Số điện thoại không được để trống");
                return;
            }
            else if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Email không được để trống");
                return;
            }
            try
            {
                
                dal Dal = new dal();
                bll_tk.suathongtin(txtTaikhoan.Text,txtHoten.Text,txtDuongdan.Text,Int32.Parse(txtPhone.Text),txtEmail.Text);
                Program.tb = Dal.GetTable("select *from taikhoan where username = '" + txtTaikhoan.Text + "'");
                MessageBox.Show("Sửa thành công");
                //Thongtintaikhoan tk = new Thongtintaikhoan();
                this.Hide();
                //tk.Show();

             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              
            }
        }
        public Suataikoan()
        {
            InitializeComponent();
        }
        public Suataikoan(String username,String fullname,String avatar,String phone,String email)
        {
            InitializeComponent();
            this.username = username;
            this.fullname = fullname;
            this.avatar = avatar;
            this.phone = phone;
            this.email = email;
        }
        private void Suataikoan_Load(object sender, EventArgs e)
        {
            txtHoten.Text = fullname;
            txtTaikhoan.Text = username;
            txtTaikhoan.Enabled = false;
            txtPhone.Text = phone;
            txtEmail.Text = email;
            txtDuongdan.Text = avatar;          
            pbavatar.ImageLocation = avatar;

        }
    }
    
}
