namespace Rabbit.Core.Interface
{
    public interface IConsumerFactory
    {
        void CreateConnection();
        void CreateBasicProperties(bool persistent);
    }
}
