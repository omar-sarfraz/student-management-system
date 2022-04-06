using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Test
{
    public partial class AddStudent : Form
    {
        MainMenu parentMenu;
        public AddStudent(MainMenu mainMenu)
        {
            parentMenu = mainMenu;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("All fields are required");
            } 
            else
            {
                SqlConnection conn = Program.Conn();
                conn.Open();

                SqlCommand insertCommand = new SqlCommand("USE studentManagement; INSERT INTO student_information (firstName,lastName,batch,section) VALUES (@fName, @lName, @batch, @section)", conn);
                insertCommand.Parameters.AddWithValue("@fName", textBox2.Text);
                insertCommand.Parameters.AddWithValue("@lName", textBox3.Text);
                insertCommand.Parameters.AddWithValue("@batch", textBox4.Text);
                insertCommand.Parameters.AddWithValue("@section", textBox5.Text);

                insertCommand.ExecuteNonQuery();

                MessageBox.Show("Record Added!");

                conn.Close();

                parentMenu.countStudents();
                parentMenu.countSections();

                parentMenu.Visible = true;
                this.Visible = false;
            }


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parentMenu.Visible = true;
            this.Visible = false;
        }
    }
}
