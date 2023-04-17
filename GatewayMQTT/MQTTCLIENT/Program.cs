using System;
using System.Runtime.InteropServices;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;

namespace MQTTCLIENT
{
     class Publisher
    {
        static async Task Main(string[] args)
        {
           var mqttFactory = new MqttFactory();
           IMqttClient client = mqttFactory.CreateMqttClient();
           var options = new MqttClientOptionsBuilder()
                              .WithClientId(Guid.NewGuid().ToString())
                              .WithTcpServer("broker.hivemq.com",1883)
                              .WithCleanSession()
                              .Build();

            client.UseConnectedHandler(e =>
            {
                Console.WriteLine("Connessione al broker effettuata");
            });
            client.UseDisconnectedHandler(e =>
            {
                Console.WriteLine("Disconnessione al broker effettuata");
            });


            await client.ConnectAsync(options);

            Console.WriteLine("Premi un tasto per pubblicare il messaggio");
            Console.ReadLine();

            await PublishMessageAsync(client);

            await client.DisconnectAsync();
        }

        private static async Task PublishMessageAsync(IMqttClient client)
        {
            string messagePayload = "Term:2;Cod:202-119-4-134";
            var message = new MqttApplicationMessageBuilder()
                              .WithTopic("RestroomTime23")
                              .WithPayload(messagePayload)
                              .WithAtLeastOnceQoS()
                              .Build();

            if (client.IsConnected)
            {
                Console.WriteLine("pubblicato");
                await client.PublishAsync(message);
            }

        }
    }
}