using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vaevi.Interfaces.IRepository;
using Vaevi.Interfaces.IServices;
using Vaevi.Models.DomainModels;
using Vaevi.Models.RequestModels;
using Vaevi.Models.ResponseModels;
using Vaevi.Models.WebModels;

namespace Vaevi.Service
{
    public sealed class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ContactModel> FindAsync(string userId, int id)
        {
            var model = await _repository.FindAsync(id);
            if (model?.UserId != userId)
            {
                throw new ApplicationException("The record does not exist");
            }
            var mapped = _mapper.Map<ContactModel>(model);
            return mapped;
        }

        public async Task<IEnumerable<ContactModel>> FindByContactName(string userId, string name)
        {
            var list = await _repository.GetAll().Where(x => x.UserId == userId).Where(x => x.FullName.ToLower().Contains(name)).ToListAsync();
            return list.Select(x => _mapper.Map<ContactModel>(x));
        }

        public async Task<IEnumerable<ContactModel>> GetAll(string userId)
        {
            return (await _repository.GetAll().Where(x => x.UserId == userId).ToListAsync()).Select(x => _mapper.Map<ContactModel>(x));
        }

        public async Task<ContactModel> SaveOrUpdate(ContactModel model)
        {
            // Update case
            if (model.Id.GetValueOrDefault(0) != 0)
            {
                var oModel = await _repository.FindAsync(model.Id.GetValueOrDefault(0));
                if (oModel != null)
                {
                    oModel.FullName = model.FullName;
                    oModel.Phone = model.Phone;
                    oModel.Address = model.Address;
                    oModel.Email = model.Email;
                    _repository.Update(oModel);
                    await _repository.SaveChangesAsync();
                }
                return model;
            }
            else // Create Case
            {
                var oModel = _mapper.Map<Contact>(model);
                _repository.Add(oModel);
                await _repository.SaveChangesAsync();
                return model;
            }
        }

        public async Task<SearchResponse<ContactModel>> SearchAsync(ContactSearchRequest searchRequest)
        {
            var response = await _repository.SearchAsync(searchRequest);
            var oModel = new SearchResponse<ContactModel>
            {
                data = response.data.Select(x => _mapper.Map<ContactModel>(x)),
                recordsFiltered = response.recordsFiltered,
                recordsTotal = response.recordsTotal,
            };
            return oModel;
        }

        public async Task<int> Delete(string userId, int id)
        {
            var dbModel = await _repository.FindAsync(id);
            if (dbModel == null || dbModel.UserId != userId)
                throw new ApplicationException($"No such contact found to delete with id: {id}");
            _repository.Delete(dbModel);
            return await _repository.SaveChangesAsync();
        }
    }
}
