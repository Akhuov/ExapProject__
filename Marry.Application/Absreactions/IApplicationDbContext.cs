using Marry.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marry.Application.Absreactions
{
    public interface IApplicationDbContext
    {
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<Bride> Brides { get; set; }
        public DbSet<Groom> Grooms { get; set; }
        public DbSet<Witness> Witnesses { get; set; }
        public DbSet<Marriage> Marriages { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
