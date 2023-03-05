using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Welcome to the Order Processor!");

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

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) => {
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Message received: {message}");
};

channel.BasicConsume(queue: "orders", autoAck: true, consumer: consumer);

var text = string.Empty;

while(text != "quit") {
    Console.WriteLine("Enter 'quit' for stop listenning the broker.");
    text = Console.ReadLine();
}

Console.ReadKey();