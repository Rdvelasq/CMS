using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data
{
    public class Department
    {
        [Key]        
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        public string DepartmentLocation { get; set; }

        public bool TestField { get; set; }

        //This is the list of personnel
        public List<Personnel> DepartmentListPersonnel { get; set; }
    }
}
