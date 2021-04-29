using MySql.Data.MySqlClient;
using SurveyManager.backend.wrappers;
using SurveyManager.backend.wrappers.SurveyJob;
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
                    RuntimeVars.Instance.LogFile.AddEntry($"Error when trying to connect to SQL database: {ex.Message}");
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
                } catch (MySqlException ex)
                {
                    dt.Columns.Add("MySQL Error");
                    dt.Columns.Add("Error Code");
                    dt.Rows.Add(ex.Message, ex.ErrorCode);
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

        #region Address
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
            } catch (Exception)
            {
                RuntimeVars.Instance.LogFile.AddEntry($"Could not delete address: {a.ID}. It might be associated with another object.");
                return false;
            }
            
            return affectedRows != 0;
        }
        #endregion

        #region Client
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
        public static bool InsertCounty(County c)
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
            return affectedRows != 0;
        }

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
        public static bool InsertRealtor(Realtor r)
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
            return affectedRows != 0;
        }

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
        public static bool InsertTitleCompany(TitleCompany t)
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
            return affectedRows != 0;
        }

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
        /// Attempts to insert a new record into the File table. If the insert could not be completed, the transaction is rolled back
        /// and no data is committed to the database.
        /// </summary>
        /// <param name="file">The <see cref="CFile"/> object to insert</param>
        /// <returns>The row id of the inserted file; 0 if the file was not inserted.</returns>
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
        /// Update the <see cref="CFile"/> object in the database. If the file has an ID of 0, it is inserted instead.
        /// </summary>
        /// <param name="file">The file to update/insert.</param>
        /// <returns>True if the update/insert completed successfully. False otherwise.</returns>
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
        /// Retrieve a single <see cref="CFile"/> record from the database.
        /// </summary>
        /// <param name="id">The id of the file record.</param>
        /// <returns>A single <see cref="CFile"/> object representing the file record or <c>null</c> if no file was found</returns>
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
        /// Retrieves multiple files from the database based on the supplied ids.
        /// </summary>
        /// <param name="ids">A variable length parameter: the list of ids of the file records to retrieve.</param>
        /// <returns>A <see cref="List{T}"/> of type <see cref="CFile"/> containing the file objects or an empty <see cref="List{T}"/> if no files were found</returns>
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
        /// Attempts to delete a file record from the database.
        /// </summary>
        /// <param name="file">The file to delete.</param>
        /// <returns>True if the deleting was successfull; False otherwise.</returns>
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
        public static bool InsertSurvey(Survey s)
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
                        cmd.Parameters.AddWithValue("@14", s.FieldRate);
                        cmd.Parameters.AddWithValue("@15", s.OfficeRate);
                        cmd.Parameters.AddWithValue("@16", s.FieldTime);
                        cmd.Parameters.AddWithValue("@17", s.OfficeTime);
                        cmd.Parameters.AddWithValue("@18", s.LineItemIds);
                        cmd.Parameters.AddWithValue("@19", s.GetNotesString());
                        cmd.Parameters.AddWithValue("@20", s.SurveyName);


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
                        cmd.Parameters.AddWithValue("@15", s.FieldRate);
                        cmd.Parameters.AddWithValue("@16", s.OfficeRate);
                        cmd.Parameters.AddWithValue("@17", s.FieldTime);
                        cmd.Parameters.AddWithValue("@18", s.OfficeTime);
                        cmd.Parameters.AddWithValue("@19", s.LineItemIds);
                        cmd.Parameters.AddWithValue("@20", s.GetNotesString());
                        cmd.Parameters.AddWithValue("@21", s.SurveyName);

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

        public static bool DoesSurveyExist(string jobNumber)
        {
            bool exists = false;
            string q = Queries.BuildQuery(QType.SELECT, "Survey", null, null, $"job_number='{jobNumber}'");
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        exists = reader.HasRows;
                    }
                }
                con.Close();
            }
            return exists;
        }

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
                                FieldRate = reader.GetDecimal(15),
                                OfficeRate = reader.GetDecimal(16),
                                FieldTime = reader.GetTimeSpan(17),
                                OfficeTime = reader.GetTimeSpan(18),
                                LineItemIds = reader.GetString(19),
                                NotesString = reader.GetString(20),
                                SurveyName = reader.GetString(21)
                            };

                            if (reader.IsDBNull(11))
                                s.RealtorID = 0;
                            else
                                s.RealtorID = reader.GetInt32(11);

                            if (reader.IsDBNull(12))
                                s.TitleCompanyID = 0;
                            else
                                s.TitleCompanyID = reader.GetInt32(12);

                            s.SetObjects();
                        }
                    }
                }
                con.Close();
            }
            return s;
        }

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
                                FieldRate = reader.GetDecimal(15),
                                OfficeRate = reader.GetDecimal(16),
                                FieldTime = reader.GetTimeSpan(17),
                                OfficeTime = reader.GetTimeSpan(18),
                                LineItemIds = reader.GetString(19),
                                NotesString = reader.GetString(20),
                                SurveyName = reader.GetString(21)
                            };

                            if (reader.IsDBNull(11))
                                s.RealtorID = 0;
                            else
                                s.RealtorID = reader.GetInt32(11);

                            if (reader.IsDBNull(12))
                                s.TitleCompanyID = 0;
                            else
                                s.TitleCompanyID = reader.GetInt32(12);

                            s.SetObjects();
                        }
                    }
                }
                con.Close();
            }
            return s;
        }

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
                                    FieldRate = reader.GetDecimal(15),
                                    OfficeRate = reader.GetDecimal(16),
                                    FieldTime = reader.GetTimeSpan(17),
                                    OfficeTime = reader.GetTimeSpan(18),
                                    LineItemIds = reader.GetString(19),
                                    NotesString = reader.GetString(20),
                                    SurveyName = reader.GetString(21)
                                };

                                if (reader.IsDBNull(11))
                                    s.RealtorID = 0;
                                else
                                    s.RealtorID = reader.GetInt32(11);

                                if (reader.IsDBNull(12))
                                    s.TitleCompanyID = 0;
                                else
                                    s.TitleCompanyID = reader.GetInt32(12);

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
    }
}
