using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Core.Interfaces
{
    public interface IUserContext
    {
        //string Email { get; }

        //string FirstName { get; }

        //string LastName { get; }

        //string UserId { get; }

        //IEnumerable<Guid> GetMemberIdsInRole(UserRole role);

        //Task<IEnumerable<UserRole>> GetRolesAsync(string userId);

        //Task<bool> IsInRole(string userId, UserRole role);

        //Task<bool> IsAdmin();

        Guid GetUserId();

        string GetUserEmail();
    }
}
