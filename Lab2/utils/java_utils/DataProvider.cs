namespace CSharp_Utils
{
    using System.IO;
    using Newtonsoft.Json;
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



    }
}