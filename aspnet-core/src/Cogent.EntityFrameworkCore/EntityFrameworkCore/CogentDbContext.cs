using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Cogent.Authorization.Roles;
using Cogent.Authorization.Users;
using Cogent.MultiTenancy;
using Cogent.Calls;

namespace Cogent.EntityFrameworkCore
{
    public class CogentDbContext : AbpZeroDbContext<Tenant, Role, User, CogentDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Call> Calls { get; set; }
        public CogentDbContext(DbContextOptions<CogentDbContext> options)
            : base(options)
        {
        }
    }
}
