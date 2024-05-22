
using AFORO255.AZ.Security.Repositories;

namespace AFORO255.AZ.Security.Data;

public class DbInitializer
{
    public static void Initialize(SecurityContext securityContext)
    {
        securityContext.Database.EnsureCreated();

        if (securityContext.UserAccess.Any())
        {
            return;   // DB has been seeded
        }

        var users = new Models.IdentityModel[]
        {
                new Models.IdentityModel{Email="eromero@cognosit.com", Password="cognosit#",FullName="Richard Romero"},
                new Models.IdentityModel{Email="jperez@cognosit.com", Password="cognosit#",FullName="Juan Perez"},
                new Models.IdentityModel{Email="mzarate@cognosit.com", Password="cognosit#",FullName="Martin Zapata"},
                new Models.IdentityModel{Email="aparedes@cognosit.com", Password="cognosit#",FullName="Antonio Paredes"},
        };

        foreach (Models.IdentityModel s in users)
        {
            securityContext.UserAccess.Add(s);
        }

        securityContext.SaveChanges();
    }
}

