using Grpc.Core;
using LearnigCSharp.gRPC.v1;
using Newtonsoft.Json;
using System;

namespace Grpc.OldClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello .NET Framework gRPC Client!!!");
            var channel = new Channel("localhost", 5000, ChannelCredentials.Insecure);
            var client = new IUser.IUserClient(channel);
            var response = client.GetUserDetails(new GetUserReq { Id = 10 });
            Console.WriteLine($"{JsonConvert.SerializeObject(response)}");

            Console.ReadKey();
        }
    }
}
