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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ConnectDB();
            SQL_AllTable();
            GetTableNames();
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;
        }
        private SQLiteConnection SQLiteConn;
        private void GetTableNames()
        {
            ///Form2 frm = new Form2();
            //string SQLQuery = "SELECT name FROM sqlite_master WHERE type ='table' ORDER BY name;";
            //SQLiteCommand command = new SQLiteCommand(SQLQuery, SQLiteConn);
            //SQLiteDataReader reader = command.ExecuteReader();
            SQLiteCommand command1 = SQLiteConn.CreateCommand();
            command1.CommandText = "SELECT История FROM История;";
            SQLiteDataReader reader1 = command1.ExecuteReader();
            //Image img = null;
            int i = 0;
            while (reader1.Read())
            {
                dataGridView1.Rows.Add(reader1[0].ToString());
                i++;
            }
            
            
        }
        private void ConnectDB()
        {
            SQLiteConn = new SQLiteConnection("Data Source=история.db;Version=3;");
            SQLiteConn.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = SQLiteConn;
        }
        private string SQL_AllTable()
        {
            return "SELECT * FROM [История] order by 1;";
        }
    }
}
