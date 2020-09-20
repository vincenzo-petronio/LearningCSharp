using Grpc.Net.Client;
using Grpc.Service;
using LearnigCSharp.gRPC;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Grpc.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello gRPC Client!!!");

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client1 = new Greeter.GreeterClient(channel);
            var response1 = await client1.SayHelloAsync(new HelloRequest { Name = "Grpc.Client" });
            Console.WriteLine(response1.Message);

            var client2 = new IUser.IUserClient(channel);
            var response2 = await client2.GetUserAsync(new GetUserReq { Id = 5 });
            Console.WriteLine($"{JsonSerializer.Serialize(response2)}");
            var response3 = await client2.GetUserDetailsAsync(new GetUserReq { Id = 5 });
            Console.WriteLine($"{JsonSerializer.Serialize(response3)}");
            Console.ReadKey();
        }
    }
}
