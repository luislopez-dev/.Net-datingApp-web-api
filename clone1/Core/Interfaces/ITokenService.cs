using clone1.Core.Entities;

namespace clone1.Core.Interfaces;

public interface ITokenService
{
    public Task<string> CreateToken(AppUser user);
}