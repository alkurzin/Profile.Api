using Microsoft.EntityFrameworkCore;

namespace Profile.Infrastructure
{
    public class ProfileDbContext : DbContext
    {
        public DbSet<Domain.Profile.Profile> Profiles { get; set; }

        public ProfileDbContext(DbContextOptions<ProfileDbContext> options)
            : base(options)
        {

        }
    }
}
