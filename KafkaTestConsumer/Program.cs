using Confluent.Kafka;

namespace KafkaTestConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConsumerConfig
            {
                GroupId = "gid-consumers",
                BootstrapServers = "localhost:9092"
            };

            using(var consumer = new ConsumerBuilder<Null, string>(config).Build())
            {
                consumer.Subscribe("TestTopic");
                while (true)
                {
                    var record = consumer.Consume();
                    Console.WriteLine(record.Message.Value);
                }
            }
        }
    }
}