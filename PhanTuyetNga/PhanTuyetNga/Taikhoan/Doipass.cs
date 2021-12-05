using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhanTuyetNga.Taikhoan
{
    public partial class Doipass : Form
    {
        BLL_taikhoan bll_tk = new BLL_taikhoan();
        Thongtintaikhoan t;
     
        public Doipass()
        {
            InitializeComponent();
        }
        public Doipass(Thongtintaikhoan t)
        {
            InitializeComponent();
            this.t = t;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            String pass = Program.tb.Rows[0][1].ToString();
            if (txtpasscu.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập lại password cũ");
                return;
            }
            else if (txtpassms.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập password mới");
                return;
            }
            else if (txtxacthuc.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập lại password mới");
                return;
            }
            else if (txtxacthuc.Text != txtpassms.Text)
            {
                MessageBox.Show("Pass không trùng khớp");
                return;
            }
            else if (txtpasscu.Text != pass)
            {
               
                MessageBox.Show("Bạn nhập sai pass cũ");
                return;
            }
            else
            {
                bll_tk.updatePass(txtpassms.Text);
                MessageBox.Show("Đổi mật khẩu thành công");
                this.Close();              
            }      
        }
        
       
       
    }
}
