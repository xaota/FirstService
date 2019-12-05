using System;
using System.Threading.Tasks;
using Modulbank.Serverless;
using Modulbank.Serverless.Contracts;
using Modulbank.Serverless.Contracts.RequestHandlers;
using Modulbank.Serverless.Contracts.RequestHandlers.Internal;
using Microsoft.AspNetCore.Mvc;
using Modulbank.Serverless.Contracts.Attributes;
using Modulbank.DbMappingNetCore.IoC;
using Modulbank.DbMapping.Contracts;
using System.Collections.Generic;
using System.Linq;
using FirstService.Contracts;

namespace FirstService
{
    public class DimmyOutRequestHandler : InternalOutRequestHandler<List<Animal>>
    {
        private readonly ICommonDbMapper _commonDbMapper;
        public DimmyOutRequestHandler(ICommonDbMapper commonDbMapper) {
            _commonDbMapper = commonDbMapper;
        }

        [Authorize("system")]
        [HttpGet]
        [Route("dummy")]
        public override async Task<List<Animal>> Handle()
        {
            var animals = await _commonDbMapper.ExecuteListAsync<Animal>("select id, name from animals");
            return animals.ToList();
            // return new DimmyOut { Name = "Ринат" };
        }
    }
}
