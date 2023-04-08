using Microsoft.AspNetCore.Identity;

namespace clone1.Entities;

public class AppUserRole : IdentityUserRole<int>
{
    public AppUser User { get; set; }
    public AppRole Role { get; set; }
}