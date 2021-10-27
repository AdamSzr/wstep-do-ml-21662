namespace CSharp_Utils
{
    using System.IO;
    using Newtonsoft.Json;
    class DataWriter
    {
        FileInfo dataFile;
        private bool FileExists { get => this.dataFile.Exists; }
        public DataWriter(FileInfo dataFile)
        {
            this.dataFile = dataFile;
        }

        public void Write(byte[] data)
        {
            using (FileStream fs = dataFile.Create())
            {
                fs.Write(data);
            }
        }

        public void Write(string data)
        {
            this.Write(data.ConvertToByteArray());
        }


        public void Append(string data)
        {
            if (dataFile.Exists)
            {
                File.AppendAllText(this.dataFile.FullName, data);
            }
            else
            {
                throw new FileNotFoundException("Cannot append to the file that not exists.");
            }

        }
    }
}