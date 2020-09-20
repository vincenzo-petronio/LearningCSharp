using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Service.DataAccess;
using LearnigCSharp.gRPC;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.Service.Services
{
    public class UserService : IUser.IUserBase
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepo userRepo;
        private readonly List<UserModel> listUm;

        public UserService(ILogger<UserService> logger, IUserRepo userRepository)
        {
            _logger = logger;
            userRepo = userRepository;
            listUm = userRepo.GetUsersAsync().GetAwaiter().GetResult();
        }

        #region [Impl IUser]
        public override Task<GetUserRes> GetUser(GetUserReq request, ServerCallContext context)
        {
            UserModel um = listUm.First(um => um.Id == request.Id);

            return Task.FromResult(new GetUserRes
            {
                User = new User
                {
                    Id = (ulong)um.Id,
                    Name = um.Name,
                    Surname = um.Surname,
                    Birthday = Timestamp.FromDateTime(um.BirthDay)
                }
            });
        }

        public override Task<GetUserDetailsRes> GetUserDetails(GetUserReq request, ServerCallContext context)
        {
            UserModel um = listUm.First(um => um.Id == request.Id);

            var userDetails = new UserDetails();
            userDetails.CurrentAddress = new UserLocation
            {
                Address = um.CurrentAddress,
                Cap = um.CurrentCap,
                City = um.CurrentCity
            };
            userDetails.User = new User
            {
                Id = (ulong)um.Id,
                Name = um.Name,
                Surname = um.Surname,
                Birthday = Timestamp.FromDateTime(um.BirthDay)
            };
            userDetails.Contact.Add(new UserContact { Name = um.Email, Type = UserContact.Types.ContactType.Email });
            userDetails.Contact.Add(new UserContact { Name = um.Pec, Type = UserContact.Types.ContactType.Pec });

            return Task.FromResult(new GetUserDetailsRes
            {
                UserDetails = userDetails
            });
        }
        #endregion
    }
}
