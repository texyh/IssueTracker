using IssueTracker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using IssueTracker.Core.Models;
using System.Threading.Tasks;
using IssueTracker.Data.DbContexts;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Data.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IssueTrackerDbContext _dbContext;

        public DepartmentRepository(IssueTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            await _dbContext.Departments.AddAsync(department);
            await _dbContext.SaveChangesAsync();
            return department;
        }

        public async Task<User> GetDepartmentAdmin(long id)
        {
            var department = await _dbContext.Departments
                .Include(x => x.Admin)
                .FirstOrDefaultAsync(x => x.Id == id);

            return department.Admin;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _dbContext.Departments
                .Include(x => x.Admin)
                .ToListAsync();
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            _dbContext.Entry(department).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return department;
        }

        public async Task<Department> GetDepartment(long id, bool includeAdmin = false)
        {
            var department = _dbContext.Departments.AsQueryable();

            if (includeAdmin)
            {
                department = department.Include(x => x.Admin);
            }

            return await department.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
