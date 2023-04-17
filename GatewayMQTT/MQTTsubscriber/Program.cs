using System;
using System.Runtime.InteropServices;
using System.Text;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;

namespace MQTTCLIENT
{
    class SubScriber
    {
        class DataStruct
        {
            public int TerminalId;
            public int id1;
            public int id2;
            public int id3;
            public int id4;
        }
        static async Task Main(string[] args)
        {
            var mqttFactory = new MqttFactory();
            IMqttClient client = mqttFactory.CreateMqttClient();
            var options = new MqttClientOptionsBuilder()
                               .WithClientId(Guid.NewGuid().ToString())
                               .WithTcpServer("broker.hivemq.com", 1883)
                               .WithCleanSession()
                               .Build();

            client.UseConnectedHandler(async e =>
            {
                Console.WriteLine("Connessione al broker effettuata");
                var topicFilter = new TopicFilterBuilder()
                                      .WithTopic("RestroomTime23")
                                      .Build();
                client.SubscribeAsync(topicFilter);
            });
            client.UseDisconnectedHandler(e =>
            {
                Console.WriteLine("Disconnessione al broker effettuata");
            });
            client.UseApplicationMessageReceivedHandler(e =>
            {
                string message = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                DataStruct dataStruct = new DataStruct();


                Console.WriteLine($"Raw - {message} ");
                string[] campi = message.Split(';', ':', '-');

                dataStruct.TerminalId = Convert.ToInt32(campi[1]);
                dataStruct.id1 = Convert.ToInt32(campi[3]);
                dataStruct.id2 = Convert.ToInt32(campi[4]);
                dataStruct.id3 = Convert.ToInt32(campi[5]);
                dataStruct.id4 = Convert.ToInt32(campi[6]);

                Console.WriteLine(dataStruct.id1);


                cmd.CommandText = "INSERT into DaTI (IDTerm, ID1, ID2, ID3, ID4, DATA) VALUES (@idterm, @id1, @id2, @id3, @id4, @data)";

                cmd.Parameters.AddWithValue("@idterm", dataStruct.TerminalId);


            });

            await client.ConnectAsync(options);

 
            Console.ReadLine();

            await client.DisconnectAsync();
        }
    }
}
  