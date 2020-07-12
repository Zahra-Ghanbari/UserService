using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    /// <summary>
    /// This generic interface provides repository functionalities.
    /// </summary>
    /// <typeparam name="TEntity">A specific model in DbContext.</typeparam>
    public interface IRepository<TEntity> :IDisposable where TEntity:class
    {
        /// <summary>
        /// Adds an entity to DbContext.
        /// </summary>
        /// <param name="entity">A specific model in DbContext.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Gets the DbContext of repository.
        /// </summary>
        /// <returns></returns>
        DbContext GetDbContext();
    }
}
