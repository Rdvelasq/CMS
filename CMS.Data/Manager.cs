using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data
{
    public class Manager : Personnel
    {
        [Required]
        public int ManagerId { get; set; }

        [Required]
        public List<Employee> Employees { get; set; } = new List<Employee>();

        [Required]
        public int NumberOfEmployees { get; set; }

        [Required]
        public double salary { get; set; }
    }
}
