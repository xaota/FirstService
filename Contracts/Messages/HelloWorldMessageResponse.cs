using Newtonsoft.Json;
using System;

namespace Modulbank.TelegramIntegration.Registration.Rinat.Messages
{
    public class HelloWorldMessageResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public HelloWorldMessageResponse(HelloWorldMessageRequest message, string splitter = ".")
        {
            Console.WriteLine(JsonConvert.SerializeObject(message));

            this.Id = message.Id;
            this.Name = message.Name + splitter + message.Name;
        }
    }
}

