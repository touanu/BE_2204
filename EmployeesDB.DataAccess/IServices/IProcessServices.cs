using EmployeesDB.DataAccess.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDB.DataAccess.IServices
{
    public interface IProcessServices
    {
        Task<Process> GetProcessByName(string processName);
        Task<int> IndexOfProcess(Process process);
    }
}
