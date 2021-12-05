using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PhanTuyetNga.Hoadon
{
    class bll_hoadon

    {        
        dal data = new dal();
        public DataTable Selectdanhmuc()
        {
            String sql = "Select * from hoadon";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
        public DataTable Selectsanpham()
        {
            String sql = "Select id,price from sanpham";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
        public DataTable Selectslsanpham(int id)
        {
            String sql = "Select soluong from sanpham where id = " + id + "";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
        public DataTable Selectsanphammua()
        {
            String sql = "Select * from bangtam";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
        public DataTable Selectsanpham(int id)
        {

            String sql = "Select price from sanpham where id='" + id + "'";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
        public void updatesoluong(int  id , int sl)
        {
            String sql = "update sanpham set soluong = soluong - " + sl + " where id = " + id + "";
            data.ExecuteNonQuery(sql);
        }
        public DataTable Selectmaid()
        {

            String sql = "Select max(id_hoadon) from hoadon ";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
        public void luu(int id, int price, int soluong, int thanhtien)
        {

            String sql = "insert into bangtam values ( N'" + id + "'," + price + ", " + soluong + " , "+thanhtien+")";
            data.ExecuteNonQuery(sql);
        }
        public void inhd( String fullname, String phone, String note, int tongtien,String phuongthuc)
        {

            String sql = "insert into hoadon(fullname,phone,note,tongtien,phuongthuc) values (N'" + fullname + "', '" + phone + "' ," +
                " N'" + note + "','" + tongtien + "',N'" + phuongthuc + "' )";
            data.ExecuteNonQuery(sql);
        }
        public void chitietdon(int hoadon_id, int sanpham_id,int dg, int sl, int tt)
        {

            String sql = "insert into chitietdon values (  '" + hoadon_id + "' ,'" + sanpham_id + "' ,"+dg+","+sl+", "+tt+" )";
            data.ExecuteNonQuery(sql);
        }
        public void huy(int id)
        {
            String sql = "delete bangtam where masp = " + id + "";
            data.ExecuteNonQuery(sql);
        }
        public void xoabangtam()
        {
            String sql = "delete bangtam";
            data.ExecuteNonQuery(sql);
        }
    }
}
