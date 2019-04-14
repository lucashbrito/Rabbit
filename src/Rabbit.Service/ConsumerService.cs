using System;
using System.Text;
using Rabbit.Core;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Rabbit.Service
{
    public class ConsumerService : ConsumerFactory 
    {
        public ConsumerService(string queueName, string exchangeName, string hostName, string userName, string password) : base(queueName, exchangeName, hostName, userName, password)
        {
        }

        public void RabbitConsumer()
        {
            CreateConnection();

            CreateBasicProperties(true);

            Model.BasicQos(0, 1, false);
        }

        public void Start()
        {
            var consumer = new QueueingBasicConsumer(Model);

            Model.BasicConsume(QueueName, false, consumer);

            while (Enable)
            {
                //get next message
                var deliveryArgs = (BasicDeliverEventArgs)consumer.Queue.DequeueNoWait(new BasicDeliverEventArgs() { ConsumerTag = "0" });

                if (deliveryArgs.ConsumerTag == "0")
                {
                    Enable = false;
                    continue;
                }
                //serialize message
                var message = Encoding.Default.GetString(deliveryArgs.Body);

                Console.WriteLine($"Message received {message}");

                Model.BasicAck(deliveryArgs.DeliveryTag, false);
            }
        }
    }
}
