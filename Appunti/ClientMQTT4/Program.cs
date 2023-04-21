using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System;
using System.Text;

namespace MQTTSubscriber
{
    class Program
    {
        static async Task Main(string[] args) {
            var mqttFactory = new MqttFactory();
            IMqttClient client = mqttFactory.CreateMqttClient();
            var option = new MqttClientOptionsBuilder()
                            .WithClientId(Guid.NewGuid().ToString())
                            .WithTcpServer("broker.hivemq.com", 1883)
                            .WithCleanSession()
                            .Build();

            client.UseConnectedHandler(async e =>
            {
                Console.WriteLine("Sono riuscito a collegarmi al broker");
                var topicfilter = new TopicFilterBuilder()
                                    .WithTopic("RestroomTime23")
                                    .Build();
                await client.SubscribeAsync(topicfilter);

            });
            client.UseDisconnectedHandler(e => 
            {
                Console.WriteLine("Mi sono disconnesso dal broker");
            });

            client.UseApplicationMessageReceivedHandler(e =>
            {
                Console.WriteLine($"Ricevuto: " +
                    $"{Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");

            });

            await client.ConnectAsync(option);

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(5); 

            var timer = new System.Threading.Timer((e) =>
            {
                string message = "I'm Alive";
                var msg = new MqttApplicationMessageBuilder()
                                .WithTopic("RestroomTime23")
                                .WithPayload(message)
                                .WithAtLeastOnceQoS()
                                .Build();
                if (client.IsConnected)
                {
                    client.PublishAsync(message);
                    Console.WriteLine("Messaggio alive inviato");
                }
                
            }, null, startTimeSpan, periodTimeSpan);

            Console.WriteLine("Premi un tasto per pubblicare");
            Console.ReadLine();

            await client.DisconnectAsync();
            
        }

        private void ImAlive()
        {

        }
    }
}