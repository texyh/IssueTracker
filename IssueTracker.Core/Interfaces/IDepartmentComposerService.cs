using IssueTracker.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Core.Interfaces
{
    public interface IDepartmentComposerService
    {
        Task<IEnumerable<Department>> GetDepartments();

        Task<Department> GetDepartmentAdmin(long id);

        Task<Department> SaveDepartment(Department department);
    }
}
