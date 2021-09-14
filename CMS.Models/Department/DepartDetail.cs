using CMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.Department
{
    public class DepartDetail
    {
        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Display(Name = "List of Personnel")]
        public List<Personnel> DepartmentListPersonnel { get; set; }


    }
}
