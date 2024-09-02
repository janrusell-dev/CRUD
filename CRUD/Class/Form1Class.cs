using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static CRUD.Model.PersonModel;

namespace CRUD.Class
{
    internal class Form1Class : IForm1
    {
        public void CreateFunction(CreateModel create)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(create.FirstName))
                {
                    MessageBox.Show("First Name cannot be empty.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(create.LastName))
                {
                    MessageBox.Show("Last Name cannot be empty.");
                    return;
                }
                int age = (int)create.Age;

                // Validate the Age input
                if (age <= 0)
                {
                    MessageBox.Show("Age must be a positive integer.");
                    return;
                }


                SqlConnection con = new SqlConnection("Data Source=JRGENGRACIAL\\SQLEXPRESS;Initial Catalog=\"CRUD App DB\";Integrated Security=True;Pooling=False;Encrypt=False");
                SqlCommand cmd = new SqlCommand("Insert into Table_1 values(@FirstName, @MiddleName, @LastName, @Age)", con);
                con.Open();

                cmd.Parameters.AddWithValue("@FirstName", create.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", create.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", create.LastName);
                cmd.Parameters.AddWithValue("@Age", create.Age);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Added succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        public void UpdateFunction(UpdateModel update)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(update.FirstName))
                {
                    MessageBox.Show("First Name cannot be empty.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(update.LastName))
                {
                    MessageBox.Show("Last Name cannot be empty.");
                    return;
                }
                int age = (int)update.Age;

                // Validate the Age input
                if (age <= 0)
                {
                    MessageBox.Show("Age must be a positive integer.");
                    return;
                }


                SqlConnection con = new SqlConnection("Data Source=JRGENGRACIAL\\SQLEXPRESS;Initial Catalog=\"CRUD App DB\";Integrated Security=True;Pooling=False;Encrypt=False");
                SqlCommand cmd = new SqlCommand("Update Table_1 set FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, Age = @Age where ID = @ID", con);
                con.Open();

                cmd.Parameters.AddWithValue("@ID", update.ID);
                cmd.Parameters.AddWithValue("@FirstName", update.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", update.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", update.LastName);
                cmd.Parameters.AddWithValue("@Age", update.Age);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Updated succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        public void DeleteFunction(DeleteModel delete)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=JRGENGRACIAL\\SQLEXPRESS;Initial Catalog=\"CRUD App DB\";Integrated Security=True;Pooling=False;Encrypt=False");
                SqlCommand cmd = new SqlCommand("Delete Table_1 where ID = @ID", con);
                con.Open();

                cmd.Parameters.AddWithValue("@ID", delete.ID);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Deleted succesfully");
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
 