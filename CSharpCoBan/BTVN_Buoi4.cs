using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CSharpCoBan
{
    internal class BTVN_Buoi4
    {
        internal void Menu()
        {
            Console.Write("Chọn bài tập: ");
            int luaChon = Nhap.SoNguyen(false, 0, 3);

            switch (luaChon)
            {
                case 1:
                    Bai1.Chay();
                    break;
                case 2:
                    Bai2.Chay();
                    break;
                case 3:
                    Bai3.Chay();
                    break;
                default:
                    break;
            }
        }

        internal class Bai1
        {
            public struct Sach
            {
                public string TieuDe { get; set; }
                public string TacGia { get; set; }
                public int Nam { get; set; }

                public override string ToString()
                {
                    return $"{TieuDe} cua {TacGia}";
                }
            }

            internal static void Chay()
            {
                var TuSach = new List<Sach>();
                int luaChon;

                do
                {
                    Console.Clear();
                    Console.Write($@"
                        1. Them sach moi
                        2. Hien thi danh sach cac sach da them
                        3. Tim kiem sach theo tieu de
                        0. Thoat chuong trinh

                        Lua chon: ");

                    luaChon = Nhap.SoNguyen(false, 0, 3);

                    switch (luaChon)
                    {
                        case 1:
                            ThemSachVaoDS(ref TuSach);
                            break;
                        case 2:
                            InToanBoSach(TuSach);
                            break;
                        case 3:
                            TimKiemSach(TuSach);
                            break;
                        default:
                            break;
                    }

                    Console.ReadLine();
                } while (luaChon != 0);
            }

            internal static void ThemSachVaoDS(ref List<Sach> TuSach)
            {
                var Sach = new Sach();
                Console.WriteLine("\nNhap vao cac thong tin cua sach");
                Console.Write("Tieu de: ");
                Sach.TieuDe = Nhap.Ten();
                Console.Write("Tac Gia: ");
                Sach.TacGia = Nhap.Ten();
                Console.Write("Nam xuat ban: ");
                Sach.Nam = Nhap.SoNguyen(false, 0, DateTime.Now.Year);

                TuSach.Add(Sach);
                Console.WriteLine($"Da them quyen sach {Sach.TieuDe} vao tu sach!");
            }

            internal static void InToanBoSach(List<Sach> TuSach)
            {
                foreach (var sach in TuSach)
                {
                    Console.WriteLine("\nCac sach co trong tu sach:");
                    Console.WriteLine(sach.ToString() + "\n");
                }
            }

            internal static void TimKiemSach(List<Sach> TuSach)
            {
                Console.Write("\nNhap ten sach can tim: ");
                string TieuDe = Console.ReadLine();

                foreach (var sach in TuSach)
                {
                    if (sach.TieuDe == TieuDe)
                    {
                        Console.WriteLine("Quyen sach " + sach.TieuDe);
                        Console.WriteLine("Tac gia " + sach.TacGia);
                        Console.WriteLine("Xuat ban nam " + sach.Nam);
                    }
                }
            }
        }

        internal class Bai2
        {
            public struct HocSinh
            {
                public string HoTen { get; set; }
                public int Tuoi { get; set; }
                public float DiemTB { get; set; }
            }

            internal static void Chay()
            {
                var DSHocSinh = new List<HocSinh>();
                int luaChon;

                do
                {
                    Console.Clear();
                    Console.Write($@"
                        1. Them hoc sinh moi
                        2. Hien thi danh sach cac hoc sinh da them
                        3. Tim kiem hoc sinh theo ten
                        0. Thoat chuong trinh

                        Lua chon: ");

                    luaChon = Nhap.SoNguyen(false, 0, 3);

                    switch (luaChon)
                    {
                        case 1:
                            ThemSachVaoDS(ref DSHocSinh);
                            break;
                        case 2:
                            InToanBoHS(DSHocSinh);
                            break;
                        case 3:
                            TimKiemHS(DSHocSinh);
                            break;
                        default:
                            break;
                    }

                    Console.ReadLine();
                } while (luaChon != 0);
            }

            internal static void ThemSachVaoDS(ref List<HocSinh> DSHocSinh)
            {
                var HS = new HocSinh();
                Console.WriteLine("\nNhap vao cac thong tin cua sach");
                Console.Write("Tieu de: ");
                HS.HoTen = Console.ReadLine();
                Console.Write("Tac Gia: ");
                HS.Tuoi = Nhap.SoNguyen(false, 0, 122);
                Console.Write("Nam xuat ban: ");
                HS.DiemTB = Nhap.SoThuc();

                DSHocSinh.Add(HS);
                Console.WriteLine($"Da them {HS.HoTen} vao danh sach!");
            }

            internal static void InToanBoHS(List<HocSinh> DSHocSinh)
            {
                foreach (var hs in DSHocSinh)
                {
                    Console.WriteLine("\nTat ca hoc sinh co trong danh sach:");
                    Console.WriteLine(hs.HoTen + "\n");
                }
            }

            internal static void TimKiemHS(List<HocSinh> DSHocSinh)
            {
                Console.WriteLine("\nNhap ho ten cua hoc sinh can tim: ");
                string HoTen = Console.ReadLine();

                foreach (var hs in DSHocSinh)
                {
                    if (hs.HoTen == HoTen)
                    {
                        Console.WriteLine("Em " + hs.HoTen);
                        Console.WriteLine(hs.Tuoi + "tuoi");
                        Console.WriteLine("Diem trung binh: " + hs.DiemTB);
                    }
                }
            }
        }

        internal class Bai3
        {
            private static HoaDon[] dsHoaDon;
            internal static CultureInfo provider = new CultureInfo("vi-VN");
            
            /* For faster test
            internal static HoaDon[] dsHoaDon = new HoaDon[]
            {
                    new HoaDon("HD01", DateTime.ParseExact("10/10/2016", "dd/MM/yyyy", provider), 100000, 1000, 1, "Tuấn"),
                    new HoaDon("HD02", DateTime.ParseExact("15/08/2010", "dd/MM/yyyy", provider), 1000000, 200000, 1, "Thái"),
                    new HoaDon("HD03", DateTime.ParseExact("10/01/2024", "dd/MM/yyyy", provider), 200000, 0, 0, "Nguyễn"),
                    new HoaDon("HD04", DateTime.ParseExact("06/03/2024", "dd/MM/yyyy", provider), 100000, 1000, 1, "Kek")
            };
            */

            public struct HoaDon
            {
                public HoaDon(string maHD, DateTime ngayPH, double tongTien, double soTienNo,int ttNo, string tenKH)
                {
                    MaHoaDon = maHD;
                    NgayPhatHanh = ngayPH;
                    TongTien = tongTien;
                    SoTienNo = soTienNo;
                    TrangThaiNo = ttNo;
                    TenKhachHang = tenKH;
                }
                public string MaHoaDon { get; set; }
                public DateTime NgayPhatHanh {  get; set; }
                public double TongTien {  get; set; }
                public double SoTienNo {  get; set; }
                public int TrangThaiNo { get; set; }
                public string TenKhachHang { get; set; }
            }

            internal static void Chay()
            {
                dsHoaDon = NhapHoaDon();
                int luaChon;

                do
                {
                    Console.Clear();
                    Console.Write($@"
                        1. Xoá nợ cho 1 hoá đơn
                        2. Xuất danh sách hoá đơn
                        3. Hiện thị hoá đơn còn nợ
                        4. Xuất ra tệp tin txt
                        0. Thoát chương trình

                        Lựa chọn: ");

                    luaChon = Nhap.SoNguyen(false, 0, 4);

                    switch (luaChon)
                    {
                        case 1:
                            XoaNo();
                            break;
                        case 2:
                            XuatDanhSach();
                            break;
                        case 3:
                            HienThiNo();
                            break;
                        case 4:
                            XuatThanhFile();
                            break;
                        default:
                            break;
                    }
                    Console.ReadKey();
                } while (luaChon != 0);
            }

            internal static HoaDon[] NhapHoaDon()
            {
                Console.Write("Nhập số lượng hoá đơn: ");
                int n = Nhap.SoNguyen();
                HoaDon[] dsHoaDon = new HoaDon[n];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("\nNhập hoá đơn thứ " + (i+1));
                    Console.Write("Mã hoá đơn: ");
                    dsHoaDon[i].MaHoaDon = Console.ReadLine();
                    Console.Write("Ngày phát hành: ");
                    dsHoaDon[i].NgayPhatHanh = Nhap.NgayThang();
                    Console.Write("Tổng tiền: ");
                    dsHoaDon[i].TongTien = Nhap.SoNguyen();
                    Console.Write("Số tiền nợ: ");
                    dsHoaDon[i].SoTienNo = Nhap.SoNguyen();
                    dsHoaDon[i].TrangThaiNo = dsHoaDon[i].SoTienNo == 0 ? 0 : 1;
                    Console.Write("Tên khách hàng: ");
                    dsHoaDon[i].TenKhachHang = Nhap.Ten();
                }

                return dsHoaDon;
            }


            internal static void XoaNo()
            {
                Console.Write("Nhập mã hoá đơn: ");
                string maHoaDon = Console.ReadLine();

                if (maHoaDon.Length == 0)
                {
                    Console.WriteLine("Mã hoá đơn không được để trống!");
                    return;
                }

                int index = TimTheoMaHoaDon(maHoaDon);
                if (index == -1)
                {
                    Console.WriteLine("Mã hoá đơn này không tồn tại!");
                    return;
                }

                dsHoaDon[index].SoTienNo = 0;
                dsHoaDon[index].TrangThaiNo = 0;
                Console.WriteLine("Đã xoá nợ cho hoá đơn " + dsHoaDon[index].MaHoaDon);
            }

            internal static void XuatDanhSach()
            {
                Console.WriteLine("Để trống để xuất toàn bộ");
                Console.Write("Nhập mã hoá đơn: ");
                string maHoaDon = Console.ReadLine();

                if (maHoaDon.Length == 0)
                {
                    Console.WriteLine("Các hoá đơn còn nợ:");
                    Console.WriteLine(InHoaDon(1));
                    Console.WriteLine("Các hoá đơn hết nợ:");
                    Console.WriteLine(InHoaDon(0));
                    return;
                }

                int index = TimTheoMaHoaDon(maHoaDon);
                if (index == -1)
                {
                    Console.WriteLine("Mã hoá đơn này không tồn tại!");
                    return;
                }

                InHoaDon(maHoaDon);
            }

            internal static void HienThiNo()
            {
                Console.WriteLine("Các hoá đơn còn nợ 30 ngày:");
                Console.WriteLine(InHoaDon(1, TimeSpan.FromDays(30)));
                Console.WriteLine("Các hoá đơn còn nợ 60 ngày:");
                Console.WriteLine(InHoaDon(1, TimeSpan.FromDays(60)));
                Console.WriteLine("Các hoá đơn còn nợ 90 ngày:");
                Console.WriteLine(InHoaDon(1, TimeSpan.FromDays(90)));
            }

            private static void XuatThanhFile()
            {
                string hoaDonKhongNo = InHoaDon(0);
                FileInfo tepHoaDon = new FileInfo("HoaDonKhongNo.txt");
                
                if (!tepHoaDon.Exists)
                {
                    tepHoaDon.Create();
                }

                using (var sw = tepHoaDon.AppendText())
                {
                    sw.WriteLine(hoaDonKhongNo);
                }

                Console.WriteLine("Đã ghi hoá đơn ra tệp tin\n" + tepHoaDon.FullName);
            }

            private static int TimTheoMaHoaDon(string maHoaDon)
            {
                for (int i = 0; i < dsHoaDon.Length; i++)
                {
                    if (dsHoaDon[i].MaHoaDon == maHoaDon)
                    {
                        return i;
                    }
                }

                return -1;
            }

            internal static string InHoaDon(int? ttNo = null, TimeSpan? thoiGianNo = null)
            {
                string format = "{0,12}{1,18}{2,16:C0}{3,16}{4,20}";
                StringBuilder builder = new StringBuilder();

                string header = string.Format(format,
                        "Mã hoá đơn",
                        "Ngày phát hành",
                        "Tổng tiền",
                        "Số tiền nợ",
                        "Tên khách hàng");
                builder.AppendLine(header);

                foreach (var item in dsHoaDon)
                {
                    if (ttNo != null & item.TrangThaiNo != ttNo)
                    {
                        continue;
                    }

                    if (thoiGianNo != null & DateTime.Now - item.NgayPhatHanh != thoiGianNo)
                    {
                        continue;
                    }

                    string output = string.Format(provider, format,
                        item.MaHoaDon,
                        item.NgayPhatHanh.ToShortDateString(),
                        item.TongTien,
                        item.SoTienNo,
                        item.TenKhachHang
                    );

                    builder.AppendLine(output);
                }

                return builder.ToString();
            }

            internal static void InHoaDon(string MaHD)
            {
                string format = "Mã hoá đơn: {0,12}\n" +
                                "Ngày phát hành {1,18}\n" +
                                "Tổng tiền: {2,16:C0}\n" + 
                                "Số tiền nợ: {3,16}\n" + 
                                "Tên khách hàng: {4,20}\n";

                int index = TimTheoMaHoaDon(MaHD);
                
                string output = string.Format(provider, format,
                        dsHoaDon[index].MaHoaDon,
                        dsHoaDon[index].NgayPhatHanh.ToShortDateString(),
                        dsHoaDon[index].TongTien,
                        dsHoaDon[index].SoTienNo,
                        dsHoaDon[index].TenKhachHang
                    );

                Console.WriteLine(output);
            }
        }
    }
}
