using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Vaevi.Interfaces;
using Vaevi.Interfaces.IRepository;
using Vaevi.Models.DomainModels;
using Vaevi.Models.Enums;
using Vaevi.Models.RequestModels;
using Vaevi.Models.ResponseModels;
using Vaevi.Repository.Data;

namespace Vaevi.Repository
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationDbContext context) : base(context)
        {
        }

        private readonly Dictionary<ContactOrderBy, Func<Contact, object>> _orderClause =
            new()
            {
                { ContactOrderBy.Name, o => o.FullName },
                { ContactOrderBy.Email, o => o.Email },
                { ContactOrderBy.Phone, o => o.Phone }
            };

        public async Task<SearchResponse<Contact>> SearchAsync(ContactSearchRequest searchRequest)
        {
            var fromRow = (searchRequest.PageNo - 1) * searchRequest.PageSize;
            var toRow = searchRequest.PageSize;
            Expression<Func<Contact, bool>> query =
                s =>
                   (s.UserId == searchRequest.UserId) &&
                   (string.IsNullOrEmpty(searchRequest.Email) || (s.Email.ToLower().Contains(searchRequest.Email.ToLower()))) &&
                   (string.IsNullOrEmpty(searchRequest.Name) || (s.FullName.ToLower().Contains(searchRequest.Name.ToLower()))) &&
                   (string.IsNullOrEmpty(searchRequest.Phone) || (s.Phone.ToLower().Contains(searchRequest.Phone.ToLower())));

            IEnumerable<Contact> data = searchRequest.IsAsc
                ? DbSet
                    .Where(query)
                    .OrderBy(_orderClause[searchRequest.OrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet
                    .Where(query)
                    .OrderByDescending(_orderClause[searchRequest.OrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();

            return new SearchResponse<Contact>
            {
                data = data,
                recordsTotal = data.Count(),
                recordsFiltered = await DbSet.CountAsync(query)
            };
        }

        protected override DbSet<Contact> DbSet => Db.Contacts;

        public override IQueryable<Contact> GetAll()
        {
            return DbSet.AsQueryable();
        }
    }
}
