using CMS.Data;
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
        public async Task<IHttpActionResult> CreateManager(CreateManager manager)
        {             
            // If the model in the createManager class 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // The model is not valid, go ahead and reject it.
            }

            var service = CreateManagerService();
            if(!await service.Create(manager))
            {
                return InternalServerError();
            }

            // If the model in the createManager class is valid
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
            return Ok($"Manager with Id {id} has been updated.");
        }

        [HttpDelete]
        // Delete Manager
        public async Task<IHttpActionResult> Delete(int id)
        {
            var managerService = CreateManagerService();
            if (!await managerService.Delete(id))
            {
                return Ok("Manager was not found.");
            }
            return Ok($"Manager with ID# {id} was deleted.");
        }

        [HttpGet]
        [Route("Manager/GetEmployeesByManager")]
        //Get List of Employees By Manager
        public async Task<IHttpActionResult> GetListOfEmployeesByManager()
        {
            var service = CreateManagerService();
            var employeesByManager = service.GetListOfEmployees();
            return Ok(await employeesByManager);
        }
    }
}
