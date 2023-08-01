namespace Vaevi.Interfaces
{
    /// <summary>
    /// Base repository interface Containing CRUD Operations
    /// </summary>
    public interface IBaseRepository<TDomainClass, in TKeyType>
        where TDomainClass : class
    {

        /// <summary>
        /// Update an Entity
        /// </summary>
        void Update(TDomainClass instance);

        /// <summary>
        /// Delete an Entity
        /// </summary>
        void Delete(TDomainClass instance);

        /// <summary>
        /// Add an Entity
        /// </summary>
        /// <param name="instance"></param>
        void Add(TDomainClass instance);
        
        /// <summary>
        /// Find an Entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="TDomainClass"/></returns>
        TDomainClass? Find(TKeyType id);

        /// <summary>
        /// Find an Entity Asynchronously
        /// </summary>
        /// <param name="id"><see cref="TKeyType"/></param>
        /// <returns><see cref="TDomainClass"/></returns>
        Task<TDomainClass?> FindAsync(TKeyType id);
        
        /// <summary>
        /// Get all Entities from Table
        /// </summary>
        /// <returns><see cref="IQueryable{TDomainClass}"/></returns>
        IQueryable<TDomainClass> GetAll();

        /// <summary>
        /// Save all tracked changes to the table
        /// </summary>
        /// <returns>Number of <see cref="int"/> rows affected</returns>
        Task<int> SaveChangesAsync();

    }
}