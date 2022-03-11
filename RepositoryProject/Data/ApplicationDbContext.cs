using Microsoft.EntityFrameworkCore;
using RepositoryProject.Models;

namespace RepositoryProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        // The DbSet property will tell EF Core tha we have a table that needs to be created
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Cutomer> Cutomers { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
