using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


static async Task Main()
{
    // The Service Bus client types are safe to cache and use as a singleton for the lifetime
    // of the application, which is best practice when messages are being published or read
    // regularly.
    //
    // Create the clients that we'll use for sending and processing messages.
    string connectionString = "Endpoint=sb://onlinebookreader.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=PsoW/Net3u3KL7Z/Zx6gNlwJdIGgz5D+G5x2ADKAqd8=";
    string topicName = "onlinebookreaderqueue";
    int numOfMessages = 3;
    ServiceBusClient client = new ServiceBusClient(connectionString);
    ServiceBusSender sender = client.CreateSender(topicName);

    // create a batch 
    using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

    for (int i = 1; i <= numOfMessages; i++)
    {
        // try adding a message to the batch
        if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}")))
        {
            // if it is too large for the batch
            throw new Exception($"The message {i} is too large to fit in the batch.");
        }
    }

    try
    {
        // Use the producer client to send the batch of messages to the Service Bus topic
        await sender.SendMessagesAsync(messageBatch);
        Console.WriteLine($"A batch of {numOfMessages} messages has been published to the topic.");
    }
    finally
    {
        // Calling DisposeAsync on client types is required to ensure that network
        // resources and other unmanaged objects are properly cleaned up.
        await sender.DisposeAsync();
        await client.DisposeAsync();
    }

    Console.WriteLine("Press any key to end the application");
    Console.ReadKey();
}