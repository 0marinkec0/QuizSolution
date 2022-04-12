using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Common.Interfaces
{
    public interface IRepository
    {
        Task AddAsync<T>(T entity);
        Task<List<T>> GetListAsync<T>();
        Task<T> GetByIdAsync<T>(int id);
        Task DeleteAsync<T>(int id);
        Task SaveAsync();
    }
}
