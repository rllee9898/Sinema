using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ElevenMovie.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Genre> Genres { get; set; }
        //public DbSet<List> Lists { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentifyUserLoginConfiguration())
                .Add(new IdentifyUserRoleConfiguration());
        }
    }

    public class IdentifyUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentifyUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }

    public class IdentifyUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentifyUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}