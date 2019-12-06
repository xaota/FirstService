using System;
using System.Threading.Tasks;
using Modulbank.Serverless;
using Modulbank.Serverless.Contracts;
using Modulbank.Serverless.Contracts.RequestHandlers;
using Modulbank.Serverless.Contracts.RequestHandlers.Internal;
using Microsoft.AspNetCore.Mvc;
using Modulbank.Serverless.Contracts.Attributes;
using Modulbank.DbMapping.Contracts.NetCore;
using FirstService.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace FirstService
{
    public class DimmyOutRequestHandler : InternalOutRequestHandler<AnimalResult>
    {
        private readonly ICommonDbMapper _commonDbMapper;

        public DimmyOutRequestHandler(ICommonDbMapper commonDbMapper)
        {
            _commonDbMapper = commonDbMapper;
        }

        [Authorize("system")]
        [HttpGet]
        [Route("dummy")]
        public override async Task<AnimalResult> Handle()
        {
            var animals = (await _commonDbMapper.ExecuteListAsync<Animal>("select id, name from animals")).ToList();
            return new AnimalResult{ Result = animals };
        }
    }
}
