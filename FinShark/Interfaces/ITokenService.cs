using FinShark.Models;

namespace FinShark.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}