namespace API.Services
{
    using Microsoft.Extensions.Hosting;
    using System.Threading;
    using System.Threading.Tasks;
    using System;
    using Newtonsoft.Json;
    using Confluent.Kafka;
    using Domain;
    using System.Collections.Generic;

    public class ProcessOrders
    {

        public Task Process(CancellationToken cancellationToken)
        {
            const int commitPeriod = 5;
            var config = new ConsumerConfig { BootstrapServers = "127.0.0.1:9092", GroupId = "test-consumer" };


            // Create the consumer
            using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
            {

                Console.WriteLine($"Subscribing to Kafka Topic {"testtopic"}");
                // Subscribe to the Kafka topic
                consumer.Subscribe(new List<string>() { "testtopic" });
                try
                {
                    while (true)
                    {
                        try
                        {
                            var consumeResult = consumer.Consume(cancellationToken);

                            if (consumeResult.IsPartitionEOF)
                            {
                                Console.WriteLine(
                                    $"Reached end of topic {consumeResult.Topic}, partition {consumeResult.Partition}, offset {consumeResult.Offset}.");

                                continue;
                            }

                            Console.WriteLine($"Received message at {consumeResult.TopicPartitionOffset}: {consumeResult.Message.Value}");

                            if (consumeResult.Offset % commitPeriod == 0)
                            {
                                try
                                {
                                    consumer.Commit(consumeResult);
                                }
                                catch (KafkaException e)
                                {
                                    Console.WriteLine($"Commit error: {e.Error.Reason}");
                                }
                            }
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Consume error: {e.Error.Reason}");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Closing consumer.");
                    consumer.Close();
                }
            }

            return Task.Run(() => true);
        }
    }
}
