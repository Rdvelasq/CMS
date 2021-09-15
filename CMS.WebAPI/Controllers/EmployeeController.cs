using CMS.Models.EmployeeModels;
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
    public class EmployeeController : ApiController
    {
        private EmployeeServices CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var employeeServices = new EmployeeServices(userId);
            return employeeServices;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(Create employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateEmployeeService();
            if(!await service.Create(employee))
            {
                return InternalServerError();
            }
            return Ok($"{employee.FirstName} {employee.LastName} has been added");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var service = CreateEmployeeService();
            if (!await service.Delete(id))
            {
                return InternalServerError();
            }
            return Ok($"Employee ID: {id} Deleted");
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var service = CreateEmployeeService();
            var employee = service.Get();
            return Ok(await employee);
        }
        
        [HttpPut]
        public async Task<IHttpActionResult> Update(Edit employee, int id)
        {
            var service = CreateEmployeeService();
            if (!await service.Update(employee,id))
            {
                return InternalServerError();
            }

            return Ok($"Employee{id} Updated");
        }
    }
}
