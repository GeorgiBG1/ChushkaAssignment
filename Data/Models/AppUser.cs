using Microsoft.AspNetCore.Identity;

namespace ChushkaAssignment.Data.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Roles = new HashSet<IdentityRole>();
        }
        public string FullName { get; set; }
        public virtual ICollection<IdentityRole> Roles { get; set; }
    }
}
