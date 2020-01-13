using Modulbank.Serverless.Contracts.HydePark;
using Modulbank.ServiceBusNetCore.Contracts;
using System.Threading.Tasks;
using Modulbank.ServiceBusNetCore.Contracts.Attributes;

using Modulbank.TelegramIntegration.Registration.Rinat.Messages;

using FirstService;

[MessageHandler(GembaQueueEnum.GembaQueue)]
public class HelloWorldMessageRequestHandler : HydeParkMessageHandler<HelloWorldMessageRequest>
{
  private readonly IHydeParkPublisher _hydeParkPublisher;

  public HelloWorldMessageRequestHandler(IHydeParkPublisher hydeParkPublisher) {
    _hydeParkPublisher = hydeParkPublisher;
  }

  public override Task HandleMessage(HelloWorldMessageRequest message) {
    HelloWorldMessageResponse response = new HelloWorldMessageResponse(message);
    return _hydeParkPublisher.PublishAsync(response);
  }
}
