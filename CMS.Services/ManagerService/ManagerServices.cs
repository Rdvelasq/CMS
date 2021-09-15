using CMS.Data;
using CMS.Models.EmployeeModels;
using CMS.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.ManagerService
{
    public class ManagerServices
    {
        private readonly Guid _id;
        public ManagerServices(Guid id)
        {
            _id = id;
        }

        public async Task<bool> Create(ManagerCreate manager)
        {
            var entity = new Manager
            {
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                HireDate = manager.HireDate,
                Email = manager.Email,
                Salary = manager.Salary,
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Managers.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
    }
}
