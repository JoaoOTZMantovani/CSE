using RabbitMQ.Client;

namespace CSE.Infrastructure.Queue;

public class RabbitMqAbstractions
{
    private readonly string Hostname = "localhost";
    private readonly string UserName = "guest";
    private readonly string Password = "guest";

    public async Task<IConnection> CreateConnection()
    {
        var factory = new ConnectionFactory
        {
            HostName = Hostname,
            UserName = UserName,
            Password = Password
        };

        return await factory.CreateConnectionAsync();
    }
}
