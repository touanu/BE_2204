using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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
                    Console.WriteLine("Ky tu vua nhap khong phai la so! Vui long nhap lai");
                    continue;
                }

                if (input <= 0 & SoAm)
                {
                    Console.WriteLine("So da nhap la so 0 hoac la so am! Vui long nhap lai");
                    continue;
                }

                if (input < min & input > max)
                {
                    Console.WriteLine($"Số đã nhập vượt quá giới hạn cho phép! Vui lòng nhập số từ {min} đến {max}");
                    continue;
                }

                kiemTra = false;
            } while (kiemTra);

            return input;
        }
    }
}
