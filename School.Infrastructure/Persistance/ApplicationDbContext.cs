using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Domain.Entities;

namespace School.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
