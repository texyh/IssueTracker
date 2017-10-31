using IssueTracker.Core.Models;
using IssueTracker.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Core.Interfaces
{
    public interface IIssueComposerService
    {
        Task<IEnumerable<Issue>> GetOpenIssues();

        Task<IEnumerable<Issue>> GetClosedIssues();

        Task<SaveIssueViewModel> GetIssue(long issueId);

        Task<Issue> SaveIssue(Issue issue);

        Task<IEnumerable<Issue>> CurentUserIssues();

        Task<IEnumerable<Issue>> AssignedIssues(Guid? userId = null);
    }
}
