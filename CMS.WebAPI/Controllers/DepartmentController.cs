using CMS.Models.Department;
using CMS.Services.Department_Services;
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
    [Authorize]
    public class DepartmentController : ApiController
    {
        private DepartService CreateDepartmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var departmentService = new DepartService(userId);
            return departmentService;
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
                return InternalServerError();
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllDepartments()
        {
            DepartService departmentServices = CreateDepartmentService();
            var department = await departmentServices.GetDepartments();
            return Ok(department);
        }

        // GET Department By Id (Required)
        [HttpGet]
        public async Task<IHttpActionResult> GetDepartmentId(int id)
        {
            DepartService departmentServices = CreateDepartmentService();
            var department = await departmentServices.GetDepartmentById(id);
            return Ok(department);
        }
    }
}
