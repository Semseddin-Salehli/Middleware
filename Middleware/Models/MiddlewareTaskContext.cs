using Microsoft.EntityFrameworkCore;

namespace Middleware.Models
{
    public class MiddlewareTaskContext : DbContext
    {
        public MiddlewareTaskContext(DbContextOptions<MiddlewareTaskContext> options) : base (options) 
        {
            
        }

        public DbSet<MiddlewareLog> Log {  get; set; }
    }
}
