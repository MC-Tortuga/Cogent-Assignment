using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Cogent.EntityFrameworkCore
{
    public static class CogentDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CogentDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CogentDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
