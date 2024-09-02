using CRUD.Class;
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
using static CRUD.Model.PersonModel;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

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
            dataGridView.DataSource = dt;
            

            string maxIdQuery = "SELECT ISNULL(MAX(ID), 0) + 1 FROM Table_1";
            using (SqlCommand maxIdCmd = new SqlCommand(maxIdQuery, con))
            {
                int nextId = (int)maxIdCmd.ExecuteScalar();

                // Set the numericUpDown2 value to the next available ID
                idBox.Value = nextId;
            }

            // Close the connection
            con.Close();

        }
        public Form1()
        {
            InitializeComponent();
            ShowDataOnGridView();
            ageBox.Text = null;
            SqlConnection con = new SqlConnection("Data Source=JRGENGRACIAL\\SQLEXPRESS;Initial Catalog=\"CRUD App DB\";Integrated Security=True;Pooling=False;Encrypt=False");
           
            con.Open();
            string maxIdQuery = "SELECT ISNULL(MAX(ID), 0) + 1 FROM Table_1";
            using (SqlCommand maxIdCmd = new SqlCommand(maxIdQuery, con))
            {
                int nextId = (int)maxIdCmd.ExecuteScalar();

                // Set the numericUpDown2 value to the next available ID
                idBox.Value = nextId;
            }

        }

  

        public void ClearData()
        {

            Create.Visible = true;
            firstNameBox.Text = "";
            middleNameBox.Text = "";
            lastNameBox.Text = "";
            ageBox.Value = 0;
            
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
            try
            {
                Form1Class form1 = new Form1Class();

                CreateModel cm = new CreateModel();
                cm.Age = (int)ageBox.Value; cm.FirstName = firstNameBox.Text;
                cm.MiddleName = middleNameBox.Text; cm.LastName = lastNameBox.Text;

                form1.CreateFunction(cm);
                ShowDataOnGridView();
                ClearData();
            }
            catch (Exception)
            {
                MessageBox.Show("Process Insertion Error");
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
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
            try
            {
                Form1Class form1 = new Form1Class();

                UpdateModel cm = new UpdateModel();
                cm.ID = (int)idBox.Value; cm.FirstName = firstNameBox.Text;
                cm.Age = (int)ageBox.Value; cm.FirstName = firstNameBox.Text;
                cm.MiddleName = middleNameBox.Text; cm.LastName = lastNameBox.Text;

                form1.UpdateFunction(cm);
                ShowDataOnGridView();
                ClearData();
            }
            catch (Exception)
            {
                MessageBox.Show("Process Insertion Error");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                Form1Class form1 = new Form1Class();

                DeleteModel cm = new DeleteModel();
                cm.ID = (int)idBox.Value;

                form1.DeleteFunction(cm);
                ShowDataOnGridView();
                ClearData();
            }
            catch (Exception)
            {
                MessageBox.Show("Process Insertion Error");
            }
        


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
           

            idBox.Value = Convert.ToDecimal(this.dataGridView.CurrentRow.Cells["ID"].Value);
            firstNameBox.Text = this.dataGridView.CurrentRow.Cells["FirstName"].Value.ToString();
            middleNameBox.Text = this.dataGridView.CurrentRow.Cells["MiddleName"].Value.ToString();
            ageBox.Value = Convert.ToDecimal(this.dataGridView.CurrentRow.Cells["Age"].Value);
            lastNameBox.Text = this.dataGridView.CurrentRow.Cells["LastName"].Value.ToString();
            
            Create.Visible = false;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            ShowDataOnGridView();
            Create.Visible = true;
            ClearData();
        }

        private void lastNameBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
