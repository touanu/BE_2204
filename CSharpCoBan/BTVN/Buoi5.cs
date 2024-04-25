using System;
using System.Globalization;

namespace CSharpCoBan.BTVN
{
    internal class Buoi5
    {
        internal void Menu()
        {
            Console.Write("Chọn bài tập: ");
            int luaChon = Input.Integer(false, 0, 2);

            switch (luaChon)
            {
                case 1:
                    Bai1.Chay();
                    break;
                case 2:
                    Bai2.Chay();
                    break;
                default:
                    break;
            }
        }

        internal static class Bai1
        {
            public static NhanVien[] dsNhanVien;
            internal static CultureInfo provider = new CultureInfo("vi-VN");

            /*
            public static NhanVien[] dsNhanVien = new NhanVien[]
            {
                new NhanVien("NV01", "Nguyễn Thái", "Tuấn", DateTime.ParseExact("10/10/2003", "dd/MM/yyyy", provider), DateTime.ParseExact("10/10/2022", "dd/MM/yyyy", provider)),
                new NhanVien("NV02", "Nguyễn Văn", "A", DateTime.ParseExact("10/10/2001", "dd/MM/yyyy", provider), DateTime.ParseExact("10/10/2024", "dd/MM/yyyy", provider)),
                new NhanVien("NV03", "Nguyễn Văn", "B", DateTime.ParseExact("10/02/2002", "dd/MM/yyyy", provider), DateTime.ParseExact("22/12/2023", "dd/MM/yyyy", provider)),
                new NhanVien("NV04", "Nguyễn Thái", "C", DateTime.ParseExact("01/01/2004", "dd/MM/yyyy", provider), DateTime.ParseExact("03/03/2018", "dd/MM/yyyy", provider))
            };
            */

            public static void Chay()
            {
                dsNhanVien = NhapDanhSach();
                int luaChon;

                do
                {
                    Console.Clear();
                    Console.Write($@"
                        1. Nhập lại danh sách nhân viên
                        2. Hiện thị toàn bộ nhân viên
                        3. Sắp xếp danh sách theo ngày sinh
                        4. Hiện thị các nhân viên có trên 5 năm làm việc
                        0. Thoát chương trình

                        Lựa chọn: ");

                    luaChon = Input.Integer(false, 0, 4);

                    switch (luaChon)
                    {
                        case 1:
                            dsNhanVien = NhapDanhSach();
                            break;
                        case 2:
                            HienThiDanhSach(dsNhanVien);
                            break;
                        case 3:
                            SapXepTheoNgaySinh();
                            break;
                        case 4:
                            LocNhanVienTheoNamLamViec(5);
                            break;
                        default:
                            break;
                    }
                    Console.ReadKey();
                } while (luaChon != 0);
            }

            public struct NhanVien : IComparable<NhanVien>
            {
                public NhanVien(string maNV, string hoDem, string ten, DateTime ngaySinh, DateTime ngayVaoLam)
                {
                    MaNV = maNV;
                    HoDem = hoDem;
                    Ten = ten;
                    NgaySinh = ngaySinh;
                    NgayVaoLam = ngayVaoLam;
                }

                public string MaNV { get; set; }
                public string HoDem { get; set; }
                public string Ten { get; set; }
                public DateTime NgaySinh { get; set; }
                public DateTime NgayVaoLam { get; set; }

                public int CompareTo(NhanVien other)
                {
                    if (other.NgaySinh == null)
                    {
                        throw new ArgumentNullException("NgaySinh");
                    }
                    TimeSpan khoangThoiGian = NgaySinh - other.NgaySinh;
                    
                    if (khoangThoiGian.TotalSeconds == 0)
                    {
                        return 0;
                    }

                    return khoangThoiGian.TotalMinutes < 0 ? -1 : 1;
                }
            }

            internal static NhanVien[] NhapDanhSach()
            {
                Console.Write("Nhập số lượng nhân viên: ");
                int n = Input.Integer();
                var dsNhanVien = new NhanVien[n];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Nhập thông tin nhân viên thứ " + (i + 1));
                    Console.Write("Mã nhân viên: ");
                    dsNhanVien[i].MaNV = Console.ReadLine();
                    Console.Write("Họ đệm: ");
                    dsNhanVien[i].HoDem = Input.Name();
                    Console.Write("Tên: ");
                    dsNhanVien[i].Ten = Input.Name();
                    Console.Write("Ngày sinh: ");
                    dsNhanVien[i].NgaySinh = Input.Date();
                    Console.Write("Ngày vào làm: ");
                    dsNhanVien[i].NgayVaoLam = Input.Date();
                }

                return dsNhanVien;
            }

