using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public class MessageLogic : IMessageLogic
    {
        private readonly ILogger<MessageLogic> _logger;   
        public MessageLogic(ILogger<MessageLogic> logger) 
        { 
            _logger = logger;
        }
        public void SendingMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/"
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            _logger.LogInformation("Connection to RabbitMQ established");

            channel.QueueDeclare("uploadDocument", durable: true, exclusive: false);

            var jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);

            channel.BasicPublish("", "uploadDocument", body: body);
            _logger.LogInformation($"successfully produced {jsonString} to uploadDocument queue");
        }
    }
}
