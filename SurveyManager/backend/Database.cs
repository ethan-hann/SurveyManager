using MySql.Data.MySqlClient;
using SurveyManager.backend.wrappers;
using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SurveyManager.utility.Enums;

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

        /// <summary>
        /// Retrieve a list of column names from the specified table.
        /// </summary>
        /// <param name="tableName">The table to get the columns of</param>
        /// <returns>An <see cref="ArrayList"/> of type <see cref="string"/> containing the column names.</returns>
        public static ArrayList GetColumns(string tableName)
        {
            ArrayList columns = new ArrayList();
            string q = $"SELECT `COLUMN_NAME` FROM `INFORMATION_SCHEMA`.`COLUMNS` WHERE `TABLE_SCHEMA`= '{DB}' AND `TABLE_NAME`= '{tableName}';";

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columns.Add(reader.GetString(0));
                        }
                    }
                }
                con.Close();
            }
            return columns;
        }

        /// <summary>
        /// Get the last row id inserted in the specified table.
        /// </summary>
        /// <param name="tablename">The table's name to search</param>
        /// <returns>The id of the last row inserted</returns>
        public static int GetLastRowIDInserted(string tablename)
        {
            int lastRowID = 0;
            ArrayList columns = GetColumns(tablename);
            string q = $"SELECT * FROM {tablename} order by {columns[0]} desc limit 1;";

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            lastRowID = reader.GetInt32(0);
                        }
                    }
                }
                con.Close();
            }
            return lastRowID;
        }

        #region Insert
        public static bool InsertAddress(Address a)
        {
            int affectedRows = 0;
            ArrayList columns = GetColumns("Address");
            columns.RemoveAt(0); //remove the id column
            columns.TrimToSize(); //trim the arraylist after index removal
            string q = Queries.BuildQuery(QType.INSERT, "Address", null, columns);

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlTransaction tr = con.BeginTransaction())
                    {
                        cmd.CommandText = q;
                        cmd.Transaction = tr;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@0", a.Street);
                        cmd.Parameters.AddWithValue("@1", a.City);
                        cmd.Parameters.AddWithValue("@2", a.ZipCode);

                        cmd.Connection = con;
                        affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                            tr.Commit();
                        else
                            tr.Rollback();
                    }
                }
                con.Close();
            }
            return affectedRows != 0;
        }

        /// <summary>
        /// Inserts a new client into the database.
        /// </summary>
        /// <param name="c">The <see cref="Client"/> to insert.</param>
        /// <returns>True if the record was inserted successfully; False otherwise.</returns>
        public static bool InsertClient(Client c)
        {
            int affectedRows = 0;
            ArrayList columns = GetColumns("Client");
            columns.RemoveAt(0); //remove the id column
            columns.TrimToSize(); //trim the arraylist after index removal
            string q = Queries.BuildQuery(QType.INSERT, "Client", null, columns);

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using(MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlTransaction tr = con.BeginTransaction())
                    {
                        cmd.CommandText = q;
                        cmd.Transaction = tr;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@0", c.Name);
                        cmd.Parameters.AddWithValue("@1", c.PhoneNumber);
                        cmd.Parameters.AddWithValue("@2", c.Email);
                        cmd.Parameters.AddWithValue("@3", c.FaxNumber);
                        cmd.Parameters.AddWithValue("@4", c.AddressID);

                        cmd.Connection = con;
                        affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                            tr.Commit();
                        else
                            tr.Rollback();
                    }
                }
                con.Close();
            }
            return affectedRows != 0;
        }
        #endregion
    }
}
