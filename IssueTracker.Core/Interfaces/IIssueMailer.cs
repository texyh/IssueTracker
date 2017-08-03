using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Core.Interfaces
{
    public interface IIssueMailer
    {

        Task EmailNewIssue(long departmentId);

        Task EmailIssueAssignedNotification(Guid resolverId);
    }
}
