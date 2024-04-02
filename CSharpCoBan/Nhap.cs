using System;

namespace CSharpCoBan
{
    internal class Nhap
    {
        internal static int SoNguyen(bool SoAm = true, int? min = null, int? max = null)
        {
            int input;
            bool kiemTra = true;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.Write("Ky tu vua nhap khong phai la so! Vui long nhap lai");
                    continue;
                }

                if (input <= 0 & SoAm)
                {
                    Console.Write("So da nhap la so 0 hoac la so am! Vui long nhap lai");
                    continue;
                }

                if (input < min & input > max)
                {
                    Console.Write($"Số đã nhập vượt quá giới hạn cho phép! Vui lòng nhập số từ {min} đến {max}");
                    continue;
                }

                kiemTra = false;
            } while (kiemTra);

            return input;
        }

        internal static float SoThuc()
        {
            float input;
            bool kiemTra = false;
            do
            {
                if (!float.TryParse(Console.ReadLine(), out input))
                {
                    Console.Write("Ky tu vua nhap khong phai la so! Vui long nhap lai");
                    continue;
                }

                kiemTra = true;
            } while (!kiemTra);

            return input;
        }
    }
}
