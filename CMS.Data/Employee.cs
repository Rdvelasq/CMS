using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data
{
    public class Employee : Personnel
    {
        [Required]
        public int ManagerId { get; set; }
        [Required]
        public double HourlyRate { get; set; }
    }
}
