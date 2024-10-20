using Microsoft.EntityFrameworkCore;
using RespositoryPatternWithUOW.Core.Consts;
using RespositoryPatternWithUOW.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryPatternWithUOW.EF.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext Context)
        {
            _context = Context;
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
            return entities;
        }

        public T Find(Expression<Func<T, bool>> predicate, string[] includes=null)
        {
            IQueryable<T> query=_context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    query=query.Include(include);

            return query.SingleOrDefault(predicate);
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, string[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            if(includes!=null)
                foreach (var include in includes)
                    query=query.Include(include);
            return query.Where(predicate).ToList();
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, int take, int skip)
        {
            return _context.Set<T>().Where(predicate).Take(take).Skip(skip).ToList();
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
