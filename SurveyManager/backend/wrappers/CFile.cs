using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class CFile : ExpandableObjectConverter, DatabaseWrapper
    {
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
        public byte[] Contents { get; set; }

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

        [Browsable(false)]
        public bool IsValidFile
        {
            get
            {
                return Contents.Length > 0 && Extension != FileExtension.NONE && FileName.Length > 0;
            }
        }

        [Browsable(false)]
        public Bitmap DisplayIcon
        {
            get
            {
                if (Extension != FileExtension.NONE)
                {
                    switch (Extension)
                    {
                        case FileExtension.DWG:
                            return Resources.dwg_16x16;
                        case FileExtension.PNG:
                        case FileExtension.JPEG:
                        case FileExtension.JPG:
                            return Resources.png_16x16;
                        case FileExtension.DOC:
                        case FileExtension.DOCX:
                            return Resources.doc_16x16;
                        case FileExtension.PDF:
                            return Resources.pdf_16x16;
                        case FileExtension.TXT:
                            return Resources.txt_16x16;
                    }
                }
                return new Bitmap(16, 16);
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

        public bool ReadAllBytes(string path)
        {
            try
            {
                Contents = File.ReadAllBytes(path);
                SetEncoding(path);
                return true;
            }
            catch (Exception ex)
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
            throw new NotImplementedException();
        }

        public DatabaseError Update()
        {
            throw new NotImplementedException();
        }
    }
}
