// See https://aka.ms/new-console-template for more information
using Storage.DataAccess.Objects;
using Storage.DataAccess.Services;

ProductServices storageServices = new();
Product product = new();

Console.WriteLine("Nhập tên sản phẩm: ");
product.ProductName = Console.ReadLine();