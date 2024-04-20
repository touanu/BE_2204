using BE2024.DataAccess.Implementations;
using BE2024.DataAccess.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.BTVN
{
    internal class BTVN_Buoi8
    {
        class Bai1
        {
            internal static void Chay()
            {
                Console.Write("Nhập vào số nhân viên: ");
                int n = Nhap.SoNguyen(false);
                NhanVien[] dsNhanVien = new NhanVien[n];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Nhập vào nhân viên thứ " + (i + 1));
                    Console.Write("Kiểu nhân viên:\n" +
                                "1. Nhân viên fulltime\n" +
                                "2. Nhân viên parttime\n" +
                                "3. Nhân viên thực tập\n" +
                                "Chọn kiểu nhân viên: ");
                    NhanVien nv = new NVFulltime();
                    int loaiNhanVien = Nhap.SoNguyen(false, 1, 3);

                    switch (loaiNhanVien)
                    {
                        case 1:
                            break;
                        case 2:
                            nv = (NVParttime)nv;
                            break;
                        case 3:
                            nv = (NVThuctap)nv;
                            break;
                    }

                    nv.MaNV = $"NV{i:D4}";
                    Console.Write("Họ tên: ");
                    nv.Ten = Nhap.Ten();
                    dsNhanVien[i] = nv;
                }
            }
        }

        class Bai2
        {
            internal static void Chay()
            {
                DsHangHoa dsHangHoa = new DsHangHoa();

            }
            internal static HangHoa NhapHang()
            {
                HangHoa hang = new DienTu();
                int loaiNhanVien = Nhap.SoNguyen(false, 1, 3);

                switch (loaiNhanVien)
                {
                    case 1:
                        break;
                    case 2:
                        hang = new ThucPham();
                        break;
                    case 3:
                        hang = new QuanAo();
                        break;
                }
                Console.Write("Nhập vào mã hàng: ");
                hang.MaHang = Console.ReadLine();
                Console.Write("Nhập vào tên hàng: ");
                hang.TenHang = Nhap.Ten();
                Console.Write("Nhập vào giá tiền: ");
                hang.GiaTien = Nhap.SoNguyen(false);
                Console.Write("Nhập vào ngày hết hạn: ");
                hang.NgayHetHan = Nhap.NgayThang();

                return hang;
            }
        }
    }
}
