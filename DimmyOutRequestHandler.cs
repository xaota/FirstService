using System;
using System.Threading.Tasks;
using Modulbank.Serverless;
using Modulbank.Serverless.Contracts;
using Modulbank.Serverless.Contracts.RequestHandlers;
using Modulbank.Serverless.Contracts.RequestHandlers.Internal;
using Microsoft.AspNetCore.Mvc;
using Modulbank.Serverless.Contracts.Attributes;

namespace FirstService
{
    public class DimmyOutRequestHandler : InternalOutRequestHandler<DimmyOut>
    {
        [Authorize("system")]
        [HttpGet]
        [Route("dummy")]
        public override async Task<DimmyOut> Handle()
        {
            return new DimmyOut { Name = "Ринат" };
        }
    }
}
