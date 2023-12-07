using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;

namespace School.Application.Absreactions
{
    public interface IApplicationDbContext
    {
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
