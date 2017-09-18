using UserTest.Configuration;
using UserTest.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace UserTest.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class UserTestDbContextFactory : IDesignTimeDbContextFactory<UserTestDbContext>
    {
        public UserTestDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<UserTestDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            UserTestDbContextConfigurer.Configure(builder, configuration.GetConnectionString(UserTestConsts.ConnectionStringName));

            return new UserTestDbContext(builder.Options);
        }
    }
}