using CommonLibs;

namespace EmployeesDB.DataAccess.Objects
{
    public class EmployeerSaveReturnData : ReturnData
    {
        public int SaveChangesCode { get; set; }
        public Employeer? Employeer { get; set; }
    }
}
