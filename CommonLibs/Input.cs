using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CSharpCoBan
{
    public class Input
    {
        public static int Integer(bool SoAm = true, int? min = null, int? max = null)
        {
            int input;
            bool kiemTra = false;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Ký tự đã nhập không phải số! Vui lòng nhập lại");
                    continue;
                }

                if (input <= 0 & SoAm)
                {
                    Console.WriteLine("Số đã nhập không phải số dương! Vui lòng nhập lại");
                    continue;
                }

                if (input < min | input > max)
                {
                    Console.WriteLine($"Số đã nhập vượt quá giới hạn cho phép! Vui lòng nhập số từ {min} đến {max}");
                    continue;
                }

                kiemTra = true;
            } while (!kiemTra);

            return input;
        }

        public static float Float(bool SoAm = true)
        {
            float input;
            bool kiemTra = false;
            do
            {
                if (!float.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Ký tự vừa nhập không phải số! Vui lòng nhập lại");
                    continue;
                }

                if (input <= 0 & SoAm)
                {
                    Console.WriteLine("Số đã nhập không phải số dương! Vui lòng nhập lại");
                    continue;
                }

                kiemTra = true;
            } while (!kiemTra);

            return input;
        }

        public static string Name()
        {
            // https://stackoverflow.com/a/3819837
            const string pattern = 
                "^([a-zA-Z]|" +
                "\\s|" +
                "[àáãạảăắằẳẵặâấầẩẫậ" +
                "èéẹẻẽêềếểễệ" +
                "đìíĩỉị" +
                "òóõọỏôốồổỗộơớờởỡợ" +
                "ùúũụủưứừửữự" +
                "ỳỵỷỹý" +
                "ÀÁÃẠẢĂẮẰẲẴẶÂẤẦẨẪẬ" +
                "ÈÉẸẺẼÊỀẾỂỄỆ" +
                "ĐÌÍĨỈỊ" +
                "ÒÓÕỌỎÔỐỒỔỖỘƠỚỜỞỠỢ" +
                "ÙÚŨỤỦƯỨỪỬỮỰ" +
                "ỲỴỶỸÝ])+$";
            string input;
            bool kiemTra = false;
            
            do
            {
                input = Console.ReadLine();

                if (input == null)
                {
                    Console.WriteLine("Vui lòng nhập vào thông tin! Vui lòng nhập lại");
                    continue;
                }

                if (!Regex.IsMatch(input, pattern))
                {
                    Console.WriteLine("Tên không được chứa số hoặc ký tự đặc biệt! Vui lòng nhập lại");
                    continue;
                }

                kiemTra = true;
            } while (!kiemTra);

            return input;
        }

        public static DateTime Date(string timeFormat = "dd/MM/yyyy")
        {
            string input;
            DateTime result = new DateTime();
            bool kiemTra = false;

            do
            {
                input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Ngày tháng không được bỏ trống! Vui lòng nhập lại.");
                    continue;
                }

                if (!DateTime.TryParseExact(input, timeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    Console.WriteLine("Ngày tháng không hợp lệ! Vui lòng nhập lại.");
                    continue;
                }

                kiemTra = true;
            } while (!kiemTra);

            return result;
        }
    }
}
