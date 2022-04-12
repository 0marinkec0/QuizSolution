using Quiz.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Interface.Services
{
    public class Repository : IRepository
    {
        public Task AddAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetListAsync<T>()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
