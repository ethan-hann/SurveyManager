using MySql.Data.MySqlClient;
using SurveyManager.backend.wrappers;
using SurveyManager.backend.wrappers.SurveyJob;
using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
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
        /// </summary>
        /// <returns>An <see cref="MySqlException"/> if an error occured while checking connection; <c>null</c> otherwise.</returns>
        public static MySqlException CheckConnection()
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
                    RuntimeVars.Instance.LogFile.AddEntry($"Error when trying to connect to SQL database: {ex.Message}");
                    return ex;
                }
                finally
                {
                    con.Dispose();
                }
                return null;
            }
        }

        /// <summary>
        /// Get a MySql Error Message based on the supplied <paramref name="exception"/>. The exception can be retrieved from the <see cref="CheckConnection"/> method.
        /// <para>If the exception is <c>null</c>, meaning no error occured, this method simply returns <c>NO ERROR</c> as a string.</para>
        /// </summary>
        /// <param name="exception">The exception to get the message of.</param>
        /// <returns>A string containing the error message.</returns>
        public static string GetErrorMessage(MySqlException exception = null)
        {
            if (exception == null)
                return "NO ERROR";
            return exception.Message;
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

            if (query.Equals("") || query.Equals(string.Empty))
            {
                dt.Columns.Add("MySQL Error");
                dt.Rows.Add("Query is empty!");
                return dt;
            }

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                try
                {
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
                }
                catch (MySqlException ex)
                {
                    dt.Columns.Add("MySQL Error");
                    dt.Columns.Add("Error Code");
                    dt.Rows.Add(ex.Message, ex.Code);
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
        /// Run the _.show_table_status() stored prodedure to get information about tables.
        /// </summary>
        /// <returns>A <see cref="DataTable"/> ready to be used as a data source for a DataGridView Control.</returns>
        public static DataTable GetTableInfo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Table");
            dt.Columns.Add("Engine");
            dt.Columns.Add("Version");
            dt.Columns.Add("Row Format");
            dt.Columns.Add("Number of Rows");
            dt.Columns.Add("Avg. Row Length");
            dt.Columns.Add("Data Length");
            dt.Columns.Add("Max Data Length");
            dt.Columns.Add("Index Length");
            dt.Columns.Add("Data Free");
            dt.Columns.Add("Next Auto Increment Value");
            dt.Columns.Add("Create Time");
            dt.Columns.Add("Last Update");
            dt.Columns.Add("Comment");


            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "_.show_table_status()";
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                dt.Rows.Add(reader["Name"],
                                            reader["Engine"],
                                            reader["Version"],
                                            reader["Row_format"],
                                            reader["Rows"],
                                            reader["Avg_row_length"],
                                            reader["Data_length"],
                                            reader["Max_data_length"],
                                            reader["Index_length"],
                                            reader["Data_free"],
                                            reader["Auto_increment"],
                                            reader["Create_time"],
                                            reader["Update_time"],
                                            reader["Comment"]);
                            }
                        }
                    }
                }
                con.Close();

                return dt;
            }
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

        #region Address
        /// <summary>
        /// Insert into the database the <see cref="Address"/> <paramref name="a"/>.
        /// </summary>
        /// <param name="a">The <see cref="Address"/> to insert.</param>
        /// <returns>The row id of the inserted object.</returns>
        public static int InsertAddress(Address a)
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
            return affectedRows != 0 ? GetLastRowIDInserted("Address") : 0;
        }

        /// <summary>
        /// Update in the database the <see cref="Address"/> <paramref name="a"/>.
        /// </summary>
        /// <param name="a">The <see cref="Address"/> to update.</param>
        /// <returns>True if the update was successfull; False otherwise.</returns>
        public static bool UpdateAddress(Address a)
        {
            int affectedRows = 0;
            ArrayList columns = GetColumns("Address");
            string q = Queries.BuildQuery(QType.UPDATE, "Address", null, columns, $"address_id={a.ID}");

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlTransaction tr = con.BeginTransaction())
                    {
                        cmd.CommandText = q;
                        cmd.Transaction = tr;
                        cmd.Parameters.AddWithValue("@0", a.ID);
                        cmd.Parameters.AddWithValue("@1", a.Street);
                        cmd.Parameters.AddWithValue("@2", a.City);
                        cmd.Parameters.AddWithValue("@3", a.ZipCode);

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
        /// Get from the database the <see cref="Address"/> object represented by the primary key <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the address object.</param>
        /// <returns>An <see cref="Address"/> object represented by the id.</returns>
        public static Address GetAddress(int id)
        {
            Address a = null;
            string q = Queries.BuildQuery(QType.SELECT, "Address", null, null, $"address_id={id}");

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
                            a = new Address
                            {
                                ID = reader.GetInt32(0),
                                Street = reader.GetString(1),
                                City = reader.GetString(2),
                                ZipCode = reader.GetString(3)
                            };
                        }
                    }
                }
                con.Close();
            }
            return a;
        }

        /// <summary>
        /// Delete from the database the <see cref="Address"/> object.
        /// </summary>
        /// <param name="a">The <see cref="Address"/> to delete.</param>
        /// <returns>True if the address was deleted successfully; False otherwise.</returns>
        public static bool DeleteAddress(Address a)
        {
            int affectedRows = 0;
            string q = Queries.BuildQuery(QType.DELETE, "Address", null, null, $"address_id={a.ID}");

            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlTransaction tr = con.BeginTransaction())
                        {
                            cmd.CommandText = q;
                            cmd.Transaction = tr;
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
            }
            catch (Exception e)
            {
                RuntimeVars.Instance.LogFile.AddEntry($"Could not delete address: {a.ID}. It might be associated with another object.");
                return false;
            }

            return affectedRows != 0;
        }
        #endregion

        #region Client
        /// <summary>
        /// Insert into the database the <see cref="Client"/> <paramref name="c"/>.
        /// </summary>
        /// <param name="c">The <see cref="Client"/> to insert.</param>
        /// <returns>The row id of the inserted object.</returns>
        public static int InsertClient(Client c)
        {
            int affectedRows = 0;
            ArrayList columns = GetColumns("Client");
            columns.RemoveAt(0); //remove the id column
            columns.TrimToSize(); //trim the arraylist after index removal
            string q = Queries.BuildQuery(QType.INSERT, "Client", null, columns);

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
            return affectedRows != 0 ? GetLastRowIDInserted("Client") : 0;
        }

        /// <summary>
        /// Update in the database the <see cref="Client"/> <paramref name="c"/>.
        /// </summary>
        /// <param name="c">The <see cref="Client"/> to update.</param>
        /// <returns>True if the update was successfull; False otherwise.</returns>
        public static bool UpdateClient(Client c)
        {
            int affectedRows = 0;
            ArrayList columns = GetColumns("Client");
            string q = Queries.BuildQuery(QType.UPDATE, "Client", null, columns, $"client_id={c.ID}");

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

                        cmd.Parameters.AddWithValue("@0", c.ID);
                        cmd.Parameters.AddWithValue("@1", c.Name);
                        cmd.Parameters.AddWithValue("@2", c.PhoneNumber);
                        cmd.Parameters.AddWithValue("@3", c.Email);
                        cmd.Parameters.AddWithValue("@4", c.FaxNumber);
                        cmd.Parameters.AddWithValue("@5", c.AddressID);

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
        /// Get from the database the <see cref="Client"/> object represented by the primary key <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the client object.</param>
        /// <returns>An <see cref="Client"/> object represented by the id.</returns>
        public static Client GetClient(int id)
        {
            Client c = null;
            string q = Queries.BuildQuery(QType.SELECT, "Client", null, null, $"client_id={id}");

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
                            c = new Client
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                PhoneNumber = reader.GetString(2),
                                Email = reader.GetString(3),
                                FaxNumber = reader.GetString(4),
                                AddressID = reader.GetInt32(5)
                            };

                            if (c.AddressID > 0)
                                c.SetAddress();
                        }
                    }
                }
                con.Close();
            }
            return c;
        }

        /// <summary>
        /// Get from the database all <see cref="Client"/> objects.
        /// </summary>
        /// <returns>A list of <see cref="Client"/> objects.</returns>
        public static List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();
            string q = Queries.BuildQuery(QType.SELECT, "Client");

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Client c = new Client
                                {
                                    ID = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    PhoneNumber = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    FaxNumber = reader.GetString(4),
                                    AddressID = reader.GetInt32(5)
                                };

                                if (c.AddressID > 0)
                                    c.SetAddress();

                                clients.Add(c);
                            }
                        }
                    }
                }
                con.Close();
            }
            return clients;
        }

        /// <summary>
        /// Delete from the database the <see cref="Client"/> object.
        /// </summary>
        /// <param name="c">The <see cref="Client"/> to delete.</param>
        /// <returns>True if the client was deleted successfully; False otherwise.</returns>
        public static bool DeleteClient(Client c)
        {
            int affectedRows = 0;
            int addressRows = 0;
            string q = Queries.BuildQuery(QType.DELETE, "Client", null, null, $"client_id={c.ID}");
            string addressQ = Queries.BuildQuery(QType.DELETE, "Address", null, null, $"address_id={c.AddressID}");

            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlTransaction tr = con.BeginTransaction())
                        {
                            cmd.CommandText = q;
                            cmd.Transaction = tr;
                            cmd.Connection = con;
                            affectedRows = cmd.ExecuteNonQuery();

                            if (affectedRows > 0)
                                tr.Commit();
                            else
                                tr.Rollback();
                        }

                        using (MySqlTransaction tr = con.BeginTransaction())
                        {
                            cmd.CommandText = addressQ;
                            cmd.Transaction = tr;
                            cmd.Connection = con;
                            addressRows = cmd.ExecuteNonQuery();

                            if (addressRows > 0)
                                tr.Commit();
                            else
                                tr.Rollback();
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                RuntimeVars.Instance.LogFile.AddEntry($"Could not delete client: {c.ID}. It might be associated with another object.");
                return false;
            }

            return affectedRows != 0 && addressRows != 0;
        }
        #endregion

        #region County
        /// <summary>
        /// Insert into the database the <see cref="County"/> <paramref name="c"/>.
        /// </summary>
        /// <param name="c">The <see cref="County"/> to insert.</param>
        /// <returns>The row id of the inserted object.</returns>
        public static int InsertCounty(County c)
        {
            int affectedRows = 0;
            ArrayList columns = GetColumns("County");
            columns.RemoveAt(0); //remove the id column
            columns.TrimToSize(); //trim the arraylist after index removal
            string q = Queries.BuildQuery(QType.INSERT, "County", null, columns);

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

                        cmd.Parameters.AddWithValue("@0", c.CountyName);

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
            return affectedRows != 0 ? GetLastRowIDInserted("County") : 0;
        }

        /// <summary>
        /// Update in the database the <see cref="County"/> <paramref name="c"/>.
        /// </summary>
        /// <param name="c">The <see cref="County"/> to update.</param>
        /// <returns>True if the update was successfull; False otherwise.</returns>
        public static bool UpdateCounty(County c)
        {
            int affectedRows = 0;
            ArrayList columns = GetColumns("County");
            string q = Queries.BuildQuery(QType.UPDATE, "County", null, columns, $"county_id={c.ID}");

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

                        cmd.Parameters.AddWithValue("@0", c.ID);
                        cmd.Parameters.AddWithValue("@1", c.CountyName);

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
        /// Get from the database the <see cref="County"/> object represented by the primary key <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the county object.</param>
        /// <returns>An <see cref="County"/> object represented by the id.</returns>
        public static County GetCounty(int id)
        {
            County c = null;
            string q = Queries.BuildQuery(QType.SELECT, "County", null, null, $"county_id={id}");

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
                            c = new County
                            {
                                ID = reader.GetInt32(0),
                                CountyName = reader.GetString(1)
                            };
                        }
                    }
                }
                con.Close();
            }
            return c;
        }

        /// <summary>
        /// Get from the database all <see cref="County"/> objects.
        /// </summary>
        /// <returns>A list of <see cref="County"/> objects.</returns>
        public static List<County> GetCounties()
        {
            List<County> counties = new List<County>();
            County c = null;
            string q = Queries.BuildQuery(QType.SELECT, "County");

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                c = new County
                                {
                                    ID = reader.GetInt32(0),
                                    CountyName = reader.GetString(1)
                                };
                                counties.Add(c);
                            }
                        }
                    }
                }
                con.Close();
            }
            return counties;
        }

        /// <summary>
        /// Delete from the database the <see cref="County"/> object.
        /// </summary>
        /// <param name="c">The <see cref="County"/> to delete.</param>
        /// <returns>True if the county was deleted successfully; False otherwise.</returns>
        public static bool DeleteCounty(County c)
        {
            int affectedRows = 0;
            string q = Queries.BuildQuery(QType.DELETE, "County", null, null, $"county_id={c.ID}");

            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlTransaction tr = con.BeginTransaction())
                        {
                            cmd.CommandText = q;
                            cmd.Transaction = tr;
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
            }
            catch (Exception)
            {
                RuntimeVars.Instance.LogFile.AddEntry($"Could not delete county: {c.ID}. It might be associated with another object.");
                return false;
            }

            return affectedRows != 0;
        }
        #endregion

        #region Realtor
        /// <summary>
        /// Insert into the database the <see cref="Realtor"/> <paramref name="r"/>.
        /// </summary>
        /// <param name="r">The <see cref="Realtor"/> to insert.</param>
        /// <returns>The row id of the inserted object.</returns>
        public static int InsertRealtor(Realtor r)
        {
            int affectedRows = 0;
            ArrayList columns = GetColumns("Realtor");
            columns.RemoveAt(0); //remove the id column
            columns.TrimToSize(); //trim the arraylist after index removal
            string q = Queries.BuildQuery(QType.INSERT, "Realtor", null, columns);

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

                        cmd.Parameters.AddWithValue("@0", r.Name);
                        cmd.Parameters.AddWithValue("@1", r.CompanyName);
                        cmd.Parameters.AddWithValue("@2", r.Email);
                        cmd.Parameters.AddWithValue("@3", r.PhoneNumber);
                        cmd.Parameters.AddWithValue("@4", r.FaxNumber);

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
            return affectedRows != 0 ? GetLastRowIDInserted("Realtor") : 0;
        }

        /// <summary>
        /// Update in the database the <see cref="Realtor"/> <paramref name="r"/>.
        /// </summary>
        /// <param name="r">The <see cref="Realtor"/> to update.</param>
        /// <returns>True if the update was successfull; False otherwise.</returns>
        public static bool UpdateRealtor(Realtor r)
        {
            int affectedRows = 0;
            ArrayList columns = GetColumns("Realtor");
            string q = Queries.BuildQuery(QType.UPDATE, "Realtor", null, columns, $"realtor_id={r.ID}");

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

                        cmd.Parameters.AddWithValue("@0", r.ID);
                        cmd.Parameters.AddWithValue("@1", r.Name);
                        cmd.Parameters.AddWithValue("@2", r.CompanyName);
                        cmd.Parameters.AddWithValue("@3", r.Email);
                        cmd.Parameters.AddWithValue("@4", r.PhoneNumber);
                        cmd.Parameters.AddWithValue("@5", r.FaxNumber);

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
        /// Get from the database the <see cref="Realtor"/> object represented by the primary key <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the realtor object.</param>
        /// <returns>An <see cref="Realtor"/> object represented by the id.</returns>
        public static Realtor GetRealtor(int id)
        {
            Realtor r = null;
            string q = Queries.BuildQuery(QType.SELECT, "Realtor", null, null, $"realtor_id={id}");

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
                            r = new Realtor
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                CompanyName = reader.GetString(2),
                                Email = reader.GetString(3),
                                PhoneNumber = reader.GetString(4),
                                FaxNumber = reader.GetString(5)
                            };
                        }
                    }
                }
                con.Close();
            }
            return r;
        }

        /// <summary>
        /// Get from the database all <see cref="Realtor"/> objects.
        /// </summary>
        /// <returns>A list of <see cref="Realtor"/> objects.</returns>
        public static List<Realtor> GetRealtors()
        {
            List<Realtor> realtors = new List<Realtor>();
            Realtor r = null;
            string q = Queries.BuildQuery(QType.SELECT, "Realtor");

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                r = new Realtor
                                {
                                    ID = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    CompanyName = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    PhoneNumber = reader.GetString(4),
                                    FaxNumber = reader.GetString(5)
                                };
                                realtors.Add(r);
                            }
                        }
                    }
                }
                con.Close();
            }
            return realtors;
        }

        /// <summary>
        /// Delete from the database the <see cref="Realtor"/> object.
        /// </summary>
        /// <param name="r">The <see cref="Realtor"/> to delete.</param>
        /// <returns>True if the realtor was deleted successfully; False otherwise.</returns>
        public static bool DeleteRealtor(Realtor r)
        {
            int affectedRows = 0;
            string q = Queries.BuildQuery(QType.DELETE, "Realtor", null, null, $"realtor_id={r.ID}");

            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlTransaction tr = con.BeginTransaction())
                        {
                            cmd.CommandText = q;
                            cmd.Transaction = tr;
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
            }
            catch (Exception)
            {
                RuntimeVars.Instance.LogFile.AddEntry($"Could not delete realtor: {r.ID}. It might be associated with another object.");
                return false;
            }

            return affectedRows != 0;
        }
        #endregion

        #region Title Company
        /// <summary>
        /// Insert into the database the <see cref="TitleCompany"/> <paramref name="t"/>.
        /// </summary>
        /// <param name="t">The <see cref="TitleCompany"/> to insert.</param>
        /// <returns>The row id of the inserted object.</returns>
        public static int InsertTitleCompany(TitleCompany t)
        {
            int affectedRows = 0;
            ArrayList columns = GetColumns("TitleCompany");
            columns.RemoveAt(0); //remove the id column
            columns.TrimToSize(); //trim the arraylist after index removal
            string q = Queries.BuildQuery(QType.INSERT, "TitleCompany", null, columns);

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

                        cmd.Parameters.AddWithValue("@0", t.Name);
                        cmd.Parameters.AddWithValue("@1", t.AssociateName);
                        cmd.Parameters.AddWithValue("@2", t.AssociateEmail);
                        cmd.Parameters.AddWithValue("@3", t.OfficeNumber);

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
            return affectedRows != 0 ? GetLastRowIDInserted("TitleCompany") : 0;
        }

        /// <summary>
        /// Update in the database the <see cref="TitleCompany"/> <paramref name="t"/>.
        /// </summary>
        /// <param name="t">The <see cref="TitleCompany"/> to update.</param>
        /// <returns>True if the update was successfull; False otherwise.</returns>
        public static bool UpdateTitleCompany(TitleCompany t)
        {
            int affectedRows = 0;
            ArrayList columns = GetColumns("TitleCompany");
            string q = Queries.BuildQuery(QType.UPDATE, "TitleCompany", null, columns, $"company_id={t.ID}");

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

                        cmd.Parameters.AddWithValue("@0", t.ID);
                        cmd.Parameters.AddWithValue("@1", t.Name);
                        cmd.Parameters.AddWithValue("@2", t.AssociateName);
                        cmd.Parameters.AddWithValue("@3", t.AssociateEmail);
                        cmd.Parameters.AddWithValue("@4", t.OfficeNumber);

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
        /// Get from the database the <see cref="TitleCompany"/> object represented by the primary key <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the title company object.</param>
        /// <returns>An <see cref="TitleCompany"/> object represented by the id.</returns>
        public static TitleCompany GetTitleCompany(int id)
        {
            TitleCompany t = null;
            string q = Queries.BuildQuery(QType.SELECT, "TitleCompany", null, null, $"company_id={id}");

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
                            t = new TitleCompany
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                AssociateName = reader.GetString(2),
                                AssociateEmail = reader.GetString(3),
                                OfficeNumber = reader.GetString(4)
                            };
                        }
                    }
                }
                con.Close();
            }
            return t;
        }

        /// <summary>
        /// Get from the database all <see cref="TitleCompany"/> objects.
        /// </summary>
        /// <returns>A list of <see cref="TitleCompany"/> objects.</returns>
        public static List<TitleCompany> GetTitleCompanies()
        {
            List<TitleCompany> companies = new List<TitleCompany>();
            TitleCompany t = null;
            string q = Queries.BuildQuery(QType.SELECT, "TitleCompany");

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                t = new TitleCompany
                                {
                                    ID = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    AssociateName = reader.GetString(2),
                                    AssociateEmail = reader.GetString(3),
                                    OfficeNumber = reader.GetString(4)
                                };
                                companies.Add(t);
                            }
                        }
                    }
                }
                con.Close();
            }
            return companies;
        }

        /// <summary>
        /// Delete from the database the <see cref="TitleCompany"/> object.
        /// </summary>
        /// <param name="t">The <see cref="TitleCompany"/> to delete.</param>
        /// <returns>True if the title company was deleted successfully; False otherwise.</returns>
        public static bool DeleteTitleCompany(TitleCompany c)
        {
            int affectedRows = 0;
            string q = Queries.BuildQuery(QType.DELETE, "TitleCompany", null, null, $"company_id={c.ID}");

            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlTransaction tr = con.BeginTransaction())
                        {
                            cmd.CommandText = q;
                            cmd.Transaction = tr;
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
            }
            catch (Exception)
            {
                RuntimeVars.Instance.LogFile.AddEntry($"Could not delete title company: {c.ID}. It might be associated with another object.");
                return false;
            }

            return affectedRows != 0;
        }
        #endregion

        #region Files

        /// <summary>
        /// Insert into the database the <see cref="CFile"/> <paramref name="file"/>.
        /// </summary>
        /// <param name="file">The <see cref="CFile"/> to insert.</param>
        /// <returns>The row id of the inserted object.</returns>
        public static int InsertFile(CFile file)
        {
            int affectedRows = 0;
            ArrayList columns = GetColumns("File");
            columns.RemoveAt(0); //remove the id column
            columns.TrimToSize(); //trim the arraylist after index removal
            string q = Queries.BuildQuery(QType.INSERT, "File", null, columns);

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlTransaction tr = con.BeginTransaction())
                    {
                        cmd.CommandText = q;
                        cmd.Transaction = tr;
                        cmd.Parameters.AddWithValue("@0", file.FileName);
                        cmd.Parameters.AddWithValue("@1", file.Description);
                        cmd.Parameters.AddWithValue("@2", file.Extension);
                        cmd.Parameters.AddWithValue("@3", file.Contents);
                        cmd.Parameters.AddWithValue("@4", file.FileEncoding.CodePage);

                        cmd.Connection = con;
                        affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            tr.Commit();
                        }
                        else
                        {
                            tr.Rollback();
                        }
                    }
                }
                con.Close();
            }
            return affectedRows != 0 ? GetLastRowIDInserted("File") : 0;
        }

        /// <summary>
        /// Update in the database the <see cref="CFile"/> <paramref name="file"/>. If the file has an ID of 0, it is inserted instead.
        /// </summary>
        /// <param name="file">The <see cref="CFile"/> to update.</param>
        /// <returns>True if the update was successfull; False otherwise.</returns>
        public static bool UpdateFile(CFile file)
        {
            if (file.ID == 0)
                return file.Insert() == DatabaseError.NoError;

            int affectedRows = 0;
            ArrayList columns = GetColumns("File");

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlTransaction tr = con.BeginTransaction())
                    {
                        string q = Queries.BuildQuery(QType.UPDATE, "File", null, columns, $"id={file.ID}");
                        cmd.CommandText = q;
                        cmd.Transaction = tr;

                        cmd.Parameters.AddWithValue("@0", file.ID);
                        cmd.Parameters.AddWithValue("@1", file.FileName);
                        cmd.Parameters.AddWithValue("@2", file.Description);
                        cmd.Parameters.AddWithValue("@3", file.Extension);
                        cmd.Parameters.AddWithValue("@4", file.Contents);
                        cmd.Parameters.AddWithValue("@5", file.FileEncoding.CodePage);

                        cmd.Connection = con;
                        affectedRows += cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            tr.Commit();
                        }
                        else
                        {
                            tr.Rollback();
                        }
                    }
                }
                con.Close();
            }
            return affectedRows != 0;
        }

        /// <summary>
        /// Get from the database the <see cref="CFile"/> object represented by the primary key <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the file object.</param>
        /// <returns>An <see cref="CFile"/> object represented by the id.</returns>
        public static CFile GetFile(int id)
        {
            CFile f = null;
            string q = Queries.BuildQuery(QType.SELECT, "Files", null, null, $"id={id}");

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            try
                            {
                                reader.Read();
                                f = new CFile
                                {
                                    ID = reader.GetInt32(0),
                                    FileName = reader.GetString(1),
                                    Description = reader.GetString(2),
                                    Extension = (FileExtension)(Enum.Parse(typeof(FileExtension), reader.GetString(3))),
                                    FileEncoding = Encoding.GetEncoding(reader.GetInt32(5))
                                };
                                long length = reader.GetBytes(4, 0, null, 0, 0);
                                byte[] fileContents = new byte[length];
                                reader.GetBytes(4, 0, fileContents, 0, fileContents.Length);
                                f.Contents = fileContents;
                            }
                            catch (Exception)
                            {
                                RuntimeVars.Instance.LogFile.AddEntry($"Could not read file from database: {id}.");
                                return null;
                            }
                        }
                    }
                }
                con.Close();
            }
            return f;
        }

        /// <summary>
        /// Get multiple files from the database based on the supplied ids.
        /// </summary>
        /// <param name="ids">A variable length parameter: the list of ids of the file records to retrieve.</param>
        /// <returns>A list of <see cref="CFile"/> objects or an empty list if no files were found.</returns>
        public static List<CFile> GetFiles(params int[] ids)
        {
            List<CFile> files = new List<CFile>();
            foreach (int id in ids)
            {
                CFile f = null;
                string q = Queries.BuildQuery(QType.SELECT, "File", null, null, $"id={id}");

                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, con))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                try
                                {
                                    reader.Read();
                                    f = new CFile
                                    {
                                        ID = reader.GetInt32(0),
                                        FileName = reader.GetString(1),
                                        Description = reader.GetString(2),
                                        Extension = (FileExtension)(Enum.Parse(typeof(FileExtension), reader.GetString(3))),
                                        FileEncoding = Encoding.GetEncoding(reader.GetInt32(5))
                                    };
                                    long length = reader.GetBytes(4, 0, null, 0, 0);
                                    byte[] fileContents = new byte[length];
                                    reader.GetBytes(4, 0, fileContents, 0, fileContents.Length);
                                    f.Contents = fileContents;
                                }
                                catch (Exception)
                                {
                                    RuntimeVars.Instance.LogFile.AddEntry($"Could not read file from database: {id}.");
                                    return files;
                                }
                            }
                        }
                    }
                    con.Close();
                }
                files.Add(f);
            }
            return files;
        }

        /// <summary>
        /// Delete from the database the <see cref="CFile"/> object.
        /// </summary>
        /// <param name="file">The <see cref="CFile"/> to delete.</param>
        /// <returns>True if the file was deleted successfully; False otherwise.</returns>
        public static bool DeleteFile(CFile file)
        {
            int affectedRows = 0;
            string q = Queries.BuildQuery(QType.DELETE, "File", null, null, $"id={file.ID}");

            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlTransaction tr = con.BeginTransaction())
                        {
                            cmd.CommandText = q;
                            cmd.Transaction = tr;
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
            }
            catch (Exception)
            {
                RuntimeVars.Instance.LogFile.AddEntry($"Could not delete file: {file.ID}. It might be associated with another object.");
                return false;
            }

            return affectedRows != 0;
        }
        #endregion

        #region Survey
        /// <summary>
        /// Insert into the database the <see cref="Survey"/> <paramref name="s"/>.
        /// </summary>
        /// <param name="s">The <see cref="Survey"/> to insert.</param>
        /// <returns>The row id of the inserted object.</returns>
        public static int InsertSurvey(Survey s)
        {
            int affectedRows = 0;
            ArrayList columns = GetColumns("Survey");
            columns.RemoveAt(0); //remove the id column
            columns.TrimToSize(); //trim the arraylist after index removal
            string q = Queries.BuildQuery(QType.INSERT, "Survey", null, columns);

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

                        cmd.Parameters.AddWithValue("@0", s.JobNumber);
                        cmd.Parameters.AddWithValue("@1", s.Client.ID);
                        cmd.Parameters.AddWithValue("@2", s.Description);
                        cmd.Parameters.AddWithValue("@3", s.AbstractNumber);
                        cmd.Parameters.AddWithValue("@4", s.Subdivision);
                        cmd.Parameters.AddWithValue("@5", s.LotNumber);
                        cmd.Parameters.AddWithValue("@6", s.BlockNumber);
                        cmd.Parameters.AddWithValue("@7", s.SectionNumber);
                        cmd.Parameters.AddWithValue("@8", s.County.ID);
                        cmd.Parameters.AddWithValue("@9", s.Acres);

                        if (s.Realtor.IsValidRealtor)
                            cmd.Parameters.AddWithValue("@10", s.Realtor.ID);
                        else
                            cmd.Parameters.AddWithValue("@10", DBNull.Value);

                        if (s.TitleCompany.IsValidCompany)
                            cmd.Parameters.AddWithValue("@11", s.TitleCompany.ID);
                        else
                            cmd.Parameters.AddWithValue("@11", DBNull.Value);

                        cmd.Parameters.AddWithValue("@12", s.FileIds);
                        cmd.Parameters.AddWithValue("@13", s.Location.ID);
                        cmd.Parameters.AddWithValue("@14", s.BillingObject.GetBillingIds());
                        cmd.Parameters.AddWithValue("@15", s.BillingObject.GetLineItemIds());
                        cmd.Parameters.AddWithValue("@16", s.GetNotesString());
                        cmd.Parameters.AddWithValue("@17", s.SurveyName);
                        cmd.Parameters.AddWithValue("@18", s.LastUpdated);


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
            return affectedRows != 0 ? GetLastRowIDInserted("Survey") : 0;
        }

        /// <summary>
        /// Update in the database the <see cref="Survey"/> <paramref name="s"/>.
        /// </summary>
        /// <param name="s">The <see cref="Survey"/> to update.</param>
        /// <returns>True if the update was successfull; False otherwise.</returns>
        public static bool UpdateSurvey(Survey s)
        {
            int affectedRows = 0;
            ArrayList columns = GetColumns("Survey");
            string q = Queries.BuildQuery(QType.UPDATE, "Survey", null, columns, $"survey_id={s.ID}");

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

                        cmd.Parameters.AddWithValue("@0", s.ID);
                        cmd.Parameters.AddWithValue("@1", s.JobNumber);
                        cmd.Parameters.AddWithValue("@2", s.Client.ID);
                        cmd.Parameters.AddWithValue("@3", s.Description);
                        cmd.Parameters.AddWithValue("@4", s.AbstractNumber);
                        cmd.Parameters.AddWithValue("@5", s.Subdivision);
                        cmd.Parameters.AddWithValue("@6", s.LotNumber);
                        cmd.Parameters.AddWithValue("@7", s.BlockNumber);
                        cmd.Parameters.AddWithValue("@8", s.SectionNumber);
                        cmd.Parameters.AddWithValue("@9", s.County.ID);
                        cmd.Parameters.AddWithValue("@10", s.Acres);

                        if (s.Realtor.IsValidRealtor)
                            cmd.Parameters.AddWithValue("@11", s.Realtor.ID);
                        else
                            cmd.Parameters.AddWithValue("@11", DBNull.Value);

                        if (s.TitleCompany.IsValidCompany)
                            cmd.Parameters.AddWithValue("@12", s.TitleCompany.ID);
                        else
                            cmd.Parameters.AddWithValue("@12", DBNull.Value);

                        cmd.Parameters.AddWithValue("@13", s.FileIds);
                        cmd.Parameters.AddWithValue("@14", s.Location.ID);
                        cmd.Parameters.AddWithValue("@15", s.BillingObject.GetBillingIds());
                        cmd.Parameters.AddWithValue("@16", s.BillingObject.GetLineItemIds());
                        cmd.Parameters.AddWithValue("@17", s.GetNotesString());
                        cmd.Parameters.AddWithValue("@18", s.SurveyName);
                        cmd.Parameters.AddWithValue("@19", s.LastUpdated);

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
        /// Search the database for the specified <paramref name="clientName"/> and get a value indiciating if the Client already exists.
        /// </summary>
        /// <param name="clientName">The client's name to search for.</param>
        /// <returns>True if the client already exists; False otherwise.</returns>
        public static bool DoesClientExist(string clientName)
        {
            bool exists = false;
            string name = clientName.TrimEnd();
            name = name.TrimStart();

            string q = Queries.BuildQuery(QType.SELECT, "Client", null, new ArrayList { "name" }, $"name LIKE '{name}'");
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    using MySqlDataReader reader = cmd.ExecuteReader();
                    exists = reader.HasRows;
                }
                con.Close();
            }
            return exists;
        }

        /// <summary>
        /// Search the database for the specified <paramref name="titleCompanyName"/> and get a value indiciating if the Title Company already exists.
        /// </summary>
        /// <param name="titleCompanyName">The title company's name to search for.</param>
        /// <returns>True if the title company already exists; False otherwise.</returns>
        public static bool DoesTitleCompanyExist(string titleCompanyName)
        {
            bool exists = false;
            string name = titleCompanyName.TrimEnd();
            name = name.TrimStart();

            string q = Queries.BuildQuery(QType.SELECT, "TitleCompany", null, new ArrayList { "name" }, $"name LIKE '{name}'");
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    using MySqlDataReader reader = cmd.ExecuteReader();
                    exists = reader.HasRows;
                }
                con.Close();
            }
            return exists;
        }

        /// <summary>
        /// Search the database for the specified <paramref name="realtorName"/> and get a value indiciating if the Realtor already exists.
        /// </summary>
        /// <param name="realtorName">The Realtor's name to search for.</param>
        /// <returns>True if the realtor already exists; False otherwise.</returns>
        public static bool DoesRealtorExist(string realtorName)
        {
            bool exists = false;
            string name = realtorName.TrimEnd();
            name = name.TrimStart();

            string q = Queries.BuildQuery(QType.SELECT, "Realtor", null, new ArrayList { "name" }, $"name LIKE '{name}'");
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    using MySqlDataReader reader = cmd.ExecuteReader();
                    exists = reader.HasRows;
                }
                con.Close();
            }
            return exists;
        }

        /// <summary>
        /// Search the database for the specified <paramref name="jobNumber"/> and get a value indicating if the job already exists.
        /// </summary>
        /// <param name="jobNumber">The job number to search for.</param>
        /// <returns>True if the survey job already exists; False otherwise.</returns>
        public static bool DoesSurveyExist(string jobNumber)
        {
            bool exists = false;
            string q = Queries.BuildQuery(QType.SELECT, "Survey", null, new ArrayList { "job_number" }, $"job_number='{jobNumber}'");
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    using MySqlDataReader reader = cmd.ExecuteReader();
                    exists = reader.HasRows;
                }
                con.Close();
            }
            return exists;
        }

        /// <summary>
        /// Get from the database the <see cref="Survey"/> object represented by the primary key <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the survey object.</param>
        /// <returns>An <see cref="Survey"/> object represented by the id.</returns>
        public static Survey GetSurvey(int id)
        {
            Survey s = null;
            string q = Queries.BuildQuery(QType.SELECT, "Survey", null, null, $"survey_id={id}");

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
                            s = new Survey
                            {
                                ID = reader.GetInt32(0),
                                JobNumber = reader.GetString(1),
                                ClientID = reader.GetInt32(2),
                                Description = reader.GetString(3),
                                AbstractNumber = reader.GetString(4),
                                Subdivision = reader.GetString(5),
                                LotNumber = reader.GetString(6),
                                BlockNumber = reader.GetString(7),
                                SectionNumber = reader.GetString(8),
                                CountyID = reader.GetInt32(9),
                                Acres = reader.GetDouble(10),
                                FileIds = reader.GetString(13),
                                LocationID = reader.GetInt32(14),
                                NotesString = reader.GetString(17),
                                SurveyName = reader.GetString(18),
                                LastUpdated = reader.GetDateTime(19)
                            };

                            if (reader.IsDBNull(11))
                                s.RealtorID = 0;
                            else
                                s.RealtorID = reader.GetInt32(11);

                            if (reader.IsDBNull(12))
                                s.TitleCompanyID = 0;
                            else
                                s.TitleCompanyID = reader.GetInt32(12);

                            s.BillingObject.BillingIds = reader.GetString(15);
                            s.BillingObject.LineItemIds = reader.GetString(16);

                            s.SetObjects();
                        }
                    }
                }
                con.Close();
            }
            return s;
        }

        /// <summary>
        /// Get from the database the <see cref="Survey"/> object represented by the job number <paramref name="jobNumber"/>.
        /// </summary>
        /// <param name="jobNumber">The job number of the survey object.</param>
        /// <returns>An <see cref="Survey"/> object represented by the job number.</returns>
        public static Survey GetSurvey(string jobNumber)
        {
            Survey s = null;
            string q = Queries.BuildQuery(QType.SELECT, "Survey", null, null, $"job_number='{jobNumber}'");

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
                            s = new Survey
                            {
                                ID = reader.GetInt32(0),
                                JobNumber = reader.GetString(1),
                                ClientID = reader.GetInt32(2),
                                Description = reader.GetString(3),
                                AbstractNumber = reader.GetString(4),
                                Subdivision = reader.GetString(5),
                                LotNumber = reader.GetString(6),
                                BlockNumber = reader.GetString(7),
                                SectionNumber = reader.GetString(8),
                                CountyID = reader.GetInt32(9),
                                Acres = reader.GetDouble(10),
                                FileIds = reader.GetString(13),
                                LocationID = reader.GetInt32(14),
                                NotesString = reader.GetString(17),
                                SurveyName = reader.GetString(18),
                                LastUpdated = reader.GetDateTime(19)
                            };

                            if (reader.IsDBNull(11))
                                s.RealtorID = 0;
                            else
                                s.RealtorID = reader.GetInt32(11);

                            if (reader.IsDBNull(12))
                                s.TitleCompanyID = 0;
                            else
                                s.TitleCompanyID = reader.GetInt32(12);

                            s.BillingObject.BillingIds = reader.GetString(15);
                            s.BillingObject.LineItemIds = reader.GetString(16);

                            s.SetObjects();
                        }
                    }
                }
                con.Close();
            }
            return s;
        }

        /// <summary>
        /// Get from the database all <see cref="Survey"/> objects.
        /// </summary>
        /// <returns>A list of <see cref="Survey"/> objects.</returns>
        public static List<Survey> GetSurveys()
        {
            List<Survey> surveys = new List<Survey>();
            Survey s = null;
            string q = Queries.BuildQuery(QType.SELECT, "Survey");

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                s = new Survey
                                {
                                    ID = reader.GetInt32(0),
                                    JobNumber = reader.GetString(1),
                                    ClientID = reader.GetInt32(2),
                                    Description = reader.GetString(3),
                                    AbstractNumber = reader.GetString(4),
                                    Subdivision = reader.GetString(5),
                                    LotNumber = reader.GetString(6),
                                    BlockNumber = reader.GetString(7),
                                    SectionNumber = reader.GetString(8),
                                    CountyID = reader.GetInt32(9),
                                    Acres = reader.GetDouble(10),
                                    FileIds = reader.GetString(13),
                                    LocationID = reader.GetInt32(14),
                                    NotesString = reader.GetString(17),
                                    SurveyName = reader.GetString(18),
                                    LastUpdated = reader.GetDateTime(19)
                                };

                                if (reader.IsDBNull(11))
                                    s.RealtorID = 0;
                                else
                                    s.RealtorID = reader.GetInt32(11);

                                if (reader.IsDBNull(12))
                                    s.TitleCompanyID = 0;
                                else
                                    s.TitleCompanyID = reader.GetInt32(12);

                                s.BillingObject.BillingIds = reader.GetString(15);
                                s.BillingObject.LineItemIds = reader.GetString(16);

                                s.SetObjects();

                                surveys.Add(s);
                            }
                        }
                    }
                }
                con.Close();
            }
            return surveys;
        }

        /// <summary>
        /// Delete from the database the <see cref="Survey"/> object.
        /// </summary>
        /// <param name="s">The <see cref="Survey"/> to delete.</param>
        /// <returns>True if the survey was deleted successfully; False otherwise.</returns>
        public static bool DeleteSurvey(Survey s)
        {
            int affectedRows = 0;
            string q = Queries.BuildQuery(QType.DELETE, "Survey", null, null, $"survey_id={s.ID}");

            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlTransaction tr = con.BeginTransaction())
                        {
                            cmd.CommandText = q;
                            cmd.Transaction = tr;
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
            }
            catch (Exception)
            {
                RuntimeVars.Instance.LogFile.AddEntry($"Could not delete survey: {s.ID}. It might be associated with another object.");
                return false;
            }

            return affectedRows != 0;
        }
        #endregion

        #region Line Items
        /// <summary>
        /// Insert into the database the <see cref="LineItem"/> <paramref name="item"/>.
        /// </summary>
        /// <param name="item">The <see cref="LineItem"/> to insert.</param>
        /// <returns>The row id of the inserted object.</returns>
        public static int InsertLineItem(LineItem item)
        {
            int affectedRows = 0;
            ArrayList columns = GetColumns("LineItem");
            columns.RemoveAt(0); //remove the id column
            columns.TrimToSize(); //trim the arraylist after index removal
            string q = Queries.BuildQuery(QType.INSERT, "LineItem", null, columns);

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

                        cmd.Parameters.AddWithValue("@0", item.Amount);
                        cmd.Parameters.AddWithValue("@1", item.Description);
                        cmd.Parameters.AddWithValue("@2", item.TaxRate);

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
            return affectedRows != 0 ? GetLastRowIDInserted("LineItem") : 0;
        }

        /// <summary>
        /// Update in the database the <see cref="LineItem"/> <paramref name="item"/>.
        /// </summary>
        /// <param name="item">The <see cref="LineItem"/> to update.</param>
        /// <returns>True if the update was successfull; False otherwise.</returns>
        public static bool UpdateLineItem(LineItem item)
        {
            if (item.ID == 0)
                return item.Insert() == DatabaseError.NoError;

            int affectedRows = 0;
            ArrayList columns = GetColumns("LineItem");
            string q = Queries.BuildQuery(QType.UPDATE, "LineItem", null, columns, $"item_id={item.ID}");

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

                        cmd.Parameters.AddWithValue("@0", item.ID);
                        cmd.Parameters.AddWithValue("@1", item.Amount);
                        cmd.Parameters.AddWithValue("@2", item.Description);
                        cmd.Parameters.AddWithValue("@3", item.TaxRate);

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
        /// Get from the database the <see cref="LineItem"/> object represented by the primary key <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the line item object.</param>
        /// <returns>An <see cref="LineItem"/> object represented by the id.</returns>
        public static LineItem GetLineItem(int id)
        {
            LineItem item = null;
            string q = Queries.BuildQuery(QType.SELECT, "LineItem", null, null, $"item_id={id}");

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
                            item = new LineItem
                            {
                                ID = reader.GetInt32(0),
                                Amount = reader.GetDecimal(1),
                                Description = reader.GetString(2),
                                TaxRate = reader.GetDouble(3),
                            };
                        }
                    }
                }
                con.Close();
            }
            return item;
        }

        /// <summary>
        /// Get multiple <see cref="LineItem"/> objects from the database based on the supplied ids.
        /// </summary>
        /// <param name="ids">A variable length parameter: the list of ids of the line item records to retrieve.</param>
        /// <returns>A list of <see cref="LineItem"/> objects or an empty list if no line items were found.</returns>
        public static List<LineItem> GetLineItems(params int[] ids)
        {
            List<LineItem> items = new List<LineItem>();

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                foreach (int id in ids)
                {
                    string q = Queries.BuildQuery(QType.SELECT, "LineItem", null, null, $"item_id={id}");

                    using (MySqlCommand cmd = new MySqlCommand(q, con))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                items.Add(new LineItem
                                {
                                    ID = reader.GetInt32(0),
                                    Amount = reader.GetDecimal(1),
                                    Description = reader.GetString(2),
                                    TaxRate = reader.GetDouble(3),
                                });
                            }
                        }
                    }
                }
                con.Close();
            }
            return items;
        }

        /// <summary>
        /// Delete from the database the <see cref="LineItem"/> object.
        /// </summary>
        /// <param name="s">The <see cref="LineItem"/> to delete.</param>
        /// <returns>True if the line item was deleted successfully; False otherwise.</returns>
        public static bool DeleteLineItem(int id)
        {
            int affectedRows = 0;
            string q = Queries.BuildQuery(QType.DELETE, "LineItem", null, null, $"item_id={id}");

            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlTransaction tr = con.BeginTransaction())
                        {
                            cmd.CommandText = q;
                            cmd.Transaction = tr;
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
            }
            catch (Exception)
            {
                RuntimeVars.Instance.LogFile.AddEntry($"Could not delete line item: {id}. It might be associated with another object.");
                return false;
            }

            return affectedRows != 0;
        }
        #endregion

        #region Rates
        /// <summary>
        /// Insert into the database the <see cref="Rate"/> <paramref name="item"/>.
        /// </summary>
        /// <param name="item">The <see cref="Rate"/> to insert.</param>
        /// <returns>The row id of the inserted object.</returns>
        public static int InsertRate(Rate item)
        {
            int affectedRows = 0;
            ArrayList columns = GetColumns("Rates");
            columns.RemoveAt(0); //remove the id column
            columns.TrimToSize(); //trim the arraylist after index removal
            string q = Queries.BuildQuery(QType.INSERT, "Rates", null, columns);

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

                        cmd.Parameters.AddWithValue("@0", item.Description);
                        cmd.Parameters.AddWithValue("@1", item.Amount);
                        cmd.Parameters.AddWithValue("@2", item.TimeUnit.ToString());
                        cmd.Parameters.AddWithValue("@3", item.TaxIncluded);

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
            return affectedRows != 0 ? GetLastRowIDInserted("Rates") : 0;
        }

        /// <summary>
        /// Update in the database the <see cref="Rate"/> <paramref name="item"/>.
        /// </summary>
        /// <param name="item">The <see cref="Rate"/> to update.</param>
        /// <returns>True if the update was successfull; False otherwise.</returns>
        public static bool UpdateRate(Rate item)
        {
            if (item.ID == 0)
                return item.Insert() == DatabaseError.NoError;

            int affectedRows = 0;
            ArrayList columns = GetColumns("Rates");
            string q = Queries.BuildQuery(QType.UPDATE, "Rates", null, columns, $"rate_id={item.ID}");

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

                        cmd.Parameters.AddWithValue("@0", item.ID);
                        cmd.Parameters.AddWithValue("@1", item.Description);
                        cmd.Parameters.AddWithValue("@2", item.Amount);
                        cmd.Parameters.AddWithValue("@3", item.TimeUnit.ToString());
                        cmd.Parameters.AddWithValue("@4", item.TaxIncluded);

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
        /// Get from the database the <see cref="Rate"/> object represented by the primary key <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the rate object.</param>
        /// <returns>An <see cref="Rate"/> object represented by the id.</returns>
        public static Rate GetRate(int id)
        {
            Rate item = null;
            string q = Queries.BuildQuery(QType.SELECT, "Rates", null, null, $"rate_id={id}");

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
                            item = new Rate
                            {
                                ID = reader.GetInt32(0),
                                Description = reader.GetString(1),
                                Amount = reader.GetDecimal(2),
                                TimeUnit = (TimeUnit)Enum.Parse(typeof(TimeUnit), reader.GetString(3)),
                                TaxIncluded = reader.GetBoolean(4)
                            };
                        }
                    }
                }
                con.Close();
            }
            return item;
        }

        /// <summary>
        /// Get from the database all <see cref="Rate"/> objects.
        /// </summary>
        /// <returns>A list of <see cref="Rate"/> objects.</returns>
        public static List<Rate> GetRates()
        {
            List<Rate> items = new List<Rate>();

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                string q = Queries.BuildQuery(QType.SELECT, "Rates", null, null);

                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Rate item = new Rate
                                {
                                    ID = reader.GetInt32(0),
                                    Description = reader.GetString(1),
                                    Amount = reader.GetDecimal(2),
                                    TimeUnit = (TimeUnit)Enum.Parse(typeof(TimeUnit), reader.GetString(3)),
                                    TaxIncluded = reader.GetBoolean(4)
                                };

                                items.Add(item);
                            }
                        }
                    }
                }
                con.Close();
            }
            return items;
        }

        /// <summary>
        /// Get multiple <see cref="Rate"/> objects from the database based on the supplied ids.
        /// </summary>
        /// <param name="ids">A variable length parameter: the list of ids of the rate records to retrieve.</param>
        /// <returns>A list of <see cref="Rate"/> objects or an empty list if no rates were found.</returns>
        public static List<Rate> GetRates(params int[] ids)
        {
            List<Rate> items = new List<Rate>();

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                foreach (int id in ids)
                {
                    string q = Queries.BuildQuery(QType.SELECT, "Rates", null, null, $"rate_id={id}");

                    using (MySqlCommand cmd = new MySqlCommand(q, con))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                Rate item = new Rate
                                {
                                    ID = reader.GetInt32(0),
                                    Description = reader.GetString(1),
                                    Amount = reader.GetDecimal(2),
                                    TimeUnit = (TimeUnit)Enum.Parse(typeof(TimeUnit), reader.GetString(3)),
                                    TaxIncluded = reader.GetBoolean(4)
                                };

                                items.Add(item);
                            }
                        }
                    }
                }
                con.Close();
            }
            return items;
        }

        /// <summary>
        /// Delete from the database the <see cref="Rate"/> object.
        /// </summary>
        /// <param name="rate">The <see cref="Rate"/> to delete.</param>
        /// <returns>True if the rate was deleted successfully; False otherwise.</returns>
        public static bool DeleteRate(Rate rate)
        {
            int affectedRows = 0;
            string q = Queries.BuildQuery(QType.DELETE, "Rates", null, null, $"rate_id={rate.ID}");

            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlTransaction tr = con.BeginTransaction())
                        {
                            cmd.CommandText = q;
                            cmd.Transaction = tr;
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
            }
            catch (Exception)
            {
                RuntimeVars.Instance.LogFile.AddEntry($"Could not delete rate: {rate.ID}. It might be associated with another object.");
                return false;
            }

            return affectedRows != 0;
        }
        #endregion

        #region Billing Items
        /// <summary>
        /// Insert into the database the <see cref="BillingItem"/> <paramref name="item"/>.
        /// </summary>
        /// <param name="item">The <see cref="BillingItem"/> to insert.</param>
        /// <returns>The row id of the inserted object.</returns>
        public static int InsertBillingItem(BillingItem item)
        {
            int affectedRows = 0;
            ArrayList columns = GetColumns("Billing");
            columns.RemoveAt(0); //remove the id column
            columns.TrimToSize(); //trim the arraylist after index removal
            string q = Queries.BuildQuery(QType.INSERT, "Billing", null, columns);

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

                        cmd.Parameters.AddWithValue("@0", item.Description);
                        cmd.Parameters.AddWithValue("@1", item.FieldRate.ID);
                        cmd.Parameters.AddWithValue("@2", item.OfficeRate.ID);
                        cmd.Parameters.AddWithValue("@3", item.FieldTime);
                        cmd.Parameters.AddWithValue("@4", item.OfficeTime);
                        cmd.Parameters.AddWithValue("@5", item.AssociatedDate);

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
            return affectedRows != 0 ? GetLastRowIDInserted("Billing") : 0;
        }

        /// <summary>
        /// Update in the database the <see cref="BillingItem"/> <paramref name="item"/>.
        /// </summary>
        /// <param name="item">The <see cref="BillingItem"/> to update.</param>
        /// <returns>True if the update was successfull; False otherwise.</returns>
        public static bool UpdateBillingItem(BillingItem item)
        {
            if (item.ID == 0)
                return item.Insert() == DatabaseError.NoError;

            int affectedRows = 0;
            ArrayList columns = GetColumns("Billing");
            string q = Queries.BuildQuery(QType.UPDATE, "Billing", null, columns, $"billing_id={item.ID}");

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

                        cmd.Parameters.AddWithValue("@0", item.ID);
                        cmd.Parameters.AddWithValue("@1", item.Description);
                        cmd.Parameters.AddWithValue("@2", item.FieldRate.ID);
                        cmd.Parameters.AddWithValue("@3", item.OfficeRate.ID);
                        cmd.Parameters.AddWithValue("@4", item.FieldTime);
                        cmd.Parameters.AddWithValue("@5", item.OfficeTime);
                        cmd.Parameters.AddWithValue("@6", item.AssociatedDate);

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
        /// Get from the database the <see cref="BillingItem"/> object represented by the primary key <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the billing item object.</param>
        /// <returns>An <see cref="BillingItem"/> object represented by the id.</returns>
        public static BillingItem GetBillingItem(int id)
        {
            BillingItem item = null;
            string q = Queries.BuildQuery(QType.SELECT, "Billing", null, null, $"billing_id={id}");

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
                            item = new BillingItem
                            {
                                ID = reader.GetInt32(0),
                                Description = reader.GetString(1),
                                FieldRateId = reader.GetInt32(2),
                                OfficeRateId = reader.GetInt32(3),
                                FieldTime = reader.GetTimeSpan(4),
                                OfficeTime = reader.GetTimeSpan(5),
                                AssociatedDate = reader.GetDateTime(6)
                            };

                            item.SetObjects();
                        }
                    }
                }
                con.Close();
            }
            return item;
        }

        /// <summary>
        /// Get multiple <see cref="BillingItem"/> objects from the database based on the supplied ids.
        /// </summary>
        /// <param name="ids">A variable length parameter: the list of ids of the billing item records to retrieve.</param>
        /// <returns>A list of <see cref="BillingItem"/> objects or an empty list if no rates were found.</returns>
        public static List<BillingItem> GetBillingItems(params int[] ids)
        {
            List<BillingItem> items = new List<BillingItem>();

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                foreach (int id in ids)
                {
                    string q = Queries.BuildQuery(QType.SELECT, "Billing", null, null, $"billing_id={id}");

                    using (MySqlCommand cmd = new MySqlCommand(q, con))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                BillingItem item = new BillingItem
                                {
                                    ID = reader.GetInt32(0),
                                    Description = reader.GetString(1),
                                    FieldRateId = reader.GetInt32(2),
                                    OfficeRateId = reader.GetInt32(3),
                                    FieldTime = reader.GetTimeSpan(4),
                                    OfficeTime = reader.GetTimeSpan(5),
                                    AssociatedDate = reader.GetDateTime(6)
                                };

                                item.SetObjects();

                                items.Add(item);
                            }
                        }
                    }
                }
                con.Close();
            }
            return items;
        }

        /// <summary>
        /// Delete from the database the <see cref="BillingItem"/> object.
        /// </summary>
        /// <param name="item">The <see cref="BillingItem"/> to delete.</param>
        /// <returns>True if the billing item was deleted successfully; False otherwise.</returns>
        public static bool DeleteBillingItem(BillingItem item)
        {
            int affectedRows = 0;
            string q = Queries.BuildQuery(QType.DELETE, "Billing", null, null, $"billing_id={item.ID}");

            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlTransaction tr = con.BeginTransaction())
                        {
                            cmd.CommandText = q;
                            cmd.Transaction = tr;
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
            }
            catch (Exception)
            {
                RuntimeVars.Instance.LogFile.AddEntry($"Could not delete billing item: {item.ID}. It might be associated with another object.");
                return false;
            }

            return affectedRows != 0;
        }
        #endregion
    }
}
