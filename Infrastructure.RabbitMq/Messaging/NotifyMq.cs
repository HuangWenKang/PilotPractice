using Application.Messaging;
using Domain.Events;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Configuration;
using System.Text;

namespace Infrastructure.RabbitMq.Messaging
{
    public class NotifyMq : INotifyMq
    {
        private readonly string ExchangeName;
        private readonly string RouteKey;
        private readonly string QueueName;
        private readonly string ExchhangeType;

        public NotifyMq()
        {
            ExchangeName = ConfigurationManager.AppSettings["ExchangeName"];
            RouteKey = ConfigurationManager.AppSettings["RouteKey"];
            QueueName = ConfigurationManager.AppSettings["QueueName"];
            ExchhangeType = ConfigurationManager.AppSettings["ExchhangeType"];
        }

        public void SendLoggedEventMessage(LoggedEvent loggedEvent)
        {
            //var onlineStoreMqUserName = Environment.GetEnvironmentVariable("ONLINE_STORE_MQ_USERNAME");
            //var onlineStoreMqPassword = Environment.GetEnvironmentVariable("ONLINE_STORE_MQ_PASSWORD");
            //var onlineStoreMqServer = Environment.GetEnvironmentVariable("ONLINE_STORE_MQ_SERVER");

            var onlineStoreMqUserName = "user";
            var onlineStoreMqPassword = "password";
            var onlineStoreMqServer = "localhost";

            var factory = new ConnectionFactory()
            { HostName = onlineStoreMqServer, UserName = onlineStoreMqUserName, Password = onlineStoreMqPassword };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

                channel.ExchangeDeclare(ExchangeName, ExchhangeType);

                channel.QueueDeclare(queue: QueueName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                channel.QueueBind(queue: QueueName, exchange: ExchangeName, routingKey: RouteKey);

                string customerData = JsonConvert.SerializeObject(loggedEvent);
                var body = Encoding.UTF8.GetBytes(customerData);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: ExchangeName,
                                     routingKey: RouteKey,
                                     basicProperties: properties,
                                     body: body);
            }
        }
    }
}
