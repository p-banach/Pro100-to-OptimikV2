using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pro100DoOptimika
{
    class Conversion
    {

        public Conversion()
        {
        }

        public string[] FileContents { get; set; }


        public void StartConversion(string pathToFile)
        {
            FileContents = System.IO.File.ReadAllLines(pathToFile, Encoding.GetEncoding(1250));
        }
    }
}
