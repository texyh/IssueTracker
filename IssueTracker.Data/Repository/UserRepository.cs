using IssueTracker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using IssueTracker.Core.Models;
using System.Threading.Tasks;
using IssueTracker.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IssueTrackerDbContext _dbContext;

        public UserRepository(IssueTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> SaveUser(User user)
        {
            _dbContext.Users.Add(user);

            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
