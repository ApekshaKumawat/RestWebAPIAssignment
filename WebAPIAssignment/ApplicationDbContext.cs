using Microsoft.EntityFrameworkCore;
using WebAPIAssignment.Model;

namespace WebAPIAssignment
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
       

        

    }
}
