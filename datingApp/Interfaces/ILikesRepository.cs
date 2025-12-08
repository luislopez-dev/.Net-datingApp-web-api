
using datingApp.DTOs;
using datingApp.Entities;
using datingApp.Helpers;

namespace datingApp.Interfaces
{
    /// <summary>
    /// </summary>
    /// <remarks>
    /// Author: Luis López  
    /// GitHub: https://github.com/luislopez-dev
    /// Description: Training Project
    /// </remarks>
    public interface ILikesRepository
    {
        public Task<UserLike> GetUserLike(int sourceUserId, int targetUserId);
        public Task<AppUser> GetUserWithLikes(int userId);
        public Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams);
        
    }
}