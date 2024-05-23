using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDB.DataAccess.Objects
{
    public class Process
    {
        [Key]
        public int ProcessID { get; set; }
        public string? ProcessName { get; set; }
        public int EmployeerID { get; set; }
    }
}
