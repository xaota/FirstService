using Newtonsoft.Json;
using System;

namespace Modulbank.TelegramIntegration.Registration.Rinat.Messages
{
    public class HelloWorldMessageResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public HelloWorldMessageResponse(HelloWorldMessageRequest message)
        {
            Console.WriteLine(JsonConvert.SerializeObject(message));

            Id = message.Id;
            Name = message.Name + message.Name;
        }
    }
}

