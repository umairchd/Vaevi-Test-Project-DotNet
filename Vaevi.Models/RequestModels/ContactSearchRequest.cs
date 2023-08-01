using Vaevi.Models.Common;
using Vaevi.Models.Enums;

namespace Vaevi.Models.RequestModels
{
    /// <summary>
    /// Contacts Search Request Model
    /// </summary>
    public class ContactSearchRequest : GetPagedListRequest
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string UserId { get; set; }

        public ContactOrderBy OrderBy
        {
            get => (ContactOrderBy)SortBy;
            set => SortBy = (short)value;
        }
    }
}
