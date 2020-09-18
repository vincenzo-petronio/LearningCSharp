using Microsoft.EntityFrameworkCore;
using RP.DataAccess.Model;
using RP.DataAccess.Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace RP.DataAccess.Repository
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        private readonly RPContext rpContext;

        public UserRepository(RPContext ctx) : base(ctx)
        {
            rpContext = ctx;
        }

        public async Task<User> GetTopUserAsync()
        {
            return await
                rpContext.User
                // Many-To-Many relationship
                .Include(x => x.Cars)
                .ThenInclude(x => x.Car)
                .AsQueryable()
                .OrderByDescending(x => x.Cars.Count)
                .FirstAsync()
                ;
        }
    }
}
