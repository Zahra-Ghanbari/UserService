using Microsoft.EntityFrameworkCore;
using Model;

namespace DataContext
{
    /// <summary>
    /// This class is a database context provider for user service.
    /// </summary>
    public class UserContext : DbContext
    {
        /// <summary>
        /// initializes a DbContext instance.
        /// </summary>
        /// <param name="options"> The database context options.</param>
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        /// <summary>
        /// Gets and sets User Entity
        /// </summary>
        public DbSet<User> Users { get; set; }

    }
}
