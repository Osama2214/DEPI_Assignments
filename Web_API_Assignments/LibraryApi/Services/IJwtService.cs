using LibraryApi.Models;

namespace LibraryApi.Services;

public interface IJwtService
{
    string GenerateToken(ApplicationUser user);
}
