using CMS.Data;
using CMS.Models.Department;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Department_Services
{
    public class DepartService
    {
        private readonly Guid departmentId; // make an _id of type Guid
        public DepartService(Guid id)
        {
            departmentId = id;
        }

        public async Task<bool> Create(DepartCreate model)
        {
            var entity =
                new Department() // This creates an instance of Department.
                {
                    DepartmentName = model.DepartmentName
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Departments.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<IEnumerable<DepartListItem>> GetDepartments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .Departments
                    .Select(c => new DepartListItem
                    {
                        DepartmentId = c.DepartmentId,
                        DepartmentName = c.DepartmentName,
                        
                    }).ToListAsync();
                return query;
            }
        }

        public async Task<DepartDetail> GetDepartmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var department =
                    await
                    ctx
                    .Departments
                    .Where(c => c.DepartmentId == id)
                    .SingleOrDefaultAsync(c => c.DepartmentId == id);
                if (department is null)
                {
                    return null;
                }

                return new DepartDetail
                {
                    DepartmentId = department.DepartmentId,
                    DepartmentName = department.DepartmentName,                    
                };
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldDepartmentData = await ctx.Departments.FindAsync(id);
                if (oldDepartmentData is null)
                {
                    return false;
                }
                ctx.Departments.Remove(oldDepartmentData);
                return await ctx.SaveChangesAsync() > 1;
            }
        }
    }
}
    

