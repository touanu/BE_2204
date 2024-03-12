using System;

namespace CSharpCoBan
{
    internal class Buoi2
    {
        internal void InThang31Ngay()
        {
            Console.Write("Cac thang co 31 ngay la:");

            for (int i = 1; i < 12; i++)
            {
                switch (i)
                {
                    case 2:
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        break;
                    default:
                        Console.Write(" " + i);
                        break;
                }
            }
        }

        internal void TinhTongNhoHon()
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
                tong += i;
            }
            Console.WriteLine("Tong (theo vong lap for) la " + tong);

            tong = 0; int j = 0;
            do
            {
                tong += j;
                j++;
            }
            while (j < input);
            Console.WriteLine("Tong (theo vong lap while) la " + tong);
        }
    }
}
