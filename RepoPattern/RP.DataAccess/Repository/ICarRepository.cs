using RP.DataAccess.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RP.DataAccess.Repository
{
    public interface ICarRepository : IRepository<Car, int>
    {
        /// <summary>
        /// Tutte le car possedute dall'user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<Car>> GetCarsByUserAsync(int userId);
    }
}
