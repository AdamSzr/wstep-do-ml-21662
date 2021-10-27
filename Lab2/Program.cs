using System;
using Newtonsoft.Json;
using System.IO;
using CSharp_Utils;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// =========================== Setup ====================================
DirectoryInfo outputFileDir = Directory.CreateDirectory("Lab2_Output");
string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

FileInfo txtFile = new FileInfo(outputFileDir + "/textfile.txt");
FileInfo csvFile = new FileInfo(outputFileDir + "/commaSepVal.csv");
FileInfo jsonFile = new FileInfo(outputFileDir + "/jsObjectNotation.json");
List<Car> cars = new List<Car>();
for (int i = 0; i < 150; i++)
{
    cars.Add(Car.Random());
}
// ======================================================================

// =========================== Data Creation ====================================


// należy przygotować dane, które będą zapisywane do plików; oprócz tekstowych potrzebne będą jeszcze dane w formacie JSON i CSV; 
// wszystkie dane tworzymy za pomocą kodu!
{
    DataWriter dw = new DataWriter(txtFile);
    StringBuilder sb = new();
    for (int i = 0; i < 100; i++)
    {
        sb.Append(i + " - " + new String(lorem.Take(80).ToArray()));
        if (i != 99)
            sb.AppendLine(); // nie dodawaj ostatniej lini ponieważ będzie 101 wierszy - ostatni pusty
    }
    var data = sb.ToString();
    dw.Write(data.ConvertToByteArray());
    Console.WriteLine("Created " + txtFile.Name);
}

{
    CsvFormat csv = CsvFormat.With(CsvFormat.CreateHeader(new Car()));
    foreach (var car in cars)
    {
        csv.AddDataRow(CsvFormat.CreateRow(car));
    }
    csv.Save(csvFile);
    Console.WriteLine("Created " + csvFile.Name);
}

{
    DataWriter dw = new(jsonFile);
    dw.Write(JsonConvert.SerializeObject(cars).ConvertToByteArray());
    Console.WriteLine("Created " + jsonFile.Name);
}

if (jsonFile.Exists && csvFile.Exists && txtFile.Exists)
    Console.WriteLine("DATA-SET HAS BEEN CREATED");

// ======================================================================
// odczyt pliku (poprawne otwarcie i zamknięcie) oraz wyświetlenie informacji w nim zawartej (jedna linia i wiele linii),

DataProvider dp = new(txtFile);
var x = dp.ReadLines(3, 10);
Console.WriteLine("Readed " + x.Length + " lines from file " + txtFile.Name + "\r\nThere is result ");
foreach (var item in x)
{
    Console.WriteLine(item);
}


Console.WriteLine("Line  " + 30 + " from file " + txtFile.Name + " is");
Console.WriteLine(dp.ReadLine(30));

// =====================================================================
// zapisywanie danych do pliku w różnych trybach,
Car toAppend = Car.Random();
DataWriter csvDW = new(csvFile);
csvDW.Append("\r\n" + CsvFormat.CreateRow(toAppend));

Console.WriteLine("Added new car to csv file.");
Console.WriteLine("Is last car from file equal to expected -> " + CsvFormat.CreateRow(toAppend) == new DataProvider(csvFile).ReadLine(1 + 150 + 1));

// =====================================================================
// napisz program, który zlicza liczbę wierszy tekstu w pliku i wyświetla tę informację,

Console.WriteLine(txtFile.Name + " have " + txtFile.OpenText().ReadToEnd().Split(Environment.NewLine).Count() + " lines of text");

// =====================================================================
// zapisywanie danych do pliku w formanie JSON,
// zapisywanie danych do pliku w formanie CSV (proszę pamietać o właściwych rozszerzeniach plików!),
// zapisywanie w formacie JSON oraz CSV odbywa się podczas przygotowywania plików z danymi
Console.WriteLine("Zapisywanie w formacie JSON oraz CSV odbywa się podczas przygotowyania plików z danymi");
