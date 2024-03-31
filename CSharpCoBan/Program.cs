using System;
using System.Collections.Generic;

namespace CSharpCoBan
{
    internal class Program
    {
        static void Main()
        {
            var BaiTap = new BTVN_Buoi3();
            Console.WriteLine("Buoc 1: Nhap vao mang");
            var mang = BaiTap.Bai1();

            Console.WriteLine($@"
                Chon bai:
                    2. In ra mang so le va mang so chan tu mang da nhap o buoc so 1
                    3. Sap xep day tang va giam dan tu mang da nhap o buoc so 1
                    4. Tinh tong cac so chan va tong cac so le tu mang da nhap o buoc so 1
                    5. In ra cac so la so Armstrong tu mang da nhap o buoc so 1.
                    6. Tinh tong cua tat ca cac so nguyen to tu mang da nhap o buoc so 1
                    0. Thoat                

                Lua chon: ");

            int luaChon = Nhap.SoNguyen(false, 0, 6);

            switch (luaChon)
            {
                case 2:
                    BaiTap.Bai2(ref mang);
                    break;
                case 3:
                    BaiTap.Bai3(mang);
                    break;
                case 4:
                    BaiTap.Bai4(ref mang);
                    break;
                case 5:
                    BaiTap.Bai5(ref mang);
                    break;
                case 6:
                    BaiTap.Bai6(ref mang);
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }
    }
}
