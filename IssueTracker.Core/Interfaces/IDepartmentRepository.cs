using IssueTracker.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Core.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();

        Task<User> GetDepartmentAdmin(long id);

        Task<Department> CreateDepartment(Department department);

        Task<Department> UpdateDepartment(Department department);

        Task<Department> GetDepartment(long id, bool includeAdmin = false);
    }
}
