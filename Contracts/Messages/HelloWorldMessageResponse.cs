namespace Modulbank.TelegramIntegration.Registration.Rinat.Messages
{
    public class HelloWorldMessageResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public HelloWorldMessageResponse(HelloWorldMessageRequest message, string splitter = ".")
        {
            Id = message.Id;
            Name = message.Name + splitter + message.Name;
        }
    }
}

