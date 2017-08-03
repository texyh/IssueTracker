using IssueTracker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using IssueTracker.Core.Models;
using System.Threading.Tasks;

namespace IssueTracker.Service
{
    public class DepartmentComposerService : IDepartmentComposerService
    {
        private readonly IDepartmentRepository _repository;
        private readonly IUserContext _userContext;

        public DepartmentComposerService(
            IDepartmentRepository repository,
            IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }

        public async Task<Department> GetDepartmentAsync(long id)
        {
            return await _repository.GetDepartment(id);
        }

        public async Task<User> GetDepartmentAdmin(long id)
        {
            return await _repository.GetDepartmentAdmin(id);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _repository.GetDepartments();
        }

        public async Task<Department> SaveDepartment(Department department)
        {
            var userId = _userContext.GetUserId();
            department.Modified = DateTime.UtcNow;
            department.ModifiedById = userId;

            if (department.Id == default(long))
            {
                department.Created = DateTime.UtcNow;
                department.CreatorId = userId;
                return await _repository.CreateDepartment(department);
            }

            var dbDepartment = await _repository.GetDepartment(department.Id);

            dbDepartment.Name = department.Name;
            dbDepartment.AdminId = department.AdminId;
            return await _repository.UpdateDepartment(department);

        }
    }
}
