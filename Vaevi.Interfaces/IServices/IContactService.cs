using Vaevi.Models.RequestModels;
using Vaevi.Models.ResponseModels;
using Vaevi.Models.WebModels;

namespace Vaevi.Interfaces.IServices
{
    public interface IContactService
    {
        Task<ContactModel> FindAsync(string userId,int id);
        Task<IEnumerable<ContactModel>> FindByContactName(string userId, string name);
        Task<IEnumerable<ContactModel>> GetAll(string userId);
        Task<ContactModel> SaveOrUpdate(ContactModel model);
        Task<SearchResponse<ContactModel>> SearchAsync(ContactSearchRequest searchRequest);
        Task<int> Delete(string userId, int id);
    }
}
