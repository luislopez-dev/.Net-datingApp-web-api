using clone1.Helpers;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace clone1.Entities;

public class AppUser : IdentityUser<int>
{
    public string City { get; set; }
    public string Country { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime LastActive { get; set; } = DateTime.UtcNow;
    public DateOnly DateOfBirth { get; set; } 
    
    public string Gender { get; set; }
    public string Interests { get; set; }
    public string KnownAs { get; set; }
    public string LookingFor { get; set; }
    public string Introduction { get; set; }
    public List<Message> MessagesSent { get; set; }
    public List<Message> MessagesReceived { get; set; }

    public List<Photo> Photos { get; set; } = new();
    public List<UserLike> LikedUsers { get; set; }
    public List<UserLike> LikedByUsers { get; set; }
    public ICollection<AppUserRole> UserRoles { get; set; }
}