﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
   
        public  string?  Name { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public bool Status { get; set; }
    }
}
