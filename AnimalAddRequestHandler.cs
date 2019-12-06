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
    public class AnimalAddRequestHandler : InternalRequestHandler<Animal, IdResult>
    {
        private readonly ICommonDbMapper _commonDbMapper;

        public AnimalAddRequestHandler(ICommonDbMapper commonDbMapper)
        {
            _commonDbMapper = commonDbMapper;
        }

        [Authorize("system")]
        [HttpPost]
        [Route("animal/add")]
        public override async Task<IdResult> Handle(Animal animal)
        {
            var id = Guid.NewGuid();
            // var name = animal.Name;
            animal.Id = id;
            await _commonDbMapper.ExecuteObjectAsync<Animal>("insert into animals (id, name) values (:id, :name)", animal);
            // await _commonDbMapper.
            // return new AnimalResult{ Result = animals };
            return new IdResult() {Id = id}; // Task<Guid>.FromResult(id);
        }
    }
}
