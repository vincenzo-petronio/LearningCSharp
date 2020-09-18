using Microsoft.EntityFrameworkCore;
using RP.DataAccess.Model;
using System;
using System.Threading.Tasks;

namespace RP.DataAccess.Repository
{
    public interface IUnitOfWork<TDbContext> : IDisposable where TDbContext : DbContext
    {
        int Save();

        IUserRepository UserRepository { get; }
        ICarRepository CarRepository { get; }
        IUserCarRepository UserCarRepository { get; }
    }
}
