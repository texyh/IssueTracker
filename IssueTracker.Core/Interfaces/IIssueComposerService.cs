﻿using IssueTracker.Core.Models;
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

        Task<Issue> GetIssue(long issueId);

        Task<Issue> SaveIssue(Issue issue);
    }
}
