using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MvcBooksApp.Models
{
    public class UserLogin : IdentityUserLogin<int>
    {
        //public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
        public virtual User User { get; set; }
    }

    public class RelUserRole : IdentityUserRole<int>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }

    }

    public class UserClaim : IdentityUserClaim<int>
    {
        public virtual User User { get; set; }
    }

    public class User : IdentityUser<int
        , UserLogin
        , RelUserRole
        , UserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<UserLogin> UserLogins { get; set; } = new HashSet<UserLogin>();

        public virtual ICollection<Role> UserRoles { get; set; } = new HashSet<Role>();
    }

    public class Role : IdentityRole<int, RelUserRole>
    {
        public virtual ICollection<User> UserModels { get; set; } = new HashSet<User>();
    }
}