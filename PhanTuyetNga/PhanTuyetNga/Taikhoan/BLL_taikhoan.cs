using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PhanTuyetNga
{
    class BLL_taikhoan
    {
        dal data = new dal();
        public DataTable Selecttaikhoan()
        {
            String sql = "Select * from taikhoan";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
        public void suathongtin(String username, String fullname, String avatar,int phone,  String email)
        {
            String sql = "update taikhoan set fullname =  N'" + fullname + "', avatar= N'" +avatar + "',phone = " + phone + ",email = N'" + email+ "' where username =  N'" + username + "'";
            data.ExecuteNonQuery(sql);
        }

        
        public void updatePass(string pass)
        {
            string sql = "update taikhoan set pass='" + pass + "'";
            data.ExecuteNonQuery(sql);
        }
    }
}
