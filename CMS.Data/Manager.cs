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
    }
}
