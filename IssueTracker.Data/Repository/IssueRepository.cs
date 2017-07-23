using IssueTracker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Core.Models;
using IssueTracker.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using IssueTracker.Core.Enums;

namespace IssueTracker.Data.Repository
{
    public class IssueRepository : IIssueRepository
    {
        private readonly IssueTrackerDbContext _dbContext;

        public IssueRepository(IssueTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Issue>> GetClosedIssues()
        {
            return await _dbContext.Issues
                .Where(x => x.Status == IssueStatusEnum.Resolved)
                .ToListAsync();
        }

        public async Task<Issue> GetIssue(long id)
        {
            return await _dbContext.Issues.FindAsync(id);
        }

        public async Task<IEnumerable<Issue>> GetOpenIssues()
        {
            return await _dbContext.Issues
                .Where(x => (x.Status == IssueStatusEnum.Open || x.Status == IssueStatusEnum.InProgress))
                .ToListAsync();
        }

        public async Task<Issue> SaveIssue(Issue issue)
        {
            _dbContext.Issues.Add(issue);

            await _dbContext.SaveChangesAsync();

            return issue;
        }

        public async Task<Issue> UpdateIssue(Issue issue)
        {
            _dbContext.Update(issue);
            await _dbContext.SaveChangesAsync();

            return issue;
        }
    }
}
