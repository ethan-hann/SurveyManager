using SurveyManager.backend.wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.utility
{
    public class CFileTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return true;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string))
                return base.ConvertTo(context, culture, value, destinationType);

            List<CFile> files = value as List<CFile>;
            if (files == null || files.Count == 0)
                return "No files pending upload.";

            CFile[] arr = files.ToArray();
            return "";//return string.Join(",", arr);
        }

        //public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        //{
        //    List<PropertyDescriptor> list = new List<PropertyDescriptor>();
        //    List<CFile> files = value as List<CFile>;

        //    if (files != null)
        //    {
        //        foreach (CFile f in files)
        //        {
        //            if (f.IsValidFile)
        //            {
        //                list.Add(new CFileDescriptor(f, list.Count));
        //            }
        //        }
        //    }
        //    return new PropertyDescriptorCollection(list.ToArray());
        //}

        //public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        //{
        //    return true;
        //}

        //private class CFileDescriptor : SimplePropertyDescriptor
        //{
        //    public CFile File { get; private set; }

        //    public CFileDescriptor(CFile file, int index) : base(file.GetType(), index.ToString(), typeof(string))
        //    {
        //        File = file;
        //    }

        //    public override object GetValue(object component)
        //    {
        //        return File.FullFileName;
        //    }

        //    public override void SetValue(object component, object value)
        //    {
        //        File.FileName = (string)value;
        //    }
        //}
    }
}
