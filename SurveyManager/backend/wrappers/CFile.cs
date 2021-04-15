using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers
{
    /// <summary>
    /// A class which represents a custom file that can be stored in the database.
    /// </summary>
    [TypeConverter(typeof(CFileTypeConverter))]
    [Serializable]
    public class CFile : DatabaseWrapper
    {
        private string tempPath = string.Empty;

        [Browsable(false)]
        public int ID { get; set; }

        [Category("File Information")]
        [Description("The file's name, without extension.")]
        [Browsable(true)]
        [DisplayName("File Name")]
        public string FileName { get; set; } = "";

        [Category("File Information")]
        [Description("A description explaining the contents of the file.")]
        [Browsable(true)]
        [DisplayName("Description")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Description { get; set; } = "";

        [Browsable(false)]
        public FileExtension Extension { get; set; } = FileExtension.NONE;

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

        [Browsable(false)]
        public string TempPath { get; internal set; }

        /// <summary>
        /// The RAW byte array representing the file's contents.
        /// </summary>
        [Browsable(false)]
        public byte[] Contents { get; set; }

        /// <summary>
        /// Get the encoding for this file.
        /// </summary>
        [Browsable(false)]
        public Encoding FileEncoding { get; set; } = Encoding.Default;

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
        /// Reads the contents in <paramref name="path"/> into the <see cref="Contents"/> property.
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
        /// <returns></returns>
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

        public DatabaseError Delete()
        {
            return Database.DeleteFile(this) ? DatabaseError.NoError : DatabaseError.FileDelete;
        }

        public DatabaseError Insert()
        {
            if (!IsValidFile)
                return DatabaseError.FileIncomplete;
            ID = Database.InsertFile(this);

            return ID != 0 ? DatabaseError.NoError : DatabaseError.FileInsert;
        }

        public DatabaseError Update()
        {
            if (!IsValidFile)
                return DatabaseError.FileIncomplete;

            return Database.UpdateFile(this) ? DatabaseError.NoError : DatabaseError.FileUpdate;
        }
    }
}
