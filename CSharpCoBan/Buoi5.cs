using System;
using System.Data;
using System.Globalization;

namespace CSharpCoBan
{
    internal class TinhNgaySong
    {
        internal void Run()
        {
            Console.WriteLine("Nhập vào ngày sinh (dd/MM/YYYY): ");
            var input = Console.ReadLine();
            var Birthday = ConvertToDateTime(input);
            var LivedTime = CalculateTime(Birthday);

            Console.WriteLine("Bạn đã sống được " + LivedTime);
        }

        internal DateTime ConvertToDateTime(string Birthday)
        {
            if (Birthday == null)
            {
                Console.WriteLine("Ngày tháng không được bỏ trống!");
                throw new NoNullAllowedException();
            }

            if (!DateTime.TryParseExact(Birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                Console.WriteLine("Ngày tháng không hợp lệ!");
                throw new Exception();
            }

            return result;
        }

        internal int CalculateTime(DateTime Birthday)
        {
            TimeSpan time = DateTime.Now - Birthday;
            return time.Days;
        }
    }

    internal class KiemTraString
    {
        internal void Run()
        {
            bool kiemTra = false;
            const string defaultUserName = "admin";
            const string defaultPassword = "admin";

            Console.WriteLine("Nhập vào tài khoản và mật khẩu");

            do
            {
                Console.Write("Tài khoản: ");
                string userName = Console.ReadLine();

                if (userName != defaultUserName)
                {
                    Console.WriteLine("Tài khoản không đúng! Vui lòng nhập lại.");
                    continue;
                }
                
                Console.Write("Mật khẩu: ");
                string password = Console.ReadLine();

                if (password != defaultPassword)
                {
                    Console.WriteLine("Mật khẩu không đúng! Vui lòng nhập lại.");
                    continue;
                }

                kiemTra = true;
            } while (!kiemTra);

            Console.WriteLine("Đăng nhập thành công!");
        }
    }
}
