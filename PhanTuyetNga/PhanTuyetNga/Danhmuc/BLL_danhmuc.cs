using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PhanTuyetNga
{
    class BLL_danhmuc
    {
        dal data = new dal();
        public DataTable Selectdanhmuc()
        {
            String sql = "Select * from danhmuc";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
        public DataTable timkiem(String id)
        {
            String sql = "Select * from danhmuc where Tendanhmuc = N'"+id+"'";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
        public void them(String Tendanhmuc, String Mota)
        {
            String sql = "insert into danhmuc values (N'" + Tendanhmuc + "',N'" + Mota + "')";
            data.ExecuteNonQuery(sql);
        }
        public void sua(String Tendanhmuc, String Mota)
        {
            String sql = "update danhmuc set Mota = N'" + Mota + "' where Tendanhmuc = N'" + Tendanhmuc + "'";
            data.ExecuteNonQuery(sql);
        }
        public void xoa(String Tendanhmuc)
        {
            String sql = "delete danhmuc where Tendanhmuc = N'" + Tendanhmuc + "'";
            data.ExecuteNonQuery(sql);
        }

    }
}
