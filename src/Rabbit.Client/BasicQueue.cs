using Rabbit.Client;
using Rabbit.Core;

namespace Rabbit.Client
{
    public class BasicQueue : ConsumerFactory
    {
        public BasicQueue(string queueName, string exchangeName, string hostName, string userName, string password) : base(queueName, exchangeName, hostName, userName, password)
        {
            CreateConnection();
            CreateBasicProperties(persistent: true);
        }
        public void CreateBasicQueue(byte[] body)
        {
            Properties.ContentType = "application/json";
            Model.BasicPublish(ExchangeName, QueueName, false, Properties, body);
        }
    }
}
