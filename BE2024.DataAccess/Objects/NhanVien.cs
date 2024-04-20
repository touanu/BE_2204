using System;

namespace BE2024.DataAccess.Objects
{
    public abstract class NhanVien
    {
        public string MaNV { get; set; }
        public string Ten { get; set; }
        public double LuongNgay;
        public TimeSpan SoNgayNghi { get; set; } = TimeSpan.Zero;
        public double TinhLuong()
        {
            DateTime firstDayOfMonth = DateTime.Now.AddDays(-DateTime.Now.Day);
            TimeSpan soNgayDaLam = DateTime.Now - firstDayOfMonth - SoNgayNghi;
            double tongLuong = LuongNgay * soNgayDaLam.TotalDays;

            return tongLuong;
        }
    }

    public class NVFulltime : NhanVien
    {
        public new double LuongNgay => 240000;
    }
    public class NVParttime : NhanVien
    {
        public new double LuongNgay => 150000;
    }

    public class NVThuctap : NhanVien
    {
        public new double LuongNgay => 100000;
    }
}
