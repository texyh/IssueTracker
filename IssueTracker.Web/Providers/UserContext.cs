using IssueTracker.Core.Helpers;
using IssueTracker.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Web.Providers
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _context;
        
        public UserContext(IHttpContextAccessor context)
        {
            _context = context;
        }

        public Guid GetUserId()
        {
            var userId = _context.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "sub")?.Value;

            if (userId.IsNull())
            {
                throw new OperationException("User is not currently logged in.", null);
            }

            return Guid.Parse(userId);
        }

        public string GetUserEmail()
        {
            var email = _context.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "email")?.Value;

            if (email.IsNullOrEmpty())
            {
                throw new OperationException("Email not found for user. Perhaps user is not currently logged in.", null);
            }

            return email;
        }
    }
}
