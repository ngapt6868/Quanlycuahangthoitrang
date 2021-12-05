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
    public partial class Dangnhap : Form
    {
        public Dangnhap()
        {
            InitializeComponent();
        }

    
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtAccount.Text.Trim() == "")
            {
                MessageBox.Show("vui long nhap tai khoan ! ");
                return;
            }
            else if(txtPassword.Text.Trim() =="")
            {
                MessageBox.Show("vui long nhap tai khoan ! ");
                return;
            }
            
            
            dal Dal = new dal();
            DataTable h = new DataTable();
            h = Dal.GetTable("select username, pass from taikhoan where username = '" + txtAccount.Text + "' and pass = '" + txtPassword.Text + "' ");
            if (txtAccount.Text == "admin" && txtPassword.Text == "1234")
            {
                Giaodien f = new Giaodien();
                f.check = true;
                f.Show();


            }
            else if(h.Rows.Count == 0)
            {
                MessageBox.Show("Bạn đã nhập sai tài khoản hoặc mật khẩu");
            }
            else
            {
               Program.tb =  Dal.GetTable("select *from taikhoan where username = '"+txtAccount.Text+"'");
                Giaodien f = new Giaodien();
                f.Show();

            }


        }
    }
}
