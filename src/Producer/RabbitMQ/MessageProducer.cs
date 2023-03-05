using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;

namespace Producer.RabbitMQ {
    public class MessageProducer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory {
                HostName = "localhost",
                Port = 5672,
                VirtualHost = "workforce",
                UserName = "foreman",
                Password = "w0rkf0rc3!"
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare("orders", exclusive: false);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "orders", body: body);
        }
    }
}