using System;

namespace BE2024.DataAccess.Objects
{
    public abstract class HangHoa
    {
        public string MaHang { get; set; }
        public string TenHang {  get; set; }
        public double GiaTien { get; set; }
        public DateTime NgaySX { get; set; }
        public DateTime? NgayHetHan { get; set; }
    }

    public class DienTu : HangHoa
    {
        
    }

    public class ThucPham : HangHoa
    {

    }

    public class QuanAo : HangHoa
    {

    }
}
