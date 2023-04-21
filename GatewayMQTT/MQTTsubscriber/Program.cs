using System;
using System.Runtime.InteropServices;
using System.Text;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.IO;

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

                DateTime Tempo = DateTime.Now;

                int day = Tempo.Day;
                int month = Tempo.Month;
                int year = Tempo.Year;

                string Data = year.ToString() + "-" + month.ToString() + "-" + day.ToString();

                int Ore = Tempo.Hour;
                int Minuti = Tempo.Minute;
                int Secondi = Tempo.Second;

                string Ora = Ore.ToString() + ":" + Minuti.ToString() + ":" + Secondi.ToString();

                string ConnectionString = "server=10.49.134.1;database=restroomtime;uid=restroomtime;pwd=restroomtime;";
                MySqlConnection Connection = new MySqlConnection(ConnectionString);
                MySqlCommand cmd;

                try
                {
                    Connection.Open();
                    cmd = Connection.CreateCommand();

                    cmd.Connection = Connection;
                    cmd.CommandText = "INSERT INTO Movimenti (id_Term, id1, id2, id3, id4, Data, Ora) VALUES (@id_Term, @id1, @id2, @id3, @id4, @Data, @Ora)";
                    cmd.Parameters.AddWithValue("@id_Term", dataStruct.TerminalId);
                    cmd.Parameters.AddWithValue("@id1", dataStruct.id1);
                    cmd.Parameters.AddWithValue("@id2", dataStruct.id2);
                    cmd.Parameters.AddWithValue("@id3", dataStruct.id3);
                    cmd.Parameters.AddWithValue("@id4", dataStruct.id4);
                    cmd.Parameters.AddWithValue("@Data", Data);
                    cmd.Parameters.AddWithValue("@Ora", Ora);
                    //cmd.CommandText = "INSERT INTO Allievi.Nome, Allievi.Cognome, Movimenti.Data, Movimenti.Ora FROM Movimenti INNER JOIN Badge on(Movimenti.id1 = Badge.id1) INNER JOIN Allievi ON(Badge.IDBadge = Allievi.IDAllievo)";

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                Connection.Close();
            });

            await client.ConnectAsync(options);


            Console.ReadLine();

            await client.DisconnectAsync();

        }
    }
}
