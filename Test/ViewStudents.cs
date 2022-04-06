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
    public partial class ViewStudents : Form
    {
        MainMenu parentMenu;

        public ViewStudents(MainMenu mainMenu)
        {
            parentMenu = mainMenu;
            InitializeComponent();

            SqlConnection conn = Program.Conn();
            conn.Open();

            SqlCommand selectCommand = new SqlCommand("USE studentManagement; SELECT * FROM student_information", conn);
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
            }

            conn.Close();


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            parentMenu.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
