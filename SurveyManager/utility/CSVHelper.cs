using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace SurveyManager.utility
{
    /// <summary>
    /// This class is used to create comma-seperated value files. Mainly, it used to dump the database data.
    /// </summary>
    public class CSVHelper
    {
        /// <summary>
        /// Creates a CSV file from the specified <see cref="DataTable"/>.
        /// </summary>
        /// <param name="dataTable">The <see cref="DataTable"/> to dump.</param>
        /// <param name="filePath">The path with the file name the CSV file should be saved to.</param>
        /// <param name="delimiter">An optional delimiter to seperate fields.</param>
        public static void CreateCSV(DataTable dataTable, string filePath, string delimiter = ",")
        {
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                throw new DirectoryNotFoundException($"Destination folder not found: {filePath}");

            DataColumn[] columns = dataTable.Columns.Cast<DataColumn>().ToArray();

            var lines = (new[] { string.Join(delimiter, columns.Select(c => c.ColumnName)) })
              .Concat(dataTable.Rows.Cast<DataRow>()
              .Select(row => string.Join(delimiter, columns.Select(c => row[c]))));

            File.WriteAllLines(filePath, lines);
        }

        /// <summary>
        /// Dumps all data to CSV files from the specified list of data tables.
        /// <para>The CSV filenames are the same as the table names.</para>
        /// </summary>
        /// <param name="tables">The <see cref="List{T}"/> of <see cref="DataTable"/>s to dump.</param>
        /// <param name="folderPath">The path to the folder where the files should be saved.</param>
        /// <param name="delimiter">An optional delimiter to seperate fields.</param>
        public static void DumpTables(List<DataTable> tables, string folderPath, string delimiter = ",")
        {
            if (!Directory.Exists(folderPath))
                throw new DirectoryNotFoundException($"Destination folder not found: {folderPath}");

            int tableCounter = 0;
            foreach (DataTable table in tables)
            {
                tableCounter++;
                string fileName = $"{table.TableName}.csv";
                string path = Path.Combine(folderPath, fileName);
                DataColumn[] columns = table.Columns.Cast<DataColumn>().ToArray();
                if (table.TableName.Equals("Survey"))
                    delimiter = "~"; //change delimeter if working with survey table because of the use of commas in notes and time entries.

                var lines = (new[] { string.Join(delimiter, columns.Select(c => c.ColumnName)) })
                  .Concat(table.Rows.Cast<DataRow>()
                  .Select(row => string.Join(delimiter, columns.Select(c => row[c]))));

                File.WriteAllLines(path, lines);
            }
        }
    }
}
