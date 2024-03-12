using System;

namespace CSharpCoBan
{
    internal class Bai2
    {
        internal void TinhTong()
        {
            Console.Write("Nhap so de tinh tong: ");
            int input = Convert.ToInt32(Console.ReadLine());

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
