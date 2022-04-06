using System.Data.SqlClient;

namespace Test
{
    public partial class EditStudent : Form
    {
        MainMenu parentMenu;
        SqlConnection conn;
        public EditStudent(MainMenu mainMenu)
        {
            InitializeComponent();
            parentMenu = mainMenu;

            conn = Program.Conn();
            conn.Open();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            parentMenu.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("All fields are required");
            }
            else
            {
                SqlCommand updateCommand = new SqlCommand("USE studentManagement; UPDATE student_information SET firstName=@fName, lastName=@lName, batch=@batch, section=@section WHERE ID=@ID", conn);
                updateCommand.Parameters.AddWithValue("@ID", textBox2.Text);
                updateCommand.Parameters.AddWithValue("@fName", textBox1.Text);
                updateCommand.Parameters.AddWithValue("@lName", textBox3.Text);
                updateCommand.Parameters.AddWithValue("@batch", textBox4.Text);
                updateCommand.Parameters.AddWithValue("@section", textBox5.Text);

                updateCommand.ExecuteNonQuery();

                MessageBox.Show("Record Updated!");

                conn.Close();
                parentMenu.countSections();

                parentMenu.Visible = true;
                this.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand queryCommand = new SqlCommand("USE studentManagement; SELECT * FROM student_Information WHERE ID = @ID", conn);
            queryCommand.Parameters.AddWithValue("@ID", textBox2.Text);

            SqlDataReader? reader = null;

            try
            {
                reader = queryCommand.ExecuteReader();
                
                reader.Read();
                textBox1.Text = reader.GetString(1);
                textBox3.Text = reader.GetString(2);
                textBox4.Text = reader.GetString(3);
                textBox5.Text = reader.GetString(4);

            } catch (InvalidOperationException exception)
            {
                MessageBox.Show("ID does not exist!");
            }

            reader.Close();
        }
    }
}
