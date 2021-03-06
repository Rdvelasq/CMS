using CMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.Department
{
    public class DepartListItem
    {
        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        public override string ToString() => DepartmentName;

        [Display(Name = "Department Location")]
        public string DepartmentLocation { get; set; }
    }
}