            internal static void HienThiDanhSach(NhanVien[] dsNhanVien)
            {
                string format = "{0,-7}{1,-25}{2,-16:C0}{3,-16}";
                string header = string.Format(format,
                            "Mã NV",
                            "Họ tên",
                            "Ngày sinh",
                            "Ngày vào làm");
                Console.WriteLine(header);

                foreach (var item in dsNhanVien)
                {
                    string output = string.Format(provider, format,
                            item.MaNV,
                            item.HoDem + " " + item.Ten,
                            item.NgaySinh.ToShortDateString(),
                            item.NgayVaoLam.ToShortDateString()
                        );
                    Console.WriteLine(output);
                }
            }

            internal static void SapXepTheoNgaySinh()
            {
                Array.Sort(dsNhanVien);
                HienThiDanhSach(dsNhanVien);
            }

            internal static void LocNhanVienTheoNamLamViec(int soNam)
            {
                var nhanvien = Array.FindAll(dsNhanVien, item => 
                    (DateTime.Now - item.NgayVaoLam).TotalDays >= (365 * soNam));
                HienThiDanhSach(nhanvien);
            }
        }

        public static class Bai2
        {
            private static Product[] dsHangHoa;
            internal static CultureInfo provider = new CultureInfo("vi-VN");

            //private static Product[] dsHangHoa = new Product[]
            //{
            //    new Product("A", 20000, DateTime.ParseExact("10/04/2024", "dd/MM/yyyy", provider)),
            //    new Product("B", 30000, DateTime.ParseExact("20/04/2024", "dd/MM/yyyy", provider)),
            //    new Product("Nước rửa mắt", 50000, DateTime.ParseExact("31/12/2024", "dd/MM/yyyy", provider))
            //};

            public static void Chay()
            {
                dsHangHoa = NhapDanhSach();
                int luaChon;

                do
                {
                    Console.Clear();
                    Console.Write($@"
                        1. Nhập lại danh sách hàng hoá
                        2. In ra các sản phẩm hết hạn trong dưới 30 ngày
                        3. In ra các sản phẩm có tên dài hơn 10 ký tự
                        0. Thoát chương trình

                        Lựa chọn: ");

                    luaChon = Input.Integer(false, 0, 3);

                    switch (luaChon)
                    {
                        case 1:
                            dsHangHoa = NhapDanhSach();
                            break;
                        case 2:
                            InSPTheoNgayHetHan(30);
                            break;
                        case 3:
                            InSPTheoDoDaiTen(10);
                            break;
                        default:
                            break;
                    }
                    Console.ReadKey();
                } while (luaChon != 0);
            }

            public struct Product
            {
                public Product(string ten, float giaBan, DateTime ngayHetHan)
                {
                    Name = ten;
                    Price = giaBan;
                    ExpiredDate = ngayHetHan;
                }
                public string Name { get; set; }
                public float Price { get; set; }
                public DateTime ExpiredDate { get; set; }
                
                public TimeSpan ExpiresTime()
                {
                    return ExpiredDate - DateTime.Now;
                }
            }

            internal static Product[] NhapDanhSach()
            {
                Console.Write("Nhập vào số lượng sản phẩm bạn muốn nhập: ");
                int n = Input.Integer(false);
                Product[] products = new Product[n];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Nhập vào thông tin sản phẩm thứ " + (i + 1));
                    Console.Write("Tên sản phẩm: ");
                    products[i].Name = Input.Name();
                    Console.Write("Giá tiền: ");
                    products[i].Price = Input.Float(false);
                    Console.Write("Ngày hết hạn: ");
                    products[i].ExpiredDate = Input.Date();
                }

                return products;
            }

            internal static void InSanPham(Product[] products)
            {
                string format = "{0,-25}{1,-16:C0}{2,-16}{3,-16:0}";
                string header = string.Format(format,
                            "Tên SP",
                            "Giá bán",
                            "Ngày hết hạn",
                            "Số ngày còn lại");
                Console.WriteLine(header);
                
                foreach (var item in products)
                {
                    string output = string.Format(provider, format,
                            item.Name,
                            item.Price,
                            item.ExpiredDate.ToShortDateString(),
                            item.ExpiresTime().TotalDays
                        );
                    Console.WriteLine(output);
                }
            }

            internal static void InSPTheoNgayHetHan(double NgayHetHan)
            {
                var products = Array.FindAll(dsHangHoa, item => item.ExpiresTime().TotalDays < NgayHetHan);
                InSanPham(products);
            }

            internal static void InSPTheoDoDaiTen(int DoDaiTen)
            {
                var products = Array.FindAll(dsHangHoa, item => item.Name.Length > DoDaiTen);
                InSanPham(products);
            }
        }
    }
}
