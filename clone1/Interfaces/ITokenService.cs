using clone1.Entities;

namespace clone1.Interfaces;

public interface ITokenService
{
    public Task<string> CreateToken(AppUser user);
}