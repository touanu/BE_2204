using System;

/*
    Bài 1: Viết chương trình c# để tính tổng 2 số được nhập từ bàn phím
    Bài 2: Viết chương trình c# để tính tổng các số chẵn nhỏ hơn số được nhập từ bàn phím 
 */

namespace CSharpCoBan
{
    internal class BTVN_Buoi1
    {
        internal void Bai1()
        {
            Console.WriteLine("Nhap vao so thu nhat: ");
            int soThuNhat = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhap vao so thu hai: ");
            int soThuHai = Convert.ToInt32(Console.ReadLine());

            int tong = soThuNhat + soThuHai;

            Console.WriteLine("Tong cua hai so la: " + tong);
        }

        internal void Bai2()
        {
            Console.Write("Nhap so de tinh tong: ");
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                Console.WriteLine("Ky tu vua nhap khong phai la so!");
                return;
            }

            if (input <= 0)
            {
                Console.WriteLine("So da nhap la so 0 hoac la so am! Vui long nhap so duong");
                return;
            }

            int tong = 0;

            for (int i = 0; i < input; i++)
            {
                if (i % 2 == 0)
                {
                    tong += i;
                }
            }

            Console.WriteLine("Tong cac so chan nho hon so duoc nhap la " + tong);
        }
    }
}
