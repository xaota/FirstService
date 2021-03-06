﻿using System;
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

using Modulbank.Serverless.Contracts.HydePark;
using Modulbank.TelegramIntegration.Registration.Rinat.Messages;

namespace FirstService
{
    public class AnimalAddRequestHandler : InternalRequestHandler<Animal, IdResult>
    {
        private readonly ICommonDbMapper _commonDbMapper;
        private readonly IHydeParkPublisher _hydeParkPublisher;


        public AnimalAddRequestHandler(ICommonDbMapper commonDbMapper, IHydeParkPublisher hydeParkPublisher)
        {
            _commonDbMapper = commonDbMapper;
            _hydeParkPublisher = hydeParkPublisher;

        }

        [Authorize("system")]
        [HttpPost]
        [Route("animal/add")]
        public override async Task<IdResult> Handle(Animal animal)
        {
            var id = Guid.NewGuid();
            // var name = animal.Name;
            animal.Id = id;
            await _commonDbMapper.ExecuteNonQueryOrThrowExceptionAsync("insert into animals (id, name) values (:id, :name) returning id", animal);
            // await _commonDbMapper.
            // return new AnimalResult{ Result = animals };

            HelloWorldMessageRequest response = new HelloWorldMessageRequest() {Id = 1, Name = "test"};
            await _hydeParkPublisher.PublishAsync(response);

            return new IdResult() {Id = id}; // Task<Guid>.FromResult(id);
        }
    }
}
