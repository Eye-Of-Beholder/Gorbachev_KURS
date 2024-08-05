using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Gorbachev_KURS.ClassFolder
{
    internal class DatabaseManager
    {
        private string connectionString = "Data Source=DESKTOP-KI0QVLM\\HOME;Initial Catalog=KOMP_KURS;Integrated Security=True";

        public DatabaseManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int InsertUser(string login, string password, string role)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [Users] (login, pass, role) OUTPUT INSERTED.ID VALUES (@login, @pass, @role)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@pass", password);
                    command.Parameters.AddWithValue("@role", role);
                    return (int)command.ExecuteScalar();
                }
            }
        }
    }
}