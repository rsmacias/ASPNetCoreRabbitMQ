# ASP.Net Core with RabbitMQ

Simple example of using the Broker Messages RabbitMQ. For this sample _Producer_ project is a Web API for adding new Orders. Besides adding the orders into an In-Memory Database, it also *publish/produce* the orders (message) asynchronously into a _Queue_. 
The _Subscriber_ project is a simple console project to *subscribe/consume* the messages (orders) by a RabbitMQ event. So, once the subscriber gets the orders it can process them.


This example got performed by following this [Tutorial](https://code-maze.com/aspnetcore-rabbitmq/)

## Execution
In order to test this sample, first you need to set up and run a docker container with RabbitMQ. If you need assitance for this please refer to the following links:

- [Install RabbitMQ](https://medium.com/bina-nusantara-it-division/a-beginners-guideline-to-rabbitmq-and-masstransit-part-1-rabbitmq-and-how-to-install-it-ab91e1dc65ad)
- [Security](https://medium.com/bina-nusantara-it-division/a-beginners-guideline-to-rabbitmq-and-masstransit-part-2-user-access-management-and-good-practice-e5dbab49699c)  * Optional

Once you have set up the container, please change the following values for yours into the _Program.cs_, and _MessageProducer.cs_ files. 

``` csharp
var factory = new ConnectionFactory {
    HostName = "localhost",
    Port = 5672,
    VirtualHost = "workforce",
    UserName = "foreman",
    Password = "w0rkf0rc3!"
};
```