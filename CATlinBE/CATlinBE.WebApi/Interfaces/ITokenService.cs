using CATlinBE.Entities;

namespace CATlinBE.WebApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
