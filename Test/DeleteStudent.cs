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
    public partial class DeleteStudent : Form
    {
        MainMenu parentMenu;
        public DeleteStudent(MainMenu mainMenu)
        {
            InitializeComponent();
            parentMenu = mainMenu;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                MessageBox.Show("ID required!");
            else
            {
                SqlConnection conn = Program.Conn();
                conn.Open();

                SqlCommand deleteCommand = new SqlCommand("USE studentManagement; DELETE FROM student_information WHERE ID=@ID", conn);
                deleteCommand.Parameters.AddWithValue("@ID", textBox2.Text);

                int numberOfRows = deleteCommand.ExecuteNonQuery();

                if(numberOfRows == 1)
                {
                    label3.ForeColor = Color.Gray;

                    conn.Close();
                    parentMenu.countStudents();
                    parentMenu.countSections();

                    await Task.Delay(1000);

                    this.Visible = false;
                    parentMenu.Visible = true;
                }
                else
                {
                    MessageBox.Show("ID does not exist!");
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parentMenu.Visible = true;
            this.Visible = false;
        }
    }
}
