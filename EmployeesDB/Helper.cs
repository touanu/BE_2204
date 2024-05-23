using EmployeesDB.DataAccess.Objects;
using System.Text;

namespace EmployeesDB
{
    internal static class Helper
    {
        internal static string WriteEmployeer(List<Employeer> employeers)
        {
            string format = "{0,-6}{1,-20}{2,-12}{3,-6}";
            StringBuilder builder = new();

            string header = string.Format(
                    format,
                    "ID", "Họ tên", "Ngày sinh", "Truyền may"
                );

            builder.AppendLine(header);
            foreach (var employee in employeers)
            {
                string content = string.Format(
                    format,
                    employee.EmployeerId,
                    employee.FullName,
                    employee.Birthday.ToString(),
                    employee.ProcessID
                );
                builder.AppendLine(content);
            }
            return builder.ToString();
        }
        internal static string WriteEmployeer(Employeer employeer)
        {
            string format = "{0,-6}{1,-20}{2,-12}{3,-6}";
            StringBuilder builder = new();

            string header = string.Format(
                    format,
                    "ID", "Họ tên", "Ngày sinh", "Truyền may"
                );

            builder.AppendLine(header);
            
            string content = string.Format(
                format,
                employeer.EmployeerId,
                employeer.FullName,
                employeer.Birthday.ToString(),
                employeer.ProcessID
            );
            builder.AppendLine(content);
            return builder.ToString();
        }
    }
}
