using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Cogent.Configuration;
using Cogent.Web;

namespace Cogent.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class CogentDbContextFactory : IDesignTimeDbContextFactory<CogentDbContext>
    {
        public CogentDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CogentDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            CogentDbContextConfigurer.Configure(builder, configuration.GetConnectionString(CogentConsts.ConnectionStringName));

            return new CogentDbContext(builder.Options);
        }
    }
}
