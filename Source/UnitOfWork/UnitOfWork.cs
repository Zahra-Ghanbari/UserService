using Interfaces;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork
{
    public class UnitOfWork<TEntity> :  IUnitOfWork<TEntity> where TEntity: class
    {
        private readonly IRepository<TEntity> _repository;
        public UnitOfWork(IRepository<TEntity> repository)
        {
            _repository=repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public DbContext Context => this._repository.GetDbContext();

        /// <summary>
        /// Applys the changes on the database.
        /// </summary>
        /// <returns>Returns <c>true</c> if the changes applied successfully, otherwise returns <c>false</c>.</returns>
        public bool Commit()
        {
            int effectedRows = 0;
            try
            {
                effectedRows = this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return effectedRows > 0;
        }

        /// <summary>
        /// Disposes the context object.
        /// </summary>
        public void Dispose()
        {
            this.Context.Dispose();
        }

        /// <summary>
        /// Gets an <see cref="IRepository{TEntity}"/> instance
        /// </summary>
        /// <returns>Returns an <see cref="IRepository{TEntity}"/></returns>
        public IRepository<TEntity> GetRepository()
        {
            return this._repository;
        }
    }
}
