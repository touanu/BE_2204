using System;
using System.Text;

namespace CSharpCoBan
{
    internal class Program
    {
        static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            var BaiTap = new BTVN_Buoi7();
            BaiTap.Menu();
        }
    }
}
