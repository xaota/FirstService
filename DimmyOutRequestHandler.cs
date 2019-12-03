using System;
using System.Threading.Tasks;
using Modulbank.Serverless;
using Modulbank.Serverless.Contracts;
using Modulbank.Serverless.Contracts.RequestHandlers;
using Modulbank.Serverless.Contracts.RequestHandlers.Internal;

namespace FirstService
{
    public class DimmyOutRequestHandler : InternalOutRequestHandler<DimmyOut>
    {
        public override async Task<DimmyOut> Handle()
        {
            return new DimmyOut { Name = "Ринат" };
        }
    }
}
