using CMS.Data;
using CMS.Models.EmployeeModels;
using CMS.Models.Managers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<bool> Create(CreateManager manager)
        {
            var entity = new Manager()
            {
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                HireDate = manager.HireDate,
                Email = manager.Email,
                Salary = manager.Salary,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Managers.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<IEnumerable<Item>> GetAllManagers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .Managers
                    .Select(d => new Item
                    {
                        FirstName = d.FirstName,
                        LastName = d.LastName,
                        HireDate = d.HireDate,
                        Email = d.Email,
                        Salary = d.Salary,
                    }).ToListAsync();
                return query;
            }
        }

        public async Task<DetailManager> GetManagerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var manager =
                    await
                    ctx
                    .Managers
                    .Where(d => d.Id == id)
                    .SingleOrDefaultAsync(d => d.Id == id);
                if (manager is null)
                {
                    return null;
                }

                return new DetailManager
                {
                    ManagerId = manager.Id,
                    FirstName = manager.FirstName,
                    LastName = manager.LastName,
                    HireDate = manager.HireDate,
                    Email = manager.Email,
                    Salary = manager.Salary,
                    Employees = ctx.Employees.Where(e => e.ManagerId == manager.Id).ToList()
                };
            }
        }

        public async Task<bool> Update(EditManager NewManager, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var manager =
                    await
                    ctx
                    .Managers
                    .SingleOrDefaultAsync(d => d.Id == id);
                manager.Email = NewManager.EmailAddress;
                manager.Salary = NewManager.Salary;
                manager.NumberOfEmployees = NewManager.NumberOfEmployees;
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Managers
                    .Select(d => d.Id == id);
                ctx.Managers.Remove((Manager)entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<IEnumerable<Item>> GetListOfEmployees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .Employees
                    .Select(d => new Item
                    {
                        ManagerId = d.ManagerId,
                        FirstName = d.FirstName,
                        LastName = d.LastName,
                        HireDate = d.HireDate,
                        Email = d.Email,
                        Salary = d.HourlyRate,

                    }).ToListAsync();
                return query;
            }
        }
    }
}
