using AFORO255.AZ.Security.Models;
using AFORO255.AZ.Security.Repositories;

namespace AFORO255.AZ.Security.Services;

public class UserService : IUserService
{
    private readonly SecurityContext _securityContext;

    public UserService(SecurityContext securityContext) => _securityContext = securityContext;

    public Task<bool> Validated(IdentityModel identityModel)
    {
        var users = _securityContext.UserAccess.ToList();
        var user = users.Where(x => x.Email == identityModel.Email && x.Password == identityModel.Password).FirstOrDefault();
        if (user == null)
        {
            return Task.FromResult(false);
        }
        return Task.FromResult(true);
    }
}

