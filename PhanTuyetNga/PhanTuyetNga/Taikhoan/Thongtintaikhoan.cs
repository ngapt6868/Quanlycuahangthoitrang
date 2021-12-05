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
    public partial class Thongtintaikhoan : Form
    {
        BLL_taikhoan bll_tk = new BLL_taikhoan();
        String username, fullname, avatar, phone, email;
        public Thongtintaikhoan()
        {
            InitializeComponent();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            username = Program.tb.Rows[0][0].ToString();

            fullname = Program.tb.Rows[0][2].ToString();
            avatar = Program.tb.Rows[0][3].ToString();
            phone = Program.tb.Rows[0][4].ToString();
            email  = Program.tb.Rows[0][5].ToString();
            Suataikoan h = new Suataikoan(username,fullname,avatar,phone,email);
            //this.Hide();
            h.Show();
        }

        private void btnRessetPassword_Click(object sender, EventArgs e)
        {
            Doipass d = new Doipass();            
            d.ShowDialog();
        }

        private void Thongtintaikhoan_Load(object sender, EventArgs e)
        {
            label5.Text = Program.tb.Rows[0][2].ToString();
            label7.Text = Program.tb.Rows[0][0].ToString();
            label8.Text = Program.tb.Rows[0][4].ToString();
            label9.Text = Program.tb.Rows[0][5].ToString();
            try
            {
                Image image = Image.FromFile(Program.tb.Rows[0][3].ToString());
                pbavatar.Image = image;
                pbavatar.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch(Exception ex)
            {
                MessageBox.Show("lỗi");
            }
        }
    }
}
