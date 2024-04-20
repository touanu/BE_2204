using BE2024.DataAccess.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE2024.DataAccess.Implementations;

namespace CSharpCoBan.BTVN
{
    internal static class BTVN_Buoi9
    {
        

        public static void Bai3()
        {
            ProductManager productManager = new ProductManager();
            Console.WriteLine(productManager.ShowAvailableProducts());

            Console.WriteLine("Nhập vào các sản phẩm bạn muốn mua");
            while (true)
            {
                Product product = new Product();
                Console.WriteLine("Mã SP: ");
                string productID = Console.ReadLine();
            }
        }
    }
}
