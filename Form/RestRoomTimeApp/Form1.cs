using System.Xml;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.IO;

namespace RestRoomTimeApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            using var reader = XmlReader.Create("config.xml");

            reader.ReadToFollowing("ip");
            var ip = reader.ReadElementContentAsString();
            reader.ReadToFollowing("db");
            var db = reader.ReadElementContentAsString();
            reader.ReadToFollowing("uid");
            var uid = reader.ReadElementContentAsString();
            reader.ReadToFollowing("pwd");
            var pwd = reader.ReadElementContentAsString();

            string connetionString = "server=" + ip + ";database=" + db + ";uid=" + uid + ";pwd=" + pwd + ";";
            
            */
            string connetionString = "server=localhost;database=restroomtime;uid=restroomtime;pwd=restroomtime";
            MySqlConnection cnn;
            cnn = new MySqlConnection(connetionString);
            MySqlCommand cmd;
            cnn.Open();
            cmd = cnn.CreateCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM classi";
                MySqlDataReader drClassi = cmd.ExecuteReader();
                while (drClassi.Read())
                {
                    listBoxClassi.Items.Add(drClassi.GetString(1));
                }
            }
            catch (Exception ex)
            {

            }
            cnn.Close();
        }

        private void textBoxCerca_TextChanged(object sender, EventArgs e)
        {
            string connetionString = "server=localhost;database=restroomtime;uid=restroomtime;pwd=restroomtime";
            MySqlConnection cnn;
            cnn = new MySqlConnection(connetionString);
            MySqlCommand cmd;
            cnn.Open();
            cmd = cnn.CreateCommand();
            try
            {
                listBoxClassi.Items.Clear();
                cmd.CommandText = "SELECT * FROM classi WHERE Nome like '%" + textBoxCerca.Text + "%'";
                MySqlDataReader drClassi = cmd.ExecuteReader();
                while (drClassi.Read())
                {
                    listBoxClassi.Items.Add(drClassi.GetString(1));
                }
            }
            catch (Exception ex)
            {

            }
            cnn.Close();
        }

        private void listBoxClassi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedClass = listBoxClassi.SelectedItem.ToString();
            string connetionString = "server=localhost;database=restroomtime;uid=restroomtime;pwd=restroomtime";
            MySqlConnection cnn;
            cnn = new MySqlConnection(connetionString);
            MySqlCommand cmd;
            cnn.Open();
            cmd = cnn.CreateCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM classi WHERE Nome like '" + SelectedClass + "'";
                MySqlDataReader drClassi = cmd.ExecuteReader();
                drClassi.Read();

                SelectedClass = drClassi.GetString(0);

            }
            catch (Exception ex)
            {

            }
            cnn.Close();

            cnn.Open();
            cmd = cnn.CreateCommand();
            try
            {
                comboBoxAlunni.Items.Clear();
                cmd.CommandText = "SELECT * FROM allievi WHERE IDClasse = " + SelectedClass;
                MySqlDataReader drAllievi = cmd.ExecuteReader();
                while (drAllievi.Read())
                {
                    comboBoxAlunni.Items.Add(drAllievi.GetString(2) + " " + drAllievi.GetString(1));
                }
            }
            catch (Exception ex)
            {

            }
            cnn.Close();
        }

        private void comboBoxAlunni_SelectedIndexChanged(object sender, EventArgs e)
        {
            card card = new card();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Data", "Data");
            dataGridView1.Columns.Add("Ora", "Ora");
            string SelectedStudent = comboBoxAlunni.SelectedItem.ToString();
            string Surname = SelectedStudent.Split(" ")[0];
            string Name = SelectedStudent.Split(" ")[1];
            string IDAlunno = "";
            string connetionString = "server=localhost;database=restroomtime;uid=restroomtime;pwd=restroomtime";
            MySqlConnection cnn;
            cnn = new MySqlConnection(connetionString);
            MySqlCommand cmd;
            cnn.Open();
            cmd = cnn.CreateCommand();
            try
            {

                cmd.CommandText = "SELECT * FROM Allievi WHERE Nome like '" + Name + "' AND Cognome like '" + Surname + "'";
                MySqlDataReader drAllievi = cmd.ExecuteReader();
                drAllievi.Read();

                labelDebug.Text = drAllievi.GetString(1) + " " + drAllievi.GetString(2) + " " + drAllievi.GetString(0);
                IDAlunno = drAllievi.GetString(0);
            }
            catch (Exception ex)
            {
                labelDebug.Text = ex.ToString();
            }
            cnn.Close();

            cnn.Open();
            cmd = cnn.CreateCommand();
            try
            {
                cmd.CommandText = "SELECT " +
                    "allievi.IDAllievo, allievi.Nome, allievi.Cognome, " +
                    "badge.id1, badge.id2, badge.id3, badge.id4 " +
                    "FROM allievi INNER JOIN badge on allievi.IDBadge = badge.IDBadge " +
                    "WHERE allievi.IDAllievo = " + IDAlunno;
                MySqlDataReader drID = cmd.ExecuteReader();
                drID.Read();
                card.id1 = drID.GetString(3);
                card.id2 = drID.GetString(4);
                card.id3 = drID.GetString(5);
                card.id4 = drID.GetString(6);
            }
            catch (Exception ex)
            {
                labelDebug.Text = ex.ToString();
            }
            cnn.Close();


            if(card.exists())
            {
                cnn.Open();
                cmd = cnn.CreateCommand();
                try
                {
                    dataGridView1.Rows.Clear();
                    cmd.CommandText = "SELECT ID_Badge, Data, Ora FROM Movimenti " +
                        "WHERE id1 = " + card.id1 + " AND id2 = " + card.id2 + " AND id3 = " + card.id3 + " AND id4 = " + card.id4;
                    MySqlDataReader drMovimenti = cmd.ExecuteReader();

                    while (drMovimenti.Read())
                    {
                        dataGridView1.Rows.Add(drMovimenti.GetString(0), drMovimenti.GetString(1).Split(" ")[0], drMovimenti.GetString(2));
                    }
                }
                catch (Exception ex)
                {
                    labelDebug.Text = ex.ToString();
                }
                cnn.Close();
            }
            else
            {
                labelDebug.Text = "L'utente non esiste";
            }
        }

        private void buttonAggiorna_Click(object sender, EventArgs e)
        {
            comboBoxAlunni_SelectedIndexChanged(sender,e);
        }
    }
    class card
    {
        public string id1;
        public string id2;
        public string id3;
        public string id4;

        public bool exists()
        {
            return (id1 != null && id2 != null && id3 != null && id4 != null) ? true : false;
        }
    }
}