using IssueTracker.Core.Interfaces;
using IssueTracker.Web.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Web
{
    public class UserContext // : IUserContext, IDisposable
    {
        
        //public class UserContext : IUserContext
        //{
        //    // private const string MANAGER_ROLE = "Manager";
        //    private readonly IHttpContextAccessor _context;

        //    /// <summary>
        //    /// constructor for UserContext
        //    /// </summary>
        //    /// <param name="context"></param>
        //    public UserContext(IHttpContextAccessor context)
        //    {
        //        _context = context;
        //    }

        //    /// <summary>
        //    /// Gets ID for the logged in user
        //    /// </summary>
        //    /// <returns></returns>
        //    public Guid GetUserId()
        //    {
        //        var userId = _context.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "sub")?.Value;

        //        if (userId.IsNullOrEmpty())
        //        {
        //            throw new OperationException("User is not currently logged in.", null);
        //        }

        //        return Guid.Parse(userId);
        //    }

        //    /// <summary>
        //    /// Gets email for the logged in user
        //    /// </summary>
        //    /// <returns></returns>
        //    public string GetUserEmail()
        //    {
        //        var email = _context.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "email")?.Value;

        //        if (email.IsNullOrEmpty())
        //        {
        //            throw new OperationException("Email not found for user. Perhaps user is not currently logged in.", null);
        //        }

        //        return email;
        //    }

        //    /// <summary>
        //    /// Gets role for the logged in user
        //    /// </summary>
        //    /// <returns></returns>
        //    public IEnumerable<string> GetUserRoles()
        //    {
        //        return _context.HttpContext.User.Claims
        //            .Where(c => c.Type == "role")
        //            .Select(x => x.Value);
        //    }

        //    /// <summary>
        //    /// Gets details for the currently logged in user
        //    /// </summary>
        //    /// <returns></returns>
        //    public UserDetail GetUserDetail()
        //    {
        //        var claims = _context.HttpContext.User.Claims;
        //        var userId = GetUserId();
        //        var email = GetUserEmail();
        //        var firstName = claims.SingleOrDefault(c => c.Type == "FirstName")?.Value;
        //        var lastName = claims.SingleOrDefault(c => c.Type == "LastName")?.Value;
        //        var roles = GetUserRoles();

        //        return new UserDetail(userId, firstName, lastName, email, roles);
        //    }

        //    /// <summary>
        //    /// Returns true if the logged in user is a manager
        //    /// </summary>
        //    /// <returns></returns>
        //    public bool IsUserManager()
        //    {
        //        var roles = GetUserRoles();

        //        return roles.Contains(MANAGER_ROLE);
        //    }
        //}
    }
}
