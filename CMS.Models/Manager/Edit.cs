using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.Managers
{
    public class EditManager
    {
        [Required]
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public double Salary { get; set; }
        public int NumberOfEmployees { get; set; }
    }
}
