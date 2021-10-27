using System;
using Newtonsoft.Json;
using System.IO;
using CSharp_Utils;
using System.Reflection;
using System.Collections.Generic;

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
}