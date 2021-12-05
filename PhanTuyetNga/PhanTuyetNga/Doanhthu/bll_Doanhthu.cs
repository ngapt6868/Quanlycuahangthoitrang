using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace PhanTuyetNga
{
    class bll_Doanhthu
    {
        dal data = new dal();

        public DataTable Selecthoadon(int loai)
        {
            DataTable dt = new DataTable();


            if (loai == 1)//ngay
            {
                String sql = "Select id_hoadon,fullname,phone,note,tongtien,phuongthuc,Ngaytao from hoadon hd where cast(Ngaytao as date) = cast(CURRENT_TIMESTAMP as date)";
                dt = data.GetTable(sql);
            }
            if (loai == 2)
            {
                String sql = "Select id_hoadon,fullname,phone,note,tongtien,phuongthuc,Ngaytao from hoadon hd where MONTH(CURRENT_TIMESTAMP) = MONTH(hd.Ngaytao) and YEAR(CURRENT_TIMESTAMP)=YEAR(hd.Ngaytao)";
                dt = data.GetTable(sql);
            }
            if (loai == 3)
            {
                String sql = "Select id_hoadon,fullname,phone,note,tongtien,phuongthuc,Ngaytao from hoadon hd where YEAR(CURRENT_TIMESTAMP)=YEAR(hd.Ngaytao)";
                dt = data.GetTable(sql);
            }
            if (loai == 0)
            {
                String sql = "Select id_hoadon,fullname,phone,note,tongtien,phuongthuc,Ngaytao from hoadon";
                dt = data.GetTable(sql);
            }

            return dt;
        }

        public DataTable Selectchitietdon(int hoadon_id)
        {
            String sql = "Select sanpham_id,dongia,soluong,thanhtien from chitietdon where hoadon_id='" + hoadon_id + "'";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
        public DataTable Selectdoanhthu()
        {
        
            DataTable dt = new DataTable();
           
            return dt;
        }

        public double DoanhThu(int loai) // 1: ngay, 2 thang ,  3 la nam
        {
            double doanhthu = 0;
            if (loai == 1)
            {
                string sql = "execute ThongKeDoanhThuNgay";
                doanhthu = data.ExecuteScalar(sql);
            }

            if (loai == 2)
            {
                string sql = "execute ThongKeDoanhThuThang";
                doanhthu = data.ExecuteScalar(sql);
            }

            if (loai == 3)
            {
                string sql = "execute ThongKeDoanhThuNam";
                doanhthu = data.ExecuteScalar(sql);
            }
            return doanhthu;
        }
        public void xoahd(int id_hoadon)
        {
            String sql = "delete hoadon where id_hoadon = " + id_hoadon + "";
            data.ExecuteNonQuery(sql);
        }
        public void xoachitiethd(int id_hoadon)
        {
            String sql = "delete Chitietdon where hoadon_id = " + id_hoadon + "";
            data.ExecuteNonQuery(sql);
        }

        internal void xoa(object id_hoadon)
        {
            throw new NotImplementedException();
        }
    }
}
