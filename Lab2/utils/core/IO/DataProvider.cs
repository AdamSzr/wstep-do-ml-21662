namespace CSharp_Utils
{
    using System.IO;
    using Newtonsoft.Json;
    using System.Linq;
    class DataProvider
    {
        FileInfo dataFile;
        private bool FileExists { get => this.dataFile.Exists; }
        public DataProvider(FileInfo dataFile)
        {
            this.dataFile = dataFile;
        }

        public byte[] ReadFile()
        {
            if (!FileExists)
                throw new FileNotFoundException("Provided FileInfo isn't correct.");

            byte[] fileByteArray = new byte[this.dataFile.Length];

            this.dataFile.OpenRead().Read(fileByteArray, 0, fileByteArray.Length);
            return fileByteArray;
        }

        public string ReadFileAsString()
        {
            return ReadFile().ConvertToString();
        }

        public object ReadAsJson()
        {
            return JsonConvert.DeserializeObject(ReadFileAsString());
        }

        public string[] ReadLines(int count)
        {
            string[] d = new string[count];
            using (StreamReader sr = dataFile.OpenText())
            {
                for (int i = 0; i < count; i++)
                {
                    string line = sr.ReadLine();
                    if (line != null)
                        d[i] = line;
                    else
                        break;
                }
            }
            return d;
        }

        public string[] ReadLines(int first, int count)
        {
            return File.ReadAllLines(dataFile.FullName).Skip(first).Take(count).ToArray();
        }

        public string ReadLine(int lineNumber)
        {
            using (StreamReader sr = dataFile.OpenText())
            {
                for (int i = 0; i < lineNumber; i++)
                {
                    string line = sr.ReadLine();
                    if (line == null)
                        throw new System.Exception("Cannot read line because file has ended.");
                }
                return sr.ReadLine();
            }
        }

    }
}