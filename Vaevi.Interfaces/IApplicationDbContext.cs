using Microsoft.EntityFrameworkCore;
using Vaevi.Models.DomainModels;

namespace Vaevi.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Contact> Contacts { get; set; }
        Task<int> SaveChangesAsync();
    }
}
