using System;
using CommonLibs;
using BE2024.DataAccess.Implementations;
using BE2024.DataAccess.Objects;

namespace CSharpCoBan.BTVN
{
    internal static class Buoi9
    {
        
        public static void Bai2()
        {
            StudentRegister studentRegister = new StudentRegister();
            int luaChon;
            do
            {
                Console.Clear();
                Console.Write($@"
                        1. Nhập thông tin cho khoá học
                        2. Đăng kí cho học viên
                        3. Hiển thị danh sách học viên đăng kí
                        0. Thoát chương trình

                        Lựa chọn: ");

                luaChon = Input.Integer(false, 0, 3);

                switch (luaChon)
                {
                    case 1:
                        Console.WriteLine("Nhập vào thông tin khoá học");
                        Console.Write("Tên khoá học: ");
                        string courseName = Console.ReadLine();
                        Console.Write("Mô tả khoá học: ");
                        string courseDesciption = Console.ReadLine();
                        Console.Write("Học phí: ");
                        double courseTuition = Input.Integer();
                        Console.Write("Ngày khai giảng (dạng dd/MM/yyyy): ");
                        DateTime courseOpenDate = Input.Date();
                        
                        ReturnData courseReturn = studentRegister.UpdateCourseInfo(
                            courseName, courseDesciption, courseTuition, courseOpenDate);
                        Console.WriteLine(courseReturn.Message);
                        break;
                    case 2:
                        Student student = new Student();
                        Console.WriteLine("Nhập vào thông tin của học viên");
                        Console.Write("Tên học viên: ");
                        student.FullName = Console.ReadLine();
                        Console.Write("Ngày sinh (dd/MM/yyyy): ");
                        student.Birthday = Input.Date();

                        ReturnData registerReturn = studentRegister.Register(student);
                        Console.WriteLine(registerReturn.Message);
                        break;
                    case 3:
                        string listStudents = studentRegister.ShowAllStudents();
                        Console.WriteLine(listStudents);
                        break;
                    default:
                        break;
                }

                Console.ReadLine();
            } while (luaChon != 0);
        }

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
                int quantity = Input.Integer(false);

                ReturnData buy = productManager.BuyProduct(productID, quantity);
                Console.WriteLine(buy.Message);
            }

            string buyList = productManager.ShowBuyProducts();
            Console.WriteLine(buyList);
        }
    }
}
