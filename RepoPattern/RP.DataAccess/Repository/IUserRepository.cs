using RP.DataAccess.Model;
using System.Threading.Tasks;

namespace RP.DataAccess.Repository
{
    public interface IUserRepository : IRepository<User, int>
    {
        /// <summary>
        /// Restituisce l'User con più Car
        /// </summary>
        /// <returns></returns>
        Task<User> GetTopUserAsync();
    }
}
