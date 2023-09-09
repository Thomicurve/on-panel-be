﻿using Common.Bases;
using Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace Common.Repository
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T : EntityBase
    {
        private readonly OnPanelContext _dbContext;
        private DbSet<T> _entities;

        public RepositoryBase(OnPanelContext dbContext) 
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<T>();
        }

        public void Delete(int id)
        {
            T? entity = _entities.FirstOrDefault(x => x.Id == id);
            if(entity == null)
            {
                throw new Exception("No se encontró el registro");
            } else
            {
                _entities.Remove(entity);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public T? GetById(int id)
        {
            return _entities.SingleOrDefault(s => s.Id == id);
        }

        public void Update(T entity)
        {
            if(entity.Id == 0)
            {
                _entities.Add(entity);
            } else
            {
                _entities.Update(entity);
            }

            _dbContext.SaveChanges();
        }
    }
}