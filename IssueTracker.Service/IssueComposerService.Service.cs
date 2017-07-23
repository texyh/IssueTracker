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
        private readonly IUserContext _userContext;

        public IssueComposerService(
            IIssueRepository repository,
            IUserContext userContext
            )
        {
            _repository = repository;
            _userContext = userContext;
        }

        public async Task<IEnumerable<Issue>> GetClosedIssues()
        {
            return await _repository.GetClosedIssues(); 
        }

        public async Task<Issue> GetIssue(long issueId)
        {
            if (issueId == default(long))
            {
                return new Issue();
            }

            return await _repository.GetIssue(issueId);
        }

        public async Task<IEnumerable<Issue>> GetOpenIssues()
        {
            return await _repository.GetOpenIssues();
        }

        public async Task<Issue> SaveIssue(Issue issue)
        {
            var userId = _userContext.GetUserId();
            issue.ModifiedById = userId;
            issue.Modified = DateTime.UtcNow;

            if (issue.Id ==  default(long))
            {
                issue.Status = IssueStatusEnum.Open;
                issue.Created = DateTime.UtcNow;
                issue.CreatorId = userId;
                return await _repository.SaveIssue(issue);
            }
            
            return await _repository.UpdateIssue(issue);
        }
    }
}
