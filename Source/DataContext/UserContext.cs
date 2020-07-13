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
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(table =>
            {           
                table.OwnsOne(
                    x => x.Address,
                    address =>
                    {
                        address.Property(x => x.Country).HasColumnName("Country");
                        address.Property(x => x.State).HasColumnName("State");
                        address.Property(x => x.City).HasColumnName("City");
                                           
                    });
            });
        }
        /// <summary>
        /// Gets and sets User Entity
        /// </summary>
        public DbSet<User> Users { get; set; }

    }
}
