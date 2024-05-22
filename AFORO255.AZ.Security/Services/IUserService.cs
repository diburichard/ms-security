using AFORO255.AZ.Security.Models;

namespace AFORO255.AZ.Security.Services;
public interface IUserService
{
    Task<bool> Validated(IdentityModel identityModel);
}

