using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
        Task BeginTransactionAsync();
        Task RollbackTransactionAsync();
        Task CommitTransactionAsync();
    }
}
