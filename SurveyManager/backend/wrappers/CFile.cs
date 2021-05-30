using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Text;
using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers
{
    /// <summary>
    /// This class represents files. The main method of note in this class is <see cref="ReadAllBytes(string)"/>. This method will actually
    /// populate this file object with the data in the actual file on disk.
    /// <para>This class implements the <see cref="IDatabaseWrapper"/> interface to facilitate easier database operations.</para>
    /// </summary>
    [TypeConverter(typeof(CFileTypeConverter))]
    [Serializable]
    public class CFile : IDatabaseWrapper
    {
        [Browsable(false)]
        public int ID { get; set; }

        /// <summary>
        /// The file name, without an extension, for this file.
        /// </summary>
        [Category("File Information")]
        [Description("The file's name, without extension.")]
        [Browsable(true)]
        [DisplayName("File Name")]
        public string FileName { get; set; } = "";

        /// <summary>
        /// A brief description for this file explaining what it is.
        /// </summary>
        [Category("File Information")]
        [Description("A description explaining the contents of the file.")]
        [Browsable(true)]
        [DisplayName("Description")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Description { get; set; } = "";

        /// <summary>
        /// The extension of this file. This is limited to the options in <see cref="FileExtension"/>.
        /// </summary>
        [Browsable(false)]
        public FileExtension Extension { get; set; } = FileExtension.NONE;

        /// <summary>
        /// The full file name including its extension.
        /// </summary>
        [Category("File Contents")]
        [Description("The full file's name.")]
        [Browsable(true)]
        [DisplayName("Full Name")]
        public string FullFileName
        {
            get
            {
                return ToString();
            }
        }

        /// <summary>
        /// A temporary path on disk to this file object.
        /// </summary>
        [Browsable(false)]
        public string TempPath { get; internal set; }

        /// <summary>
        /// The raw byte array representing the file's contents.
        /// </summary>
        [Browsable(false)]
        public byte[] Contents { get; set; }

        /// <summary>
        /// Get the encoding for this file.
        /// </summary>
        [Browsable(false)]
        public Encoding FileEncoding { get; set; } = Encoding.Default;

        /// <summary>
        /// The size of the file as a formatted string. The string will be formatted as {size} {unit}, i.e. 5 MB for 5 megabytes.
        /// </summary>
        [Category("File Contents")]
        [Description("The size of the file as stored in the database.")]
        [Browsable(true)]
        [DisplayName("File Size")]
        public string FileSize
        {
            get
            {
                return Contents != null ? Utility.FormatSize(Contents.Length) : "0 KB";
            }
        }

        /// <summary>
        /// Get a value indicating if this is a valid file and thus ready to be saved to the database.
        /// <para>A valid file is one whose contents are not null or empty and has a file name and extension.</para>
        /// </summary>
        [Browsable(false)]
        public bool IsValidFile
        {
            get
            {
                return Contents != null && (Contents.Length > 0 && Extension != FileExtension.NONE && FileName.Length > 0);
            }
        }

        /// <summary>
        /// Get the icon to display for this file based on its <see cref="Extension"/> property.
        /// </summary>
        [Category("File Contents")]
        [Browsable(false)]
        [DisplayName("Icon")]
        public Bitmap DisplayIcon
        {
            get
            {
                if (Extension != FileExtension.NONE)
                {
                    switch (Extension)
                    {
                        case FileExtension.DWG:
                        case FileExtension.DXF:
                        case FileExtension.DWT:
                        case FileExtension.DXB:
                        return Resources.dwg_32x32;
                        case FileExtension.PNG:
                        case FileExtension.JPEG:
                        case FileExtension.JPG:
                        return Resources.png_32x32;
                        case FileExtension.DOC:
                        case FileExtension.DOCX:
                        return Resources.doc_32x32;
                        case FileExtension.PDF:
                        return Resources.pdf_32x32;
                        case FileExtension.TXT:
                        return Resources.txt_32x32;
                    }
                }
                return Resources.file_32x32;
            }
        }

        public CFile() { }

        public CFile(int iD, string fileName, string description, FileExtension extension, byte[] contents, Encoding fileEncoding)
        {
            ID = iD;
            FileName = fileName;
            Description = description;
            Extension = extension;
            Contents = contents;
            FileEncoding = fileEncoding;
        }

        public CFile(string fileName, string description, FileExtension extension, byte[] contents, Encoding fileEncoding)
        {
            FileName = fileName;
            Description = description;
            Extension = extension;
            Contents = contents;
            FileEncoding = fileEncoding;
        }

        public CFile(string fileName, string description, FileExtension extension, byte[] contents)
        {
            FileName = fileName;
            Description = description;
            Extension = extension;
            Contents = contents;
        }

        public CFile(int iD, string fileName, string description, FileExtension extension, byte[] contents)
        {
            ID = iD;
            FileName = fileName;
            Description = description;
            Extension = extension;
            Contents = contents;
        }

        public CFile(int iD, string fileName, string description, FileExtension extension)
        {
            ID = iD;
            FileName = fileName;
            Description = description;
            Extension = extension;
        }

        public CFile(string fileName, string description, FileExtension extension)
        {
            FileName = fileName;
            Description = description;
            Extension = extension;
        }

        /// <summary>
        /// Reads all of the bytes of the file in <paramref name="path"/> into the <see cref="Contents"/> property.
        /// </summary>
        /// <param name="path">The path to the file to read from.</param>
        /// <returns>True if the file was read successfully; False otherwise.</returns>
        public bool ReadAllBytes(string path)
        {
            try
            {
                Contents = File.ReadAllBytes(path);
                SetEncoding(path);
                return true;
            }
            catch (Exception)
            {
                RuntimeVars.Instance.LogFile.AddEntry($"Error when trying to read a file: {path}");
                return false;
            }
        }

        private void SetEncoding(string path)
        {
            using (StreamReader reader = new StreamReader(path, Encoding.ASCII, true))
            {
                reader.Peek();
                FileEncoding = reader.CurrentEncoding;
            }
        }

        /// <summary>
        /// Get a file path to this CFile object. The temporary file is deleted after the program is closed.
        /// </summary>
        /// <returns>The path to the temporary file.</returns>
        public string GetTempFile()
        {
            if (Contents.Length == 0)
                return null;

            string path = Path.Combine(RuntimeVars.Instance.TempFiles.TempDir, Path.GetRandomFileName() + $"-{FullFileName}");
            File.WriteAllBytes(path, Contents);
            RuntimeVars.Instance.TempFiles.AddFile(path, false);

            TempPath = path;

            return path;
        }

        /// <summary>
        /// Override for <see cref="object.ToString()"/> that returns a readable version of this <see cref="CFile"/>.
        /// </summary>
        /// <returns><c>FileName.Extension</c></returns>
        public override string ToString()
        {
            return $"{FileName}.{Extension.ToString().ToLower()}";
        }

        public DatabaseError Insert()
        {
            DatabaseError e;
            if (IsValidFile)
            {
                if (ID == 0)
                {
                    ID = Database.InsertFile(this);
                    e = ID != 0 ? DatabaseError.NoError : DatabaseError.FileInsert;
                }
                else
                {
                    e = Database.UpdateFile(this) ? DatabaseError.NoError : DatabaseError.FileUpdate;
                }
                return e;
            }
            return DatabaseError.FileIncomplete;
        }

        public DatabaseError Update()
        {
            return Insert();
        }

        public DatabaseError Delete()
        {
            return Database.DeleteFile(this) ? DatabaseError.NoError : DatabaseError.FileDelete;
        }
    }
}
