using System;

namespace CSharpCoBan
{
    internal class Bai1
    {
        internal void TinhTong()
        {
            Console.WriteLine("Nhap vao so thu nhat: ");
            int soThuNhat = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhap vao so thu hai: ");
            int soThuHai = Convert.ToInt32(Console.ReadLine());

            int tong = soThuNhat + soThuHai;

            Console.WriteLine("Tong cua hai so la: " + tong);
        }
    }
}
