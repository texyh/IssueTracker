using IssueTracker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using IssueTracker.Core.Models;
using System.Threading.Tasks;
using IssueTracker.Core.Enums;

namespace IssueTracker.Service
{
    public class IssueComposerService : IIssueComposerService
    {
        private readonly IIssueRepository _repository;

        public IssueComposerService(IIssueRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Issue>> GetClosedIssues()
        {
            return await _repository.GetClosedIssues(); 
        }

        public async Task<Issue> GetIssue(long issueId)
        {
            return await _repository.GetIssue(issueId);
        }

        public async Task<IEnumerable<Issue>> GetOpenIssues()
        {
            return await _repository.GetOpenIssues();
        }

        public async Task<Issue> SaveIssue(Issue issue)
        {
            if (issue.Id ==  default(long))
            {
                issue.Status = IssueStatusEnum.Open; 
                issue.Created = DateTime.UtcNow;
                issue.Modified = DateTime.UtcNow;
                return await _repository.SaveIssue(issue);
            }

            issue.Modified = DateTime.UtcNow;
            return await _repository.UpdateIssue(issue);
        }
    }
}
