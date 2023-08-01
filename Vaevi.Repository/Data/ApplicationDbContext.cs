using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vaevi.Interfaces;
using Vaevi.Models.DomainModels;

namespace Vaevi.Repository.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>().HasKey(x => x.Id);
            builder.Entity<ApplicationUser>().HasMany(x => x.Contacts).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            base.OnModelCreating(builder);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}