
namespace datingApp.Entities;

/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public class UserLike
{
    public AppUser SourceUser { get; set; }
    public int SourseUserId { get; set; }
    public AppUser TargetUser { get; set; }
    public int TargetUserId { get; set; }
}