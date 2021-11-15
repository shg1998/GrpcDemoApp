using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcServer;
using GrpcServer.Protos;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var input = new HelloRequest {Name = "Mohammad"};
            //var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //var client = new Greeter.GreeterClient(channel);
            //var reply = await client.SayHelloAsync(input);
            //Console.WriteLine(reply.Message);

            var channel  = GrpcChannel.ForAddress("https://localhost:5001");
            var customerClient = new Customer.CustomerClient(channel);
            var clientinput = new CustomerLookupModel {UserId = 1};
            var reply = await customerClient.GetCustomerInfoAsync(clientinput);

            Console.WriteLine(reply.FirstName);
            Console.WriteLine(reply.LastName);
            Console.ReadLine();
        }
    }
}
