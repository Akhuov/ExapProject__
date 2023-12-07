using Marry.Application.Absreactions;
using Marry.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marry.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        {
            Database.Migrate(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marriage>()
                .HasOne(m => m.Groom)
                .WithOne(g => g.Marriage)
                .HasForeignKey<Marriage>(m => m.GroomId) 
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<Marriage> Marriages { get; set; }
        public DbSet<Bride> Brides { get; set; }
        public DbSet<Groom> Grooms { get; set; }
        public DbSet<Witness> Witnesses { get ; set; }
    }
}
