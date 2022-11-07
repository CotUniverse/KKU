using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms;


namespace ККУ.Forms
{
    public partial class FormPok : Form
    {
        public FormPok()
        {
            InitializeComponent();
            MaximizeBox = false;
            ConnectDB();
            SQL_AllTable();
           // GetTableNames();

        }
        private SQLiteConnection SQLiteConn;
        class uslugi
        {
            public double otoplenie = 1584.28;
            public double hot_water = 124.02;
            public double cold_water = 21.4;
            public double elecro = 3.08;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string data = DateTime.Now.ToLongDateString() + "-" + DateTime.Now.ToLongTimeString();
            listBox1.Items.Add(data);
            double summa = 0;
            uslugi zena = new uslugi();
            if (checkBox2.Checked)
            {
                summa += zena.otoplenie;
                listBox1.Items.Add($"Цена за отопление = {zena.otoplenie}");
            }
            if (comboBox1.SelectedIndex != -1)
            {
                checkBox6.CheckState = CheckState.Checked;
                if (comboBox1.SelectedIndex == 0) { summa += 27.46; listBox1.Items.Add($"Цена за содержание = 27,46"); }
                if (comboBox1.SelectedIndex == 1) { summa += 28.11; listBox1.Items.Add($"Цена за содержание = 28,11"); }
                if (comboBox1.SelectedIndex == 2) { summa += 19.55; listBox1.Items.Add($"Цена за содержание = 19.55"); }
                if (comboBox1.SelectedIndex == 3) { summa += 19.75; listBox1.Items.Add($"Цена за содержание = 19.75"); }
                if (comboBox1.SelectedIndex == 4) { summa += 20.42; listBox1.Items.Add($"Цена за содержание = 20.42"); }
                if (comboBox1.SelectedIndex == 5) { summa += 20.42; listBox1.Items.Add($"Цена за содержание = 20.42"); }
                if (comboBox1.SelectedIndex == 6) { summa += 21.11; listBox1.Items.Add($"Цена за содержание = 21.11"); }
                if (comboBox1.SelectedIndex == 7) { summa += 22.65; listBox1.Items.Add($"Цена за содержание = 22.65"); }
                if (comboBox1.SelectedIndex == 8) { summa += 23.34; listBox1.Items.Add($"Цена за содержание = 23.34"); }
                if (comboBox1.SelectedIndex == 9) { summa += 24.55; listBox1.Items.Add($"Цена за содержание = 24.55"); }
                if (comboBox1.SelectedIndex == 10) { summa += 25.22; listBox1.Items.Add($"Цена за содержание = 25.22"); }

            }
            if (checkBox5.Checked)
            {
                double hot_water = Convert.ToDouble(numericUpDown3.Value) * zena.hot_water; summa += hot_water;
                listBox1.Items.Add($"Цена за куб.м горячей воды = {zena.hot_water}, итого = {hot_water}");
            }
            if (checkBox4.Checked)
            {
                double cold_water = Convert.ToDouble(numericUpDown2.Value) * zena.cold_water; summa += cold_water;
                listBox1.Items.Add($"Цена за куб.м холодной воды = {zena.cold_water}, итого = {cold_water}");
            }
            if (checkBox3.Checked)
            {
                double electro = Convert.ToDouble(numericUpDown1.Value) * zena.elecro; summa += electro;
                listBox1.Items.Add($"Цена за электричество кВт/час= {zena.elecro}, итого = {electro}");
            }


            listBox1.Items.Add($"Итоговая цена: {summa}");
            string SQL = "INSERT INTO История VALUES(@История) ";
            SQLiteCommand cmd = new SQLiteCommand(SQL);
            cmd.Connection = SQLiteConn;

            
            cmd.Parameters.AddWithValue("Истоория ", Convert.ToString(DateTime.Now));

            foreach (string s in listBox1.Items)
            {
                SQL = "INSERT INTO История VALUES(@История) ";
                cmd = new SQLiteCommand(SQL);
                cmd.Connection = SQLiteConn;
                //n += s + ";"; 

                cmd.Parameters.AddWithValue("История", s);
                

                cmd.ExecuteNonQuery();
            }
            cmd.Parameters.AddWithValue("История", "");
            
            cmd.ExecuteNonQuery();
        }


        private string SQL_AllTable()
        {
            return "SELECT * FROM [История] order by 1;";
        }
        private void ConnectDB()
        {
            SQLiteConn = new SQLiteConnection("Data Source=история.db;Version=3;");
            SQLiteConn.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = SQLiteConn;
        }
    }
}
