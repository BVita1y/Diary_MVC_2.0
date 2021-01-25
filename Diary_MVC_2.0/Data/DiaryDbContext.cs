using Diary_MVC_2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Diary_MVC_2._0.Data
{
    public class DiaryDbContext : DbContext
    {
        public DiaryDbContext(DbContextOptions<DiaryDbContext> options)
            : base(options)
        { }

        public DbSet<Reminder> Reminder { get; set; }
        public DbSet<Case> Case { get; set; }
        public DbSet<Meeting> Meeting { get; set; }
        public DbSet<Plan> Plan { get; set; }
    }
}
