using CMS.Models.Managers;
using CMS.Services.ManagerService;
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
    public class ManagerController : ApiController
    {
        private ManagerServices CreateManagerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var managerServices = new ManagerServices(userId);
            return managerServices;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(CreateManager manager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateManagerService();
            if(!await service.Create(manager))
            {
                return InternalServerError();
            }
            return Ok($"{manager.FirstName} {manager.LastName} has been added to the database.");
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllManagers()
        {
            ManagerServices managerServices = CreateManagerService();
            var manager = await managerServices.GetAllManagers();
            return Ok(manager);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetManagerById(int id)
        {
            ManagerServices managerServices = CreateManagerService();
            var manager = await managerServices.GetManagerById(id);
            return Ok(manager);
        }

        [HttpPut]
        // Update Manager
        public async Task<IHttpActionResult> Update(EditManager manager, int id)
        {
            var service = CreateManagerService();
            if (!await service.Update(manager, id))
            {
                return InternalServerError();
            }
            return Ok($"Manager{id} has been updated.");
        }

        [HttpDelete]
        // Delete Manager
        public async Task<IHttpActionResult> Delete(int id)
        {
            var service = CreateManagerService();
            var manager = service.GetManagerById(id);
            return Ok(await manager);
        }

        [HttpGet]
        // Get List of Employees By Manager
        public async Task<IHttpActionResult> GetListOfEmployeesByManager()
        {
            var service = CreateManagerService();
            var employeesByManager = service.GetListOfEmployees();
            return Ok(await employeesByManager);
        }
    }
}
