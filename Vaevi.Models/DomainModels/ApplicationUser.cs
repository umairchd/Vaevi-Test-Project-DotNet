using Microsoft.AspNetCore.Identity;

namespace Vaevi.Models.DomainModels
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
