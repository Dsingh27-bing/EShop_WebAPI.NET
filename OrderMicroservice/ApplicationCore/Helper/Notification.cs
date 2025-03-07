using System.Text;
using RabbitMQ.Client;
using RabbitMQ;

namespace ApplicationCore.Helper;

public class Notification
{
    private ConnectionFactory _connectionFactory;

    public Notification()
    {
        
        
    }
    
    public async Task AddMessagetoQueue(string message)
    {
        _connectionFactory = new ConnectionFactory();
        _connectionFactory.Uri = new Uri("amqp://guest:guest@localhost:5672");
        _connectionFactory.ClientProvidedName = "Order Service";
        
        var connection = await _connectionFactory.CreateConnectionAsync();
        var channel = await connection.CreateChannelAsync();
        string exchangeName = "orderExchange";
        string routingkey = "order-api-routing-key";
        string queueName = "order-api-queue";
        channel.ExchangeDeclareAsync(exchangeName, ExchangeType.Direct, true);
        channel.QueueDeclareAsync(queueName,false,false,false,null);
        channel.QueueBindAsync(queueName, exchangeName, routingkey);
        byte[] messageBodyBytes = Encoding.UTF8.GetBytes(message);
        await channel.BasicPublishAsync(exchangeName, routingkey, true, messageBodyBytes, CancellationToken.None);
        // channel.CloseAsync();
        // connection.CloseAsync();
    }

}