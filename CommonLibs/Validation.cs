using System.Linq;
using System.Text.RegularExpressions;

namespace CommonLibs
{
    public class Validation
    {
        public static bool IsNegative(int number)
        {
            if (number < 0)
                return true;

            return false;
        }

        public static bool IsNumber(string input)
        {
            if (!string.IsNullOrEmpty(input))
                return false;

            if (!input.All(char.IsDigit))
                return false;

            return true;
        }

        public static bool IsName(string input)
        {
            // https://stackoverflow.com/a/46265018
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

            if (string.IsNullOrEmpty(input))
                return false;

            if (IsContainHTMLTags(input))
                return false;

            if (!Regex.IsMatch(pattern, input))
                return false;

            return true;
        }

        public static bool IsContainNumber(string input)
        {
            // https://stackoverflow.com/a/18251942
            return input.Any(char.IsDigit);
        }

        public static bool IsContainHTMLTags(string input)
        {
            Regex tagPattern = new Regex(@"<[^>]+>");
            return tagPattern.IsMatch(input);
        }
    }
}
