using System.ComponentModel.DataAnnotations;

namespace Vaevi.Models.WebModels
{
    public class ContactModel
    {
        public int? Id { get; set; }
        [Required, Phone, DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [MaxLength(30), MinLength(1), Required]
        public string FullName { get; set; }
        [DataType(DataType.EmailAddress), EmailAddress(ErrorMessage = "Not valid email")]
        public string? Email { get; set; }
        [MaxLength(250)]
        public string? Address { get; set; }

        public string UserId { get; set; }
    }
}
