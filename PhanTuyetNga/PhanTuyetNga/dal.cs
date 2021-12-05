using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PhanTuyetNga
{
    class dal
    {   
        public SqlConnection getConnection()
        {
            string connString = @"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLBanPkien;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
        public DataTable GetTable(String sql)
        {
            SqlConnection con = getConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public void ExecuteNonQuery(String sql)
        {
            SqlConnection con = getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public int ExecuteScalar(String sql)
        {
            SqlConnection con = getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            int value = (int)cmd.ExecuteScalar();
            con.Close();
            return value;
        }


    }
}
