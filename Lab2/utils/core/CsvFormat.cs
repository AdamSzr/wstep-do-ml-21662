using System;
using Newtonsoft.Json;
using System.IO;
using CSharp_Utils;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

public class CsvFormat
{

    string headers;
    List<string> rows;
    char separator;
    int fieldCount;
    private CsvFormat()
    {
        this.rows = new List<string>();
    }

    public static CsvFormat With(string headers, char separator = ',')
    {
        CsvFormat obj = new CsvFormat();
        obj.headers = headers;
        obj.separator = separator;
        obj.fieldCount = headers.Split(separator).Length;
        return obj;
    }
    public bool AddDataRow(string row)
    {
        if (ValidateRow(row))
            this.rows.Add(row);

        return true;
    }
    private bool ValidateRow(string row)
    {
        return row.Split(separator).Length == fieldCount;
    }

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        sb.Append(headers);
        for (int i = 0; i < rows.Count; i++)
        {
            sb.Append(rows[i]);
            if (i != rows.Count - 1)
                sb.AppendLine();
        }
        return sb.ToString();
    }

    public void Save(FileInfo file)
    {
        if ((file.Extension != ".csv"))
            throw new Exception("File that has to be saved does not contain .csv file extension");

        using (FileStream fs = file.OpenWrite())
        {
            fs.Write(this.ToString().ConvertToByteArray());
        }
    }

    public static string CreateHeader(object o, char separator = ',')
        {
            StringBuilder sb = new StringBuilder();
            Type t = typeof(Car); // Where obj is object whose properties you need.
            PropertyInfo[] pi = t.GetProperties();
            for (int i = 0; i < pi.Length; i++)
            {
                sb.Append(pi[i].Name);
                if (i != pi.Length - 1)
                    sb.Append(separator);
            }
            sb.AppendLine();
            return sb.ToString();
        }
        public static string CreateRow(object o, char separator = ',')
        {
            StringBuilder sb = new StringBuilder();
            Type t = typeof(Car); // Where obj is object whose properties you need.
            PropertyInfo[] pi = t.GetProperties();
            for (int i = 0; i < pi.Length; i++)
            {
                sb.Append(pi[i].GetValue(o));
                if (i != pi.Length - 1)
                    sb.Append(separator);
            }
            return sb.ToString();
        }
}