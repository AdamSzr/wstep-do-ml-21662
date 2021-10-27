using System;
using Newtonsoft.Json;
using System.IO;
using CSharp_Utils;
using System.Reflection;

// należy przygotować dane, które będą zapisywane do plików; oprócz tekstowych potrzebne będą jeszcze dane w formacie JSON i CSV; wszystkie dane tworzymy za pomocą kodu!
// odczyt pliku (poprawne otwarcie i zamknięcie) oraz wyświetlenie informacji w nim zawartej (jedna linia i wiele linii),
// napisz program, który zlicza liczbę wierszy tekstu w pliku i wyświetla tę informację,
// zapisywanie danych do pliku w różnych trybach,
// zapisywanie danych do pliku w formanie JSON,
// zapisywanie danych do pliku w formanie CSV (proszę pamietać o właściwych rozszerzeniach plików!),
// zapisz pliki wynikowe w folderze 'Lab2' i umieść go w repozytorium ♥.

DirectoryInfo outputFileDir = Directory.CreateDirectory("Lab2_Output");


string txtData = StringUtils.RandomString(600);
Console.WriteLine(txtData);
File.OpenWrite(outputFileDir.FullName + "/randomstring.txt").Write(txtData.ConvertToByteArray());
Car c = new();
c.Weight=200;
c.DoorsCount=5;
c.Length=300;


CsvFormat csv = CsvFormat.With(StringUtils.CreateCSVHeader(c));
csv.AddDataRow(StringUtils.CreateCSVRow(c));


Console.WriteLine(csv.ToString());
Console.WriteLine(JsonConvert.SerializeObject(c));