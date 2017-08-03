using IssueTracker.Core.Helpers;
using IssueTracker.Core.Interfaces;
using IssueTracker.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;


        public UserContext(
            IHttpContextAccessor context,
            UserManager<ApplicationUser> userManager
            )
        {
            _context = context;
            _userManager = userManager;
        }

        public Guid GetUserId()
        {
            //var userId = _context.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "sub")?.Value;

            //if (userId.IsNull())
            //{
            //    throw new OperationException("User is not currently logged in.", null);
            //}

            //return Guid.Parse(userId);
            var user = _context.HttpContext.User;
            var userId =  _userManager.GetUserId(user);

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
