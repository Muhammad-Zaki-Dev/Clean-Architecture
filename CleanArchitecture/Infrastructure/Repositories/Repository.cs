using Domain.Generic;
using Infrastructure.Presistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> dbSet;

        public Repository(ApplicationContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            
        }

        public async Task DeleteAsync(Guid Id)
        {
            var entity = await dbSet.FindAsync(Id);
            dbSet.Remove(entity);
          
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public  void Update(T entity)
        {
            dbSet.Update(entity);
        
        }
    }
}
