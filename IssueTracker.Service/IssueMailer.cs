using IssueTracker.Core.Interfaces;
using IssueTracker.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Service
{
    public class IssueMailer : IIssueMailer
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IDepartmentRepository _departmentRepository;
        
        public IssueMailer(
            IUserService userService,
            IEmailService emailService,
            IDepartmentRepository departmentReposiptory)

        {
            _userService = userService;
            _emailService = emailService;
            _departmentRepository = departmentReposiptory;
        }

        public async Task EmailIssueAssignedNotification(Guid resolverId)
        {
            var resolver = await _userService.GetUser(resolverId);

            var msg = new StringBuilder();
            msg.AppendFormat("Hi {0}", resolver.FirstName);
            msg.AppendLine();
            msg.AppendFormat("You have been Assign an Issue to resolve");
            msg.AppendLine();
            msg.AppendFormat("Thanks");
            msg.AppendLine();
            msg.AppendFormat("Issue Tracking System");

            try
            {
                var email = new Email
                {
                    Subject = "You have bee Assigned an issue",
                    Recipients = new string[] {resolver.Email},
                    // Bcc = add administrator later
                    Body = msg.ToString(),
                    Sender = "no-reply@IssueTrackingSystem.com"
                };

                await _emailService.SendAsync(email);
            }
            
            catch(Exception)
            {
                throw new InvalidOperationException();
            }

        }

        public async Task EmailNewIssue(long departmentId)
        {
            var department = await _departmentRepository.GetDepartment(departmentId, includeAdmin:true);
            var msg = new StringBuilder();
            msg.AppendFormat("Hi {0}", department.Admin.FirstName);
            msg.AppendLine();
            msg.AppendFormat("An Issue That needs the attention of your Department Has been Raised,/" +
                "Kindly Assign a member of your department to resolve it.");
            msg.AppendLine();
            msg.AppendFormat("Thanks");
            msg.AppendLine();
            msg.AppendFormat("Issue Tracking System");

            try
            {
                var email = new Email
                {
                    Subject = "An Issue that needs your attention has been raised",
                    Recipients = new string[] { department.Admin.Email },
                    // Bcc = add administrator later
                    Body = msg.ToString(),
                    Sender = "no-reply@IssueTrackingSystem.com"
                };

                await _emailService.SendAsync(email);
            }
            catch (Exception)
            {

                throw new InvalidOperationException();
            }

        }
    }
}
