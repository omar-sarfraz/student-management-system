using System.Data.SqlClient;

namespace Test
{
    internal static class Program
    {
        [STAThread]
        
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainMenu());

        }

        public static SqlConnection Conn()
        {
            SqlConnection? conn = null;
            string connectionString = "Data Source = DESKTOP-8DR3E29\\MSSQLSERVER01; Integrated Security=true; TrustServerCertificate=true";

            try
            {
                conn = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return conn;
        }

    }
}