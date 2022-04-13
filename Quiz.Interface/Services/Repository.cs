using Microsoft.EntityFrameworkCore;
using Quiz.Application.Common.Interfaces;
using Quiz.Domain.Entites;
using Quiz.Interface.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Interface.Services
{
    public class Repository : IRepository
    {
        private readonly QuizDbContext _dbContext;

        public Repository(QuizDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync<T>(T entity) where T : BaseEntity
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync<T>(int id) where T : BaseEntity
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);

            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : BaseEntity
        {
            var query =  _dbContext.Set<T>().AsQueryable();

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<T>> GetListAsync<T>() where T : BaseEntity
        {
            var query = _dbContext.Set<T>().AsQueryable();
            return await query.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
