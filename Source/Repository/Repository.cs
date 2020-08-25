using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    /// <summary>
    /// This generic class provides repository functionalities.
    /// </summary>
    /// <typeparam name="TEntity">A specific model in DbContext.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        private DbContext Context { get; }
        internal readonly DbSet<TEntity> dbSet;
        
        /// <summary>
        /// Initialize an instance of repository.
        /// </summary>
        /// <param name="context"></param>
        public Repository(DbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));        
            this.dbSet = this.Context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }
        public void Dispose()
        {
            Context.Dispose();
        }
        public DbContext GetDbContext()
        {
            return this.Context;
        }
    }
}
