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

namespace CRUD
{
    public partial class Form1 : Form
    {
       

        public void ShowDataOnGridView()
        {
            SqlConnection con = new SqlConnection("Data Source=JRGENGRACIAL\\SQLEXPRESS;Initial Catalog=\"CRUD App DB\";Integrated Security=True;Pooling=False;Encrypt=False");
            con.Open();
            string readQuery = "SELECT * FROM Table_1";
            SqlDataAdapter sda = new SqlDataAdapter(readQuery, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sda);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            

            string maxIdQuery = "SELECT ISNULL(MAX(ID), 0) + 1 FROM Table_1";
            using (SqlCommand maxIdCmd = new SqlCommand(maxIdQuery, con))
            {
                int nextId = (int)maxIdCmd.ExecuteScalar();

                // Set the numericUpDown2 value to the next available ID
                numericUpDown2.Value = nextId;
            }

            // Close the connection
            con.Close();

        }
        public Form1()
        {
            InitializeComponent();
            ShowDataOnGridView();
            numericUpDown1.Text = null;
            SqlConnection con = new SqlConnection("Data Source=JRGENGRACIAL\\SQLEXPRESS;Initial Catalog=\"CRUD App DB\";Integrated Security=True;Pooling=False;Encrypt=False");
           
            con.Open();
            string maxIdQuery = "SELECT ISNULL(MAX(ID), 0) + 1 FROM Table_1";
            using (SqlCommand maxIdCmd = new SqlCommand(maxIdQuery, con))
            {
                int nextId = (int)maxIdCmd.ExecuteScalar();

                // Set the numericUpDown2 value to the next available ID
                numericUpDown2.Value = nextId;
            }

        }

        public void ClearData()
        {
        
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            numericUpDown1.Text = null;


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection("Data Source=JRGENGRACIAL\\SQLEXPRESS;Initial Catalog=\"CRUD App DB\";Integrated Security=True;Pooling=False;Encrypt=False");
            SqlCommand cmd = new SqlCommand("Insert into Table_1 values(@ID, @FirstName, @MiddleName, @LastName, @Age)", con);
            con.Open();

            string checkIdQuery = "SELECT COUNT(*) FROM Table_1 WHERE ID = @ID";
            using (SqlCommand checkIdCmd = new SqlCommand(checkIdQuery, con))
            {
                checkIdCmd.Parameters.AddWithValue("@ID", (int)numericUpDown2.Value);
                int idCount = (int)checkIdCmd.ExecuteScalar();

                if (idCount > 0)
                {
                    MessageBox.Show("ID already exists. Please use a different ID.");
                    return; // Exit the method
                }

                cmd.Parameters.AddWithValue("@ID", (int)numericUpDown2.Value);
                cmd.Parameters.AddWithValue("@FirstName", (textBox1.Text));
                cmd.Parameters.AddWithValue("@MiddleName", (textBox2.Text));
                cmd.Parameters.AddWithValue("@LastName", (textBox3.Text));
                cmd.Parameters.AddWithValue("@Age", (int)numericUpDown1.Value);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Added succesfully");
                ShowDataOnGridView();
                ClearData();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection("Data Source=JRGENGRACIAL\\SQLEXPRESS;Initial Catalog=\"CRUD App DB\";Integrated Security=True;Pooling=False;Encrypt=False");
            string readQuery = "SELECT * FROM Table_1";
            SqlDataAdapter sda = new SqlDataAdapter(readQuery, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sda);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt; 
            
            con.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=JRGENGRACIAL\\SQLEXPRESS;Initial Catalog=\"CRUD App DB\";Integrated Security=True;Pooling=False;Encrypt=False");
            SqlCommand cmd = new SqlCommand("Update Table_1 set FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName where ID = @ID", con);
            con.Open();
         
            cmd.Parameters.AddWithValue("@ID", (int)numericUpDown2.Value);
            cmd.Parameters.AddWithValue("@FirstName", (textBox1.Text));
            cmd.Parameters.AddWithValue("@MiddleName", (textBox2.Text));
            cmd.Parameters.AddWithValue("@LastName", (textBox3.Text));
            cmd.Parameters.AddWithValue("@Age", (int)numericUpDown1.Value);
            cmd.ExecuteNonQuery();

           
            MessageBox.Show("Updated succesfully");
            
            ClearData();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=JRGENGRACIAL\\SQLEXPRESS;Initial Catalog=\"CRUD App DB\";Integrated Security=True;Pooling=False;Encrypt=False");
            SqlCommand cmd = new SqlCommand("Delete Table_1 where ID = @ID", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", (int)numericUpDown2.Value);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted succesfully");
            ShowDataOnGridView();
            ClearData();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach(Control control in this.Controls)
            {
                if(control is DataGridView)
                {
                    control.Visible = false;
                }
                else
                {
                    control.Visible = true;
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            numericUpDown2.Value = Convert.ToDecimal(this.dataGridView1.CurrentRow.Cells["ID"].Value);
            textBox1.Text = this.dataGridView1.CurrentRow.Cells["FirstName"].Value.ToString();
            textBox2.Text = this.dataGridView1.CurrentRow.Cells["MiddleName"].Value.ToString();
            textBox3.Text = this.dataGridView1.CurrentRow.Cells["LastName"].Value.ToString();
            numericUpDown1.Value = Convert.ToDecimal(this.dataGridView1.CurrentRow.Cells["Age"].Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
         
        }
    }
}
