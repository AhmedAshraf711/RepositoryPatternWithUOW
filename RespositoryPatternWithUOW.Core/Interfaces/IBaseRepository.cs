using RespositoryPatternWithUOW.Core.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryPatternWithUOW.Core.Interfaces
{
    public interface IBaseRepository<T> where T :class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        T Find(Expression<Func<T,bool>> predicate,string[] includes);
       IEnumerable<T> FindAll(Expression<Func<T,bool>> predicate,string[] includes);
       IEnumerable<T> FindAll(Expression<Func<T,bool>> predicate,int take,int skip);
       T Add(T entity);
       IEnumerable<T> AddRange(IEnumerable<T> entities);
 
    }
}
