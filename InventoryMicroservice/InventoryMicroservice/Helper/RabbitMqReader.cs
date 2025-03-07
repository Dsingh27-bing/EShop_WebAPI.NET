using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace InventoryMicroservice.Helper;

public class RabbitMqReader
{
    private ConnectionFactory _connectionFactory;
    public async Task ReadMessage(Func<string,string> reader)
    {
        _connectionFactory = new ConnectionFactory();
        _connectionFactory.Uri = new Uri("amqp://guest:guest@localhost:5672");
        _connectionFactory.ClientProvidedName = "Inventory Service";
        
        var connection = await _connectionFactory.CreateConnectionAsync();
        var channel = await connection.CreateChannelAsync();
        string exchangeName = "orderExchange";
        string routingkey = "order-api-routing-key";
        string queueName = "order-api-queue";
        channel.ExchangeDeclareAsync(exchangeName, ExchangeType.Direct, true);
        channel.QueueDeclareAsync(queueName,false,false, false,null);
        channel.QueueBindAsync(queueName, exchangeName, routingkey,null);
        channel.BasicQosAsync(0,1,false);
        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            string message = Encoding.UTF8.GetString(body);
            reader(message);
            Console.WriteLine(" [x] Received {0}", message);
            await channel.BasicAckAsync(ea.DeliveryTag, false);
        };
        
        Task<string> str = channel.BasicConsumeAsync(queueName, false, consumer);
        channel.BasicCancelAsync(JsonSerializer.Serialize(str));
        channel.CloseAsync();
        connection.CloseAsync();
    }
}