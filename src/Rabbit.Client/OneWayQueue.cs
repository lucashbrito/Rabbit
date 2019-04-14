using Rabbit.Core;

namespace Rabbit.Client
{
    public class OneWayQueue : ConsumerFactory
    {
        public OneWayQueue(string queueName, string exchangeName, string hostName, string userName, string password) : base(queueName, exchangeName, hostName, userName, password)
        {
            CreateConnection();
            CreateBasicProperties(true);
        }

        public void CreateOneWayQueue(byte[] body)
        {
            Model.BasicPublish(ExchangeName, QueueName, false, Properties, body);
        }
    }
}
