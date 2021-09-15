﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data
{
    public class Manager : Personnel
    {
        [Required]
        public List<Employee> Employees { get; set; } = new List<Employee>();

        [Required]
        public int NumberOfEmployees { get; set; }

        [Required]
        public double Salary { get; set; }
    }
}
