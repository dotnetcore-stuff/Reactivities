using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace API.Kafka
{
    public class SampleStore
    {
        public SampleStore()
        {
            
        }

        public async Task<bool> Publish(string message)
        {
            
            var config = new ProducerConfig{ BootstrapServers = "127.0.0.1:9092"};
            Action<DeliveryReport<Null, string>> handler = r => 
                Console.WriteLine(!r.Error.IsError ? $"Message Delivered To {r.TopicPartitionOffset}"
                : $"Error {r.Error.Reason}");
            using(var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                // var strValue = "";
                // for(int i =0; i < 100; i++) 
                // {
                //     strValue += $"Sample_{i}_";
                //     await producer.ProduceAsync("sample-topic", new Message<Null, string>{Value = strValue});
                // }
                var result = await producer.ProduceAsync("testtopic", new Message<Null, string>{Value = message});
                Console.WriteLine($"Event {message} sent on Partition: {result.Partition} with Offset: {result.Offset}");
                producer.Flush(TimeSpan.FromSeconds(10));
            }

            return true;
                
        }
    }
}