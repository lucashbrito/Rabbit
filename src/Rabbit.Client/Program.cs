using System;
using System.Text;

namespace Rabbit.Client
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
            var message = Console.ReadLine();
            BasicQueue(message);

            message = Console.ReadLine();
            OneWayQueue(message);
        }

        static void BasicQueue(string message)
        {
            QueueName = "Basic";
            ExchangeName = "Basic";
            var messageBuffer = Encoding.Default.GetBytes($"'prop:'{message}'");

            var basicQueue = new BasicQueue(QueueName, ExchangeName, HostName, UserName, Password);

            basicQueue.CreateBasicQueue(messageBuffer);
        }

        static void OneWayQueue(string message)
        {
            QueueName = "OneWay";
            ExchangeName = "OneWay";
            var messageBuffer = Encoding.Default.GetBytes($"'prop:'{message}'");
            var oneWay = new OneWayQueue(QueueName, ExchangeName, HostName, UserName, Password);

            oneWay.CreateOneWayQueue(messageBuffer);
        }
    }
}
