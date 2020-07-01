using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelephoneDiary
{
    public partial class Phone : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Phone;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public Phone()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            //cursor focusing on textBox1 
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO dbo.Mobiles
            (FirstName,LastName,Mobile,Email,Category)
            VALUES   
            ('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')", connection);

            cmd.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Your new contact has been successfully saved!");
            DisplayContactsInfo();
        }

        void DisplayContactsInfo()
        {
            //SqlDataAdapter automatically open and close the connection
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM dbo.Mobiles", connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            //loop through each table's row
            foreach (DataRow item in dt.Rows)
            {
                int newRow = dataGridView1.Rows.Add();
                dataGridView1.Rows[newRow].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[newRow].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[newRow].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[newRow].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[newRow].Cells[4].Value = item[4].ToString();

            }


        }

        private void Phone_Load(object sender, EventArgs e)
        {
            /* Example of how to change cursor's focus
             ActiveControl = textBox2;
             textBox2.Focus();*/

            DisplayContactsInfo();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
