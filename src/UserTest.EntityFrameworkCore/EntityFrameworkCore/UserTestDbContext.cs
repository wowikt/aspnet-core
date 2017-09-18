using Abp.Zero.EntityFrameworkCore;
using UserTest.Authorization.Roles;
using UserTest.Authorization.Users;
using UserTest.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace UserTest.EntityFrameworkCore
{
    public class UserTestDbContext : AbpZeroDbContext<Tenant, Role, User, UserTestDbContext>
    {
        /* Define an IDbSet for each entity of the application */
        
        public UserTestDbContext(DbContextOptions<UserTestDbContext> options)
            : base(options)
        {

        }
    }
}
