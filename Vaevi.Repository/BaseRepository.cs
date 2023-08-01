using Microsoft.EntityFrameworkCore;
using Vaevi.Interfaces;

namespace Vaevi.Repository
{

    /// <summary>
    /// Base Repository Containing Commonly used CRUD Operations
    /// </summary>
    public abstract class BaseRepository<TDomainClass> : IBaseRepository<TDomainClass, int>
       where TDomainClass : class 
    {
        #region Protected

        /// <summary>
        /// Primary database set
        /// </summary>
        protected abstract DbSet<TDomainClass> DbSet { get; }

        #endregion
        #region Constructor

        protected BaseRepository(IApplicationDbContext context)
        {
            Db = context;
        }

        #endregion

        #region Public
        /// <summary>
        /// base Db Context
        /// </summary>
        public IApplicationDbContext Db;

        /// <summary>
        /// Find Entity by Id
        /// </summary>
        public virtual TDomainClass? Find(int id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Find Entity by Id
        /// </summary>
        public virtual TDomainClass? Find(string id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Find Entity by Id
        /// </summary>
        public virtual TDomainClass? Find(long id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Find Entity by Id
        /// </summary>
        public virtual TDomainClass? Find(Guid id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Find Entity by Id
        /// </summary>
        public virtual async Task<TDomainClass?> FindAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        /// <summary>
        /// Find Entity by Id
        /// </summary>
        public virtual async Task<TDomainClass?> FindAsync(string id)
        {
            return await DbSet.FindAsync(id);
        }

        /// <summary>
        /// Find Entity by Id
        /// </summary>
        public virtual async Task<TDomainClass?> FindAsync(long id)
        {
            return await DbSet.FindAsync(id);
        }

        /// <summary>
        /// Find Entity by Id
        /// </summary>
        public virtual async Task<TDomainClass?> FindAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        /// <summary>
        /// Get All Entities 
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TDomainClass> GetAll()
        {
            return DbSet.AsQueryable();
        }

        /// <summary>
        /// Save Changes Async in the entities
        /// </summary>
        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }

        /// <summary>
        /// Delete an entry
        /// </summary>
        public virtual void Delete(TDomainClass instance)
        {
            DbSet.Remove(instance);
        }
        
        /// <summary>
        /// Add an entry
        /// </summary>
        public virtual void Add(TDomainClass instance)
        {
            DbSet.Add(instance).State = EntityState.Added;
        }

        /// <summary>
        /// Add an entry
        /// </summary>
        public virtual void Update(TDomainClass instance)
        {
            DbSet.Update(instance).State = EntityState.Modified;
        }

        #endregion
    }
}
