using Microsoft.AspNetCore.Identity;

namespace clone1.Core.Entities;

public class AppUserRole : IdentityUserRole<int>
{
    public AppUser User { get; set; }
    public AppRole Role { get; set; }
}