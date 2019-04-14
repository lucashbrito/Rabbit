using Rabbit.Core.Interface;
using RabbitMQ.Client;
using System;

namespace Rabbit.Core
{
    public class ConsumerFactory : IConsumerFactory
    {
        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private string HostName;
        private string UserName;
        private string Password;
        protected bool Enable = true;
        protected IBasicProperties Properties { get; set; }
        protected IModel Model { get; set; }
        protected string QueueName { get; set; }
        protected string ExchangeName { get; set; }
        public ConsumerFactory(string queueName, string exchangeName, string hostName, string userName, string password)
        {
            QueueName = queueName;
            ExchangeName = exchangeName;
            HostName = hostName;
            UserName = userName;
            Password = password;
            Console.WriteLine($"Queue {QueueName}, Exchange {ExchangeName}");
        }
        public void CreateConnection()
        {
            _connectionFactory = new ConnectionFactory()
            {
                HostName = HostName,
                UserName = UserName,
                Password = Password
            };

            _connection = _connectionFactory.CreateConnection();
            Model = _connection.CreateModel();
        }
        public void CreateBasicProperties(bool persistent)
        {
            Properties = Model.CreateBasicProperties();
            Properties.Persistent = persistent;
        }

    }

}


