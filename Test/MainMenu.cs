using System.Data.SqlClient;

namespace Test
{
    public partial class MainMenu : Form
    {

        public MainMenu()
        {
            InitializeComponent();
            
            Task.Delay(2000);
            countStudents();
            countSections();
        }

        public void countStudents()
        {
            SqlConnection conn = Program.Conn();
            conn.Open();

            SqlCommand countCommand = new SqlCommand("USE studentManagement; SELECT COUNT(id) FROM student_information;", conn);
            SqlDataReader reader = countCommand.ExecuteReader();
            reader.Read();

            label4.Text = Convert.ToString(reader.GetInt32(0));
        }

        public void countSections()
        {
            SqlConnection conn = Program.Conn();
            conn.Open();

            SqlCommand countCommand = new SqlCommand("USE studentManagement; SELECT COUNT(DISTINCT batch) FROM student_information;", conn);
            SqlDataReader reader = countCommand.ExecuteReader();
            reader.Read();

            label6.Text = Convert.ToString(reader.GetInt32(0));
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            AddStudent addStudent = new AddStudent(this);
            addStudent.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            
            ViewStudents viewStudents = new ViewStudents(this);
            viewStudents.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            DeleteStudent deleteStudent = new DeleteStudent(this);
            deleteStudent.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            EditStudent editStudent = new EditStudent(this);
            editStudent.Visible = true;
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}