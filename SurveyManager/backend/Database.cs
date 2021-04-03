using MySql.Data.MySqlClient;
using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.backend
{
    /// <summary>
    /// Class responsible for handling database connections and is the main class used to insert, update, and select records.
    /// </summary>
    public class Database
    {
        /// <summary>
        /// The hostname of the database connection
        /// </summary>
        public static string Server { get; set; }

        /// <summary>
        /// The port the database connection is listening on
        /// </summary>
        public static string Port { get; set; }

        /// <summary>
        /// The name of the database to connect to
        /// </summary>
        public static string DB { get; set; }

        /// <summary>
        /// The user name for the database
        /// </summary>
        public static string Username { get; set; }

        /// <summary>
        /// The password for the database
        /// </summary>
        public static string Password { get; set; }

        /// <summary>
        /// The full connection string
        /// </summary>
        public static string ConnectionString { get; private set; }

        /// <summary>
        /// The maximum allowed packet size in bytes for a file upload
        /// </summary>
        public const int MAX_ALLOWED_PACKET_SIZE = 1073741824;

        /// <summary>
        /// Initializes properties with values from the connection string saved in settings.
        /// Sets the <see cref="ConnectionString"/> property using these values.
        /// </summary>
        public static void Initialize()
        {
            string connection = Settings.Default.ConnectionString;
            if (connection != null && !connection.Equals(""))
            {
                Console.WriteLine("Connection string: " + connection);
                string[] conParts = connection.Split(';');
                string[] conParams = new string[conParts.Length];

                for (int i = 0; i < conParts.Length; i++)
                {
                    conParams[i] = conParts[i].Substring(conParts[i].IndexOf('=') + 1);
                }

                Server = conParams[0];
                Username = conParams[1];
                Password = conParams[2];
                Port = conParams[3];
                DB = conParams[4];

                ConnectionString = $"server={Server};UID={Username};PASSWORD={Password};port={Port};Database={DB};Pooling=True;sqlservermode=True;";
            }
        }

        /// <summary>
        /// Used to save the connection string to settings
        /// </summary>
        public static void SaveConnectionString()
        {
            ConnectionString = $"server={Server};UID={Username};PASSWORD={Password};port={Port};Database={DB};Pooling=True;sqlservermode=True;";
            Settings.Default.ConnectionString = ConnectionString;
            Settings.Default.Save();
        }

        /// <summary>
        /// Creates a database connection on the given connection string and tests that it can be opened and closed.
        /// If it can't, the error code returned by <see cref="MySqlException"/> is returned by this function.
        /// </summary>
        /// <returns></returns>
        public static int CheckConnection()
        {
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    con.Close();
                    RuntimeVars.Instance.DatabaseConnected = true;
                }
                catch (MySqlException ex)
                {
                    RuntimeVars.Instance.DatabaseConnected = false;
                    return ex.Number;
                }
                finally
                {
                    con.Dispose();
                }
                return -1;
            }
        }

        /// <summary>
        /// Executes a filter query built by a <see cref="forms.dialogs.AdvancedFilter"/> dialog.
        /// </summary>
        /// <param name="query">The query to execute on the database.</param>
        /// <returns>A <see cref="DataTable"/> containing all of the rows that matched the query.
        /// <para>It is up to the calling class to parse this data appropiately.</para>
        /// </returns>
        public static DataTable ExecuteFilter(string query)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                }
                con.Close();
            }
            return dt;
        }
    }
}
