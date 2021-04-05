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

        public static bool DeleteRealtor(Realtor c)
        {
            int affectedRows = 0;
            string q = Queries.BuildQuery(QType.DELETE, "Realtor", null, null, $"realtor_id={c.ID}");

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
                return false;
            }

            return affectedRows != 0;
        }
        #endregion
    }
}
