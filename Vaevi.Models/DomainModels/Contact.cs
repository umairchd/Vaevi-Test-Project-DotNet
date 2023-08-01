using Microsoft.AspNetCore.Identity;

namespace Vaevi.Models.DomainModels
{
    public class Contact
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public string? Email { get; set; }

        public string? Address { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
