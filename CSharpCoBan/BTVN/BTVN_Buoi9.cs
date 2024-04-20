using System;
using BE2024.DataAccess.Implementations;
using BE2024.DataAccess.Objects;

namespace CSharpCoBan.BTVN
{
    internal static class BTVN_Buoi9
    {
        

        public static void Bai3()
        {
            ProductManager productManager = new ProductManager();
            Console.WriteLine(productManager.ShowAvailableProducts());

            Console.WriteLine("Nhập mã 0 để dừng việc nhập.");
            Console.WriteLine("Nhập vào các sản phẩm bạn muốn mua");

            while (true)
            {
                Console.Write("Mã SP: ");
                string productID = Console.ReadLine();

                if (productID == "0")
                {
                    break;
                }

                Console.Write("Số lượng: ");
                int quantity = Nhap.SoNguyen(false);

                ReturnData buy = productManager.BuyProduct(productID, quantity);
                Console.WriteLine(buy.Message);
            }

            string buyList = productManager.ShowBuyProducts();
            Console.WriteLine(buyList);
        }
    }
}
