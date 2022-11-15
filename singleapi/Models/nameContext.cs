using Microsoft.EntityFrameworkCore;

namespace singleapi.Models
{
    public class nameContext : DbContext
    {
        public nameContext()
         {

            }


        public nameContext(DbContextOptions<nameContext> options)
            : base(options)
        {

        }
        public DbSet<name> names { get; set; }
    }
}
