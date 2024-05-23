﻿using System.ComponentModel.DataAnnotations;

namespace EmployeesDB.DataAccess.Objects
{
    public class Employeer
    {
        [Key]
        public int EmployeerId { get; set; }
        public string? FullName { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
