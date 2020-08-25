using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    /// <summary>
    /// This Interface provides some functionalities to apply database operations on storage.
    /// </summary>
    /// <typeparam name="TEntity">A specific model in DbContext.</typeparam>
    public interface IUnitOfWork<TEntity> :IDisposable where TEntity: class
    {
        /// <summary>
        /// Gets the current repository which work on TEntity.
        /// </summary>
        /// <returns>Returns a repository.</returns>
        IRepository<TEntity> GetRepository();

        /// <summary>
        /// Applys the changes on the database.
        /// </summary>
        /// <returns>Returns <c>true</c> if the changes applied successfully, otherwise returns <c>false</c>.</returns>
        bool Commit();

    }

}
