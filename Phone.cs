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


        private void Phone_Load(object sender, EventArgs e)
        {
            /* Example of how to change cursor's focus
             ActiveControl = textBox2;
             textBox2.Focus();*/

            DisplayContactsInfo();
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
            VALUES   ('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')", connection);

            cmd.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Your new contact has been successfully saved!");
            DisplayContactsInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM dbo.Mobiles
            WHERE   (Mobile = '" + textBox3.Text + "')", connection);

            cmd.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Your contact has been successfully deleted!");
            DisplayContactsInfo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE dbo.Mobiles
            SET FirstName = '" + textBox1.Text + "', LastName = '" + textBox2.Text + "', Mobile = '" + textBox3.Text + "', Email = '" + textBox4.Text + "', Category = '" + comboBox1.Text + "' WHERE (Mobile = '" + textBox3.Text + "')", connection);

            cmd.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Your new contact has been successfully updated!");
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

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM dbo.Mobiles WHERE (Mobile LIKE '%" + textBox5.Text + "%') OR (LastName LIKE '%" + textBox5.Text + "%' ) OR (FirstName LIKE '%" + textBox5.Text + "%' )", connection);
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

    }
}
