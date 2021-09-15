using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.EmployeeModels
{
    public class Edit
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int ManagerId { get; set; }
        public double HourlyRate { get; set; }
    }
}
