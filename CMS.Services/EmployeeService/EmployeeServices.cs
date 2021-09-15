using CMS.Data;
using CMS.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.EmployeeService
{
    public class EmployeeServices
    {
        private readonly Guid _id;
        public EmployeeServices(Guid id)
        {
            _id = id;
        }
        
        public async Task<bool> Create(Create employee)
        {
            var entity = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                HireDate = employee.HireDate,
                Email = employee.Email,
                ManagerId = employee.ManagerId,
                HourlyRate = employee.HourlyRate
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Employees.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        
        }

        public async Task<bool> Delete(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Employees
                    .Single(e => e.Id == id);
                ctx.Employees.Remove(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
            
        }

        public async Task<IEnumerable<ListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext()) {
                var query =
                    await
                    ctx
                    .Employees
                    .Select(d => new ListItem
                    {
                        FirstName = d.FirstName,
                        LastName = d.LastName,
                        HireDate = d.HireDate,
                        Email = d.Email,
                        ManagerId = d.ManagerId,
                        HourlyRate = d.HourlyRate
                    }).ToListAsync();

                    return query;               
             }

        }

        public async Task<bool> Update(Edit NewEployee, int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var employee =
                    await
                    ctx
                    .Employees
                    .SingleOrDefaultAsync(d => d.Id == id);
                employee.Email = NewEployee.Email;
                employee.ManagerId = NewEployee.ManagerId;
                employee.HourlyRate = NewEployee.HourlyRate;
                return await ctx.SaveChangesAsync() == 1;
            }
            
        }
        
    }
}
