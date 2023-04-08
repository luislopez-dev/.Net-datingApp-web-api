using Microsoft.AspNetCore.Identity;

namespace clone1.Entities;

public class AppRole : IdentityRole<int>
{
    public ICollection<AppUserRole> UserRoles { get; set; }
}