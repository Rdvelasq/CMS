using CMS.Models.Department;
using CMS.Services.Department_Services;
using CMS.Services.EmployeeService;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CMS.WebAPI.Controllers
{
    //[Authorize]
    public class DepartmentController : ApiController
    {
        private DepartService CreateDepartmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var departmentService = new DepartService(userId);
            return departmentService;
        }


        //Not Sure if i should include this here
        private EmployeeServices CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var employeeServices = new EmployeeServices(userId);
            return employeeServices;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Department(DepartCreate department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateDepartmentService();
            if (await service.Create(department))
            {
                return Ok($"The department {department.DepartmentName} has been created");
            }
            return InternalServerError();
        }


        // Get All Departments
        [HttpGet]
        public async Task<IHttpActionResult> GetAllDepartments()
        {
            DepartService departmentServices = CreateDepartmentService();
            var department = await departmentServices.GetDepartments();
            return Ok(department);
        }

        // GET Department By Id (Required)
        [HttpGet]
        public async Task<IHttpActionResult> GetDepartmentById(int id)
        {
            DepartService departmentServices = CreateDepartmentService();
            var department = await departmentServices.GetDepartmentById(id);
            return Ok(department);
        }


        //[HttpGet]
        //public async Task<IHttpActionResult> GetEmployeesByDepartmentName(string departmentName)
        //{
            
        //}

        // DELETE Department By Id (Required)

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var service = CreateDepartmentService();
            if (!await service.Delete(id))
            {
                return Ok("Record not found") ;
            }
            return Ok($"Department with ID# {id} was Deleted");
        }

        // UPDATE Department By Id (Required)
        [HttpPut]
        public async Task<IHttpActionResult> Update(DepartEdit department)
        {
            var service = CreateDepartmentService();
            if (!await service.Update(department))
            {
                return InternalServerError();
            }

            return Ok($"Department with ID# {department.DepartmentId} was Updated");
        }
    }
}
