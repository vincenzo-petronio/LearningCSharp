using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grpc.Service.DataAccess
{
    public interface IUserRepo
    {
        Task<List<UserModel>> GetUsersAsync();
    }
}
