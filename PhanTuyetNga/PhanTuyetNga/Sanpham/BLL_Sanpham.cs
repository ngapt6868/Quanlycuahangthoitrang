using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PhanTuyetNga.Sanpham
{
    class BLL_Sanpham
    {
        dal data = new dal();
        public DataTable Selectsanpham()
        {
            String sql = "Select * from sanpham";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
        public DataTable Selectmasp(int masp)
        {
            String sql = "Select * from sanpham where id = '"+masp+"'";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
        public DataTable Selectdanhmuc()
        {
            String sql = "Select Tendanhmuc from danhmuc";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
        public DataTable timkiem(int id)
        {
            String sql = "Select * from sanpham where id = N'" + id + "'";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
        public DataTable timkiem2(String tensp)
        {
            String sql = "Select * from sanpham where Tensp like N'%" + tensp + "%'";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
        public void them(String Tensp,String avartar, int price, String brand, int soluong,String Mota, String tendanhmuc)
        {

            String sql = "insert into sanpham (Tensp,avatar,price, brand, soluong,Mota,Tendanhmuc)" +
                " values ( N'" + Tensp + "',N'"+avartar+"', "+price+",N'"+brand+"',"+soluong+",N'"+Mota+"',N'"+tendanhmuc+"')";
            data.ExecuteNonQuery(sql);

        }
        public void sua(int masp,String Tensp, String avartar, int price, String brand, int soluong, String Mota, String tendanhmuc)
        {

            String sql = "update sanpham set Tensp =  N'" + Tensp + "', avatar = N'" + avartar + "',price =  " + price + ", brand = N'" + brand + "',soluong = " + soluong + ",Mota = N'" + Mota + "',Tendanhmuc = N'" + tendanhmuc + "' where id = '"+masp+"'";
            data.ExecuteNonQuery(sql);
        }
        public void xoa(int id)
        {
            String sql = "delete sanpham where id = N'" + id + "'";
            data.ExecuteNonQuery(sql);
        }
    }
}
