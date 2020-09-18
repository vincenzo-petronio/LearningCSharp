using RP.DataAccess.Model;
using RP.DataAccess.Persistence;

namespace RP.DataAccess.Repository
{
    public class UserCarRepository : Repository<UserCar, int>, IUserCarRepository
    {
        private readonly RPContext rpContext;

        public UserCarRepository(RPContext ctx) : base(ctx)
        {
            rpContext = ctx;
        }
    }
}
