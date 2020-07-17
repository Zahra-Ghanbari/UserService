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
            _repository=repository;
        }
        public DbContext Context => this._repository.GetDbContext();

        public int Commit()
        {
            return this.Context.SaveChanges();
        }
        //?
        public void Dispose()
        {
            this.Context.Dispose();
        }

        public IRepository<TEntity> GetRepository()
        {
            return this._repository;
        }
    }
}
