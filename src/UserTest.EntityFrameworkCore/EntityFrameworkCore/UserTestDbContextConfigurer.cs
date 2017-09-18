using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace UserTest.EntityFrameworkCore
{
    public static class UserTestDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<UserTestDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<UserTestDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}