using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.Service.DataAccess
{
    public class UserModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }

        public string CurrentAddress { get; set; }
        public string CurrentCap { get; set; }
        public string CurrentCity { get; set; }

        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Pec { get; set; }
    }
}
