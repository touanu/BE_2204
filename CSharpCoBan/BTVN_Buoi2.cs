using System;

namespace CSharpCoBan
{
    internal class BTVN_Buoi2
    {
        internal void Bai1()
        {
            Console.Write("Nhap vao so: ");
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                Console.WriteLine("Ky tu vua nhap khong phai la so!");
                return;
            }

            if (input <= 0)
            {
                Console.WriteLine("So da nhap la so 0 hoac la so am! Vui long nhap mot so duong");
                return;
            }

            Console.WriteLine("Cac so nguyen to co trong khoang tu 1 den " +  input + " la:");
            for (int i = 0; i < input; i++)
            {
                if (SoNguyenTo(i))
                {
                    Console.Write(i + "  ");
                }
            }
        }

        internal bool SoNguyenTo(int n)
        {
            for (int j = 2; j < n / 2; j++)
            {
                if (n % j == 0)
                {
                    return false;
                }
            }

            return true;
        }

        internal void Bai2()
        {
            Console.WriteLine("Nhap vao mot chuoi bat ki: ");
            string input = Console.ReadLine();
            int n = input.Length;

            Console.WriteLine("Chuoi sau khi dao nguoc la: ");
            for (int i = n-1; i >= 0; i--)
            {
                Console.Write(input[i]);
            }
        }

        internal void Bai3()
        {
            Console.WriteLine("Nhap vao mot chuoi bat ki: ");
            string input = Console.ReadLine();
            Console.WriteLine("Nhap vao 1 ky tu can dem: ");
            var kyTu = Console.ReadLine()[0];
            int dem = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == kyTu)
                {
                    dem++;
                }
            }

            Console.WriteLine("Ky tu " + kyTu + " da xuat hien " + dem + " lan");
        }

        internal void Bai4()
        {
            Console.Write("Nhap vao so: ");
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                Console.WriteLine("Ky tu vua nhap khong phai la so!");
                return;
            }

            if (input <= 0)
            {
                Console.WriteLine("So da nhap la so 0 hoac la so am! Vui long nhap mot so duong");
                return;
            }

            int tong = 1;
            int i = 1;

            do
            {
                tong *= i;
                i++;
            } while (i <= input);

            Console.WriteLine("Giai thua cua " + input + " la " + tong);
        }

        internal void Bai5()
        {
            Random rnd = new Random();
            int soNgauNhien = rnd.Next(0, 1000);

            int input;

            do
            {
                Console.Write("Hay doan so: ");
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Ky tu vua nhap khong phai la so!");
                    continue;
                }

                if (input < soNgauNhien)
                {
                    Console.WriteLine("Sai! So ngau nhien lon hon so da nhap!");
                    continue;
                }

                if (input > soNgauNhien)
                {
                    Console.WriteLine("Sai! So ngau nhien nho hon so da nhap!");
                }
            } while (input != soNgauNhien);

            Console.WriteLine("Chinh xac!");
        }

        internal void Bai6() 
        {
            string matKhau;
            bool valid = false;

            do
            {
                Console.Write("Mat khau: ");
                matKhau = Console.ReadLine();

                if (matKhau.Length < 6 || matKhau.Length > 12)
                {
                    Console.WriteLine("Mat khau phai tu 6 den 12 ky tu! Vui long nhap lai.");
                    continue;
                }

                if (!matKhau.Contains("@"))
                {
                    Console.WriteLine("Mat khau phai chua ky tu '@'! Vui long nhap lai.");
                    continue;
                }

                valid = true;
            } while (!valid);

            Console.WriteLine("Mat khau hop le!");
        }
    }
}
