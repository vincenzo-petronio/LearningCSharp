using RP.DataAccess.Model;
using RP.DataAccess.Persistence;
using System;
using System.Threading.Tasks;

namespace RP.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork<RPContext>
    {
        private readonly RPContext rpContext;
        private IUserRepository userRepository;
        private ICarRepository carRepository;
        private IUserCarRepository userCarRepository;

        public UnitOfWork(RPContext ctx)
        {
            this.rpContext = ctx;
        }

        public IUserRepository UserRepository
        {
            get
            {
                return userRepository ?? (userRepository = new UserRepository(rpContext));
            }
        }

        public ICarRepository CarRepository => carRepository ?? (carRepository = new CarRepository(rpContext));
        public IUserCarRepository UserCarRepository => userCarRepository ?? (userCarRepository = new UserCarRepository(rpContext));

        public int Save()
        {
            //return await rpContext.SaveChangesAsync();
            return rpContext.SaveChanges();
        }

        public void Dispose()
        {
            rpContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
