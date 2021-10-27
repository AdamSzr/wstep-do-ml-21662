namespace CSharp_Utils
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text;
    public class CharUtils
    {
        System.Random random = new System.Random();
        public char RandomUpperChar()
        {
            return (char)random.Next(65, 90 + 1);
        }

        public char RandomLowwerChar()
        {
            return (char)random.Next(97, 122 + 1);
        }

        public char RandomNumberChar()
        {
            return (char)random.Next(48, 57 + 1);
        }
    }
}