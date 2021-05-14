using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace AirFreight_Calculator
{
    static class Connect
    {
        private const String server = "localhost";
        internal static String userId = "general";
        internal static String password = "";
        private const String database = "air_cargo";
        /*
        internal static void SetConnect(string user, string pw)
        {
            userId = user;
            password = pw;
        }

        public static void SetConnect()
        {
            userId = "general";
            password = "";
        }
        */
        public static MySqlConnection InitDB()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = server;
            builder.UserID = userId;
            builder.Password = password;
            builder.Database = database;

            String conn = builder.ToString();

            try
            {
                return new MySqlConnection(conn);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Hiba az adatbázishoz csatlakozáskor{Environment.NewLine}{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Egyéb hiba{Environment.NewLine}{ex.Message}");
            }
            return default(MySqlConnection);
        }
    }
}
