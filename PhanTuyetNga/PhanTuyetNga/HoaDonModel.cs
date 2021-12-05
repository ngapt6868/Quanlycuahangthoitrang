using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanTuyetNga
{
    public class HoaDonModel
    {
        public string MaHD { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }

        public List<SanPhamModel> sanphams { get; set; }
    }

    public class SanPhamModel
    {
        public string MaSP { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
    }
}
