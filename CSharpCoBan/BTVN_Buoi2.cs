using System;

/*
    Bài 1: In dãy số nguyên tố nhỏ hơn số được nhập vào từ bàn phím
    Bài 2: Viết chương trình c# Nhập vào 1 chuỗi bất kỳ sau đó hãy đảo ngược chuổi đó
    Bài 3: Đếm số lần xuất hiện của một ký tự trong chuỗi
    Bài 4: sử dụng do-while để Tính giai thừa của một số
    Bài 5: Sử dụng do-while để Đoán số ngẫu nhiên ( nhập vào bàn phím 1 số bất kỳ và so sánh với số được sinh ra từ Class Random trong c#)
    Bài 6: Sử dụng do-while để kiểm tra mật khẩu được nhập từ bàn phím ( Mật khẩu phải từ 6-12 ký tự và có ký tự @) 
 */

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
            Console.Write("Hay doan so ngau nhien: ");
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

            Random rnd = new Random();
            int soNgauNhien = rnd.Next();

            do
            {

            } while (input != soNgauNhien);
        }
    }
}
