using System;

namespace Rabbit.Service
{
    class Program
    {
        static string HostName = "localhost";
        static string UserName = "guest";
        static string Password = "guest";
        static string QueueName;
        static string ExchangeName;
        static void Main(string[] args)
        {
            ConsumerService();
        }

        static void ConsumerService()
        {
            QueueName = "Basic";
            ExchangeName = "Basic";
            var consumer = new ConsumerService(QueueName, ExchangeName, HostName, UserName, Password);

            consumer.RabbitConsumer();
            consumer.Start();
        }
    }
}
