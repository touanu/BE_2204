using System;

namespace CSharpCoBan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] mangMau = {1,5,6,3,2,4};

            var BaiTap = new Buoi3();
            BaiTap.SapXep(ref mangMau);

            Console.ReadKey();
        }
    }
}
