using Microsoft.EntityFrameworkCore;
using RP.DataAccess.Model;
using RP.DataAccess.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RP.DataAccess.Repository
{
    public class CarRepository : Repository<Car, int>, ICarRepository
    {
        private readonly RPContext rpContext;

        public CarRepository(RPContext ctx) : base(ctx)
        {
            rpContext = ctx;
        }

        public async Task<IEnumerable<Car>> GetCarsByUserAsync(int userId)
        {
            return await rpContext.Car
                .Include(x => x.Users)
                .ThenInclude(x => x.User)
                .AsQueryable()
                .Where(x => x.Users.Any(u => u.UserId.Equals(userId)))
                .ToListAsync()
                ;
        }
    }
}
