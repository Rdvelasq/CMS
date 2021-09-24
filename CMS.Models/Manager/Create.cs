using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.Managers
{
    public class CreateManager
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        public DateTime HireDate { get; set; }

        [Required]
        public string Email { get; set; }
        public double Salary { get; set; }

        public int NumberOfEmployees { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
