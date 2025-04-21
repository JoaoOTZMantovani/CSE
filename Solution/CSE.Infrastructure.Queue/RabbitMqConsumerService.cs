using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Hosting;

namespace CSE.Infrastructure.Queue;

public class RabbitMqConsumerService : BackgroundService
{
    private readonly string Hostname = "localhost";
    private readonly string UserName = "guest";
    private readonly string Password = "guest";
    private readonly int Port = 5672;

    private readonly string QueueName = "cse.api-initial.queue";

    private IChannel? _channel;

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        var factory = new ConnectionFactory
        {
            HostName = Hostname,
            UserName = UserName,
            Password = Password,
            Port = Port
        };

        var connection = await factory.CreateConnectionAsync(cancellationToken);

        _channel = await connection.CreateChannelAsync();

        await _channel.QueueDeclareAsync(
            queue: QueueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        await base.StartAsync(cancellationToken);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (_channel == null)
        {
            throw new InvalidOperationException("Channel is not initialized.");
        }

        var consumer = new AsyncEventingBasicConsumer(_channel);

        consumer.ReceivedAsync += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine($"Received message: {message}");

            await _channel.BasicAckAsync(ea.DeliveryTag, false);
        };

        _channel.BasicConsumeAsync(
            queue: QueueName,
            consumerTag: "cse.api",
            autoAck: false,
            consumer: consumer
        );

        return Task.CompletedTask;
    }
}
