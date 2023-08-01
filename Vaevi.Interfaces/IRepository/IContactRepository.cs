using Vaevi.Models.DomainModels;
using Vaevi.Models.RequestModels;
using Vaevi.Models.ResponseModels;

namespace Vaevi.Interfaces.IRepository
{
    public interface IContactRepository : IBaseRepository<Contact, int>
    {
        Task<SearchResponse<Contact>> SearchAsync(ContactSearchRequest searchRequest);
    }
}
