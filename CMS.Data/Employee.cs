using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data
{
    public class Employee : Personnel
    {
        [ForeignKey(nameof(Manager))]
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }

        [Required]
        public double HourlyRate { get; set; }
    }
}
