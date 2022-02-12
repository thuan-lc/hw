using Microsoft.AspNetCore.Identity;

namespace LibraryManagementAPI.Domains
{
    public class CustomUser: IdentityUser
    {
        public double Credits { get; set; }
    }
}
