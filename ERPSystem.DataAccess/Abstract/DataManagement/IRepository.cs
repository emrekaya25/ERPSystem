using ERPSystem.Entity.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccess.Abstract.DataManagement
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Filter = null, params string[] IncludeProperties);
        Task<EntityEntry<T>> AddAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task RemoveAsync(T Entity);
    }
}
