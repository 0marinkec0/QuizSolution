using Quiz.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Common.Interfaces
{
    public interface IRepository
    {
        Task AddAsync<T>(T entity) where T : BaseEntity;
        Task<List<T>> GetListAsync<T>() where T : BaseEntity;
        Task<T> GetByIdAsync<T>(int id) where T : BaseEntity;
        Task DeleteAsync<T>(int id) where T : BaseEntity;
        Task SaveAsync();
    }
}
