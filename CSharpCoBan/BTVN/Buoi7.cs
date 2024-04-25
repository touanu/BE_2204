using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CSharpCoBan.BTVN
{
    internal class Buoi7
    {
        public void Menu()
        {
            Console.Write("Chọn bài tập: ");
            int luaChon = Input.Integer(false, 0, 3);

            switch (luaChon)
            {
                case 2:
                    Bai2.Chay();
                    break;
                case 3:
                    Bai3.Chay();
                    break;
                default:
                    break;
            }
        }
        internal static class Bai1
        {
            internal class Book
            {
                internal string Title { get; set; }
                internal string Author { get; set; }
                internal string ISBN { get; set; }
                internal float Price { get; set; }
            }

            internal class Library
            {
                private readonly List<Book> books = new List<Book>();
                private readonly List<Book> borrowedBooks = new List<Book>();
                internal void Add(string title, string author, string id, float price)
                {
                    Book book = new Book
                    {
                        Title = title,
                        Author = author,
                        ISBN = id,
                        Price = price
                    };

                    books.Add(book);
                }
                internal Book SearchbyID(string bookId)
                {
                    try
                    {
                        return books.Single(item => item.ISBN == bookId);
                    }
                    catch
                    {
                        Console.WriteLine("Không tìm thấy sách yêu cầu trong thư viện!");
                        return null;
                    }
                }
                internal List<Book> SearchbyAuthor(string author)
                {
                    return books.FindAll(item => item.Author == author);
                }
                internal void BorrowBook(string id)
                {
                    Book borrowed = SearchbyID(id);
                    books.Remove(borrowed);
                    borrowedBooks.Add(borrowed);
                }
                internal void ReturnBook(string id)
                {
                    Book borrowed;
                    try
                    {
                        borrowed = borrowedBooks.Single(item => item.ISBN == id);
                    }
                    catch
                    {
                        Console.WriteLine("Quyển sách này chưa được mượn hoặc không tồn tại!");
                        return;
                    }
                    
                    borrowedBooks.Remove(borrowed);
                    books.Add(borrowed);
                    
                }
            }
        }

        internal class Bai2
        {
            private static NhanVien[] dsNhanVien;
            public static void Chay()
            {
                dsNhanVien = NhapNhanVien();
                int luaChon;
                do
                {
                    Console.Clear();
                    Console.Write($@"
                        1. Nhập lại danh sách nhân viên
                        2. Tính toán lương cho nhân viên
                        0. Thoát chương trình

                        Lựa chọn: ");

                    luaChon = Input.Integer(false, 0, 3);

                    switch (luaChon)
                    {
                        case 1:
                            dsNhanVien = NhapNhanVien();
                            break;
                        case 2:
                            TinhToanBoLuong();
                            break;
                        default:
                            break;
                    }

                    Console.ReadLine();
                } while (luaChon != 0);
            }
            private static NhanVien TaoNhanVien(int loaiNhanVien)
            {
                switch (loaiNhanVien)
                {
                    case 1:
                        return new NVFulltime();
                    case 2:
                        return new NVParttime();
                    case 3:
                        return new NVThuctap();
                    default:
                        return null;
                }
            }
            private static NhanVien[] NhapNhanVien()
            {
                Console.Write("Nhập vào số nhân viên: ");
                int n = Input.Integer(false);
                NhanVien[] dsNhanVien = new NhanVien[n];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Nhập vào nhân viên thứ " + (i+1));
                    Console.Write("Kiểu nhân viên:\n" +
                                "1. Nhân viên fulltime\n" +
                                "2. Nhân viên parttime\n" +
                                "3. Nhân viên thực tập\n" +
                                "Chọn kiểu nhân viên: ");

                    NhanVien nv = TaoNhanVien(Input.Integer(false, 1, 3));

                    nv.MaNV = $"NV{i:D4}";
                    Console.Write("Họ tên: ");
                    nv.Ten = Input.Name();
                    dsNhanVien[i] = nv;
                    Console.WriteLine();
                }

                return dsNhanVien;
            }

            private static void TinhToanBoLuong()
            {
                CultureInfo provider = new CultureInfo("vi-VN");
                Console.WriteLine("\nBảng lương tháng");
                string format = "{0,-27}{1,-16:C0}{2,-12}";
                string header = string.Format(format, "Họ tên", "Lương", "Số ngày nghỉ");
                Console.WriteLine(header);

                foreach (var item in dsNhanVien)
                {
                    string context = string.Format(
                        provider,
                        format, 
                        item.Ten, item.TinhLuong(), item.SoNgayNghi.TotalDays
                    );
                    
                    Console.WriteLine(context);
                }
            }

            abstract class NhanVien
            {
                internal string MaNV { get; set; }
                internal string Ten { get; set; }
                internal abstract double LuongNgay { get; }
                internal TimeSpan SoNgayNghi { get; set; } = TimeSpan.Zero;
                internal double TinhLuong()
                {
                    DateTime firstDayOfMonth = DateTime.Now.AddDays(-DateTime.Now.Day);
                    TimeSpan soNgayDaLam = DateTime.Now - firstDayOfMonth - SoNgayNghi;
                    double tongLuong = LuongNgay * soNgayDaLam.TotalDays;

                    return tongLuong;
                }
            }
            private class NVFulltime : NhanVien
            {
                internal override double LuongNgay => 240000;
            }
            private class NVParttime : NhanVien
            {
                internal override double LuongNgay => 150000;
            }

            private class NVThuctap : NhanVien
            {
                internal override double LuongNgay => 100000;
            }
        }
        internal static class Bai3
        {
            internal static readonly Products products = new Products();
            public static void Chay()
            {
                AddNewProduct();
                int choose;
                do
                {
                    Console.Clear();
                    Console.Write($@"
                        1. Nhập lại danh sách sản phẩm
                        2. Xoá một sản phẩm
                        3. Cập nhật lại một sản phẩm
                        4. Xoá nhiều sản phẩm cùng lúc
                        0. Thoát chương trình

                        Lựa chọn: ");

                    choose = Input.Integer(false, 0, 4);

                    switch (choose)
                    {
                        case 1:
                            AddNewProduct();
                            break;
                        case 2:
                            DeleteProduct();
                            break;
                        case 3:
                            UpdateProduct();
                            break;
                        case 4:
                            DeleteMultipleProduct();
                            break;
                        default:
                            break;
                    }

                    Console.ReadLine();
                } while (choose != 0);
            }

            private static void AddNewProduct()
            {
                Console.Write("Nhập số lượng sản phẩm: ");
                int n = Input.Integer();

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Nhập vào sản phẩm thứ " + (i + 1));
                    string idSP = $"P{products.Count+1:D4}";
                    Console.Write("Tên sản phẩm: ");
                    string tenSP = Input.Name();
                    Console.Write("Giá bán: ");
                    float giaBan = Input.Float(false);

                    products.Insert(idSP, tenSP, giaBan);
                }
            }

            private static void DeleteProduct()
            {
                Console.Write("Nhập vào tên hoặc id của sản phẩm: ");
                string value = Console.ReadLine();
                Product product = products.Search(value);

                if (product == null)
                {
                    Console.WriteLine("Sản phẩm vừa nhập không tồn tại!");
                    return;
                }

                products.Delete(product);
            }

            private static void UpdateProduct()
            {
                Console.Write("Nhập vào ID của sản phẩm: ");
                string id = Console.ReadLine();

                if (products.Search(id) == null)
                {
                    Console.WriteLine("Sản phẩm vừa nhập không tồn tại!");
                    return;
                }

                Console.Write("Tên sản phẩm: ");
                string name = Input.Name();
                Console.Write("Giá bán: ");
                float price = Input.Float(false);

                products.Update(id, name, price);
            }

            private static void DeleteMultipleProduct()
            {
                List<Product> deleteProducts = new List<Product>();
                Console.WriteLine("Nhập 0 để dừng việc nhập sản phẩm.");
                Console.WriteLine("Nhập vào ID hoặc tên của các sản phẩm:");
                do
                {
                    string value = Console.ReadLine();

                    if (value == "0")
                        break;

                    Product product = products.Search(value);

                    if (product == null)
                    {
                        Console.WriteLine("Sản phẩm vừa nhập không tồn tại!");
                        continue;
                    }

                    deleteProducts.Add(product);
                } while (true);

                foreach (Product item in deleteProducts)
                {
                    products.Delete(item);
                }
            }

            internal interface IProduct
            {
                void Insert(string id, string name, float price);
                void Update(string id, string name, float price);
                void Delete(Product product);
                Product Search(string searchValue);
            }
            internal class Product
            {
                internal string ProductId { get; set; }
                internal string ProductName { get; set; }
                internal float Price { get; set; }
            }
            internal class Products : IProduct
            {
                public int Count
                { 
                    get
                    {
                        return ListProduct.Count;
                    }
                }
                private List<Product> ListProduct { get; set; } = new List<Product>();

                public void Insert(string id, string name, float price)
                {
                    Product product = new Product()
                    {
                        ProductId = id,
                        ProductName = name,
                        Price = price
                    };

                    ListProduct.Add(product);
                }

                public void Update(string id, string name, float price)
                {
                    int index = ListProduct.FindIndex(item => item.ProductId == id);
                    ListProduct[index].ProductName = name;
                    ListProduct[index].Price = price;
                }

                public void Delete(Product product)
                {
                    ListProduct.Remove(product);
                }

                public Product Search(string searchValue)
                {
                    if (string.IsNullOrEmpty(searchValue))
                        return null;

                    try
                    {
                        return ListProduct.Single(item => item.ProductId == searchValue);
                    } catch {
                        return ListProduct.Find(item => item.ProductName == searchValue);
                    }
                }
            }

        }
    }
}
