using IssueTracker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using IssueTracker.Core.Models;
using System.Threading.Tasks;

namespace IssueTracker.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository reposiotory)
        {
            _repository = reposiotory;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repository.GetUsers();
        }

        public async Task<User> SaveUser(User user)
        {
            return await _repository.SaveUser(user);
        }

        public async Task<User> GetUser(Guid userId)
        {
            return await _repository.GetUser(userId);
        }

      
    }
}
