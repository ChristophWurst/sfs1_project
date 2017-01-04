using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Models
{
    public class ProjectManagerContext : DbContext
    {
        public ProjectManagerContext(DbContextOptions<ProjectManagerContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
    }

}
