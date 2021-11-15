using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcServer.Protos;
using Microsoft.Extensions.Logging;
using ILogger = Grpc.Core.Logging.ILogger;

namespace GrpcServer.Services
{
    public class CustomerService:Customer.CustomerBase
    {
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            var output = new CustomerModel();
            switch (request.UserId)
            {
                case 1:
                    output.FirstName = "MohammadHossein";
                    output.LastName = "Nezhadhendi";
                    break;
                case 2:
                    output.FirstName = "Ahmad";
                    output.LastName = "Mansouri";
                    break;
                case 3:
                    output.FirstName = "Sepehr";
                    output.LastName = "Karimi";
                    break;
            }

            return Task.FromResult(output);
        }
    }
}
