using Microsoft.EntityFrameworkCore;
using act.Models;

namespace act.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Act> Acts {get;set;}
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
    }
}