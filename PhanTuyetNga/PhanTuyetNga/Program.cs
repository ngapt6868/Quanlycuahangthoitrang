using PhanTuyetNga.Admin.Doanhthu;
using PhanTuyetNga.Taikhoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using PhanTuyetNga.Hoadon;

namespace PhanTuyetNga
{
    static class Program
    {
        internal static DataTable tb;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dangnhap());    
        }
    }
}
