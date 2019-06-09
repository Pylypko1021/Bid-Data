using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.Common;
using BrightIdeasSoftware;




namespace BigBD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fastObjectListView1.VirtualMode = false;

            LoadData();


        }
        private void LoadData()
        {




            string serverName = "localhost"; // Адрес сервера (для локальной базы пишите "localhost")
            string userName = "root"; // Имя пользователя
            string dbName = "ranok"; //Имя базы данных
            string port = "3306"; // Порт для подключения
            string password = "gegyhegut619"; // Пароль для подключения
            string connStr = "server=" + serverName +
                ";user=" + userName +
                ";database=" + dbName +
                ";port=" + port +
                ";password=" + password + ";";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(@"SELECT * FROM udcr", conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable("udcr");
            da.Fill(table);
            listView1.View = View.Details;
            fastObjectListView1.View = View.Details;
            ListViewItem iItem;

            foreach (DataRow row in table.Rows)
            {
                iItem = new ListViewItem();
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    if (i == 0)
                        iItem.Text = row.ItemArray[i].ToString();
                    else
                        iItem.SubItems.Add(row.ItemArray[i].ToString());
                }
                listView1.Items.Add(iItem);
                // fastObjectListView1.Items.Add(iItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            listView1.Items.Clear();
            string serverName = "localhost"; // Адрес сервера (для локальной базы пишите "localhost")
            string userName = "root"; // Имя пользователя
            string dbName = "ranok"; //Имя базы данных
            string port = "3306"; // Порт для подключения
            string password = "gegyhegut619"; // Пароль для подключения
            string connStr = "server=" + serverName +
                ";user=" + userName +
                ";database=" + dbName +
                ";port=" + port +
                ";password=" + password + ";";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            String id1 = Convert.ToString(textBox1.Text);
            String id2 = Convert.ToString(textBox2.Text);
            String date1 = Convert.ToString(textBox3.Text);
            String date2 = Convert.ToString(textBox4.Text);

            string query = "";
            if (textBox3.Text == "" && textBox4.Text == "")
            {
                query = "SELECT * FROM udcr WHERE frequency_start BETWEEN @id1 AND @id2 ORDER BY frequency_start ASC";
            }
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                query = "SELECT * FROM udcr WHERE date BETWEEN @date1 AND @date2 ORDER BY frequency_start ASC";
            }
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                query = "SELECT * FROM udcr WHERE frequency_start BETWEEN @id1 AND @id2 AND date BETWEEN @date1 AND @date2 ORDER BY frequency_start ASC";
            }

            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("id1", id1);
            command.Parameters.AddWithValue("id2", id2);
            command.Parameters.AddWithValue("date1", date1);
            command.Parameters.AddWithValue("date2", date2);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable table = new DataTable("udcr");
            da.Fill(table);
            listView1.View = View.Details;
            fastObjectListView1.View = View.Details;
            ListViewItem iItem;

            foreach (DataRow row in table.Rows)
            {
                iItem = new ListViewItem();
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    if (i == 0)
                        iItem.Text = row.ItemArray[i].ToString();
                    else
                        iItem.SubItems.Add(row.ItemArray[i].ToString());
                }
                listView1.Items.Add(iItem);
                /*
                MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[16]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
                data[data.Count - 1][8] = reader[8].ToString();
                data[data.Count - 1][9] = reader[9].ToString();
                data[data.Count - 1][10] = reader[10].ToString();
                data[data.Count - 1][11] = reader[11].ToString();
                data[data.Count - 1][12] = reader[12].ToString();
                data[data.Count - 1][13] = reader[13].ToString();
                data[data.Count - 1][14] = reader[14].ToString();
                data[data.Count - 1][15] = reader[15].ToString();

            }

            reader.Close();

            conn.Close();

            foreach (string[] s in data)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(s.ToString());
                listView1.Columns.A(item);
            }
            */

            }
        }
    }
}
