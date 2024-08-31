﻿using System;
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
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            button1.Visible = false;
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
            cmd.Parameters.AddWithValue("@ID", (int)numericUpDown2.Value);
            cmd.Parameters.AddWithValue("@FirstName",(textBox1.Text));
            cmd.Parameters.AddWithValue("@MiddleName", (textBox2.Text));
            cmd.Parameters.AddWithValue("@LastName", (textBox3.Text));
            cmd.Parameters.AddWithValue("@Age", (int)numericUpDown1.Value);


            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Added succesfully");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.Visible = false;
                }
                else if (control is NumericUpDown)
                {
                    control.Visible = false;
                }
                else if (control is Label)
                {
                    control.Visible = false;
                }
                else
                {
                    control.Visible = true;
                }
                Read.Visible = false ;
                Create.Visible = false ;  
                Delete.Visible = false ;
                Update.Visible = false ;
            }
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

            con.Close();
            MessageBox.Show("Updated succesfully");
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
            button1.Visible = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}