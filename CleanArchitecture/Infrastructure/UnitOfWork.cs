using Domain.Entities;
using Domain.Generic;
using Infrastructure.Presistance;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext applicationContext;
        public IRepository<Category> Categories { get; }
        public IRepository<SubCategory> SubCategories { get; }
        public UnitOfWork(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
            Categories = new Repository<Category>(applicationContext);
            SubCategories = new Repository<SubCategory>(applicationContext);
        }

        public async Task<int> CommitChanges()
        {
           return await applicationContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            applicationContext.Dispose();

        }
    }
}
