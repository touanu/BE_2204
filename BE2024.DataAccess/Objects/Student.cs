using System;

namespace BE2024.DataAccess.Objects
{
    public class Student
    {
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime RegisterDate { get; set; }
        public double Discount { get; set; } = 0;
    }
}
