using System.Data.SQLite;

namespace SQLiteIntegration_ADOdotNET
{
    public static class DatabaseHelper
    {
        public static void DbContext()
        {
            string ConnectionString = "Data Source=C:\\SQLiteStudio\\TrialDB";
            try
            {
                SQLiteConnection connection = null;
                using (connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Connected");
                        string query = "SELECT Username FROM Users";
                        SQLiteCommand command =new SQLiteCommand(query,connection);
                        SQLiteDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine("Username: " + reader["Username"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}