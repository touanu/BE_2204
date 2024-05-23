using EmployeesDB.DataAccess.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDB.DataAccess.IServices
{
    public interface IEmployeerServices
    {
        Task<EmployeerSaveReturnData> Create(Employeer employeer);
        Task<EmployeerSaveReturnData> Update(Employeer employeer);
        Task<EmployeerSaveReturnData> Delete(int employeerID);
        Task<Employeer> GetEmployeerbyName(string employeerName);
        Task<Employeer> GetEmployeerbyProcessID(int processID);
    }
}
