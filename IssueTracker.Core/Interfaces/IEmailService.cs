using IssueTracker.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Core.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(Email email);
    }
}
