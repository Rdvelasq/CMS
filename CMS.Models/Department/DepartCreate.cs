using CMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.Department
{
    public class DepartCreate
    {
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }
        public override string ToString() => DepartmentName;

        [Required]
        public string DepartmentLocation { get; set; }

        public List<Personnel> DepartmentListPersonnel { get; set; }

    }
}
