using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE2024.DataAccess.Objects
{
    public class Course
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Tuition { get; set; }
        public DateTime OpeningDate { get; set; }

    }
}
