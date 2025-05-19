using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Generic
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<SubCategory> SubCategories { get; }
        Task<int> CommitChanges();
    }
}
