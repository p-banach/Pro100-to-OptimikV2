using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro100DoOptimika
{
    /// <summary>
    /// Used to hold file contents before they're processed.
    /// </summary>
    public class FileContentsPreConversion
    {
        /// <summary>
        /// Info is stored in rows, as it comes from a .csv file.
        /// </summary>
        public List<DataRow> DataRows { get; set; }

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public FileContentsPreConversion()
        {
            DataRows = new List<DataRow>();
        }

        /// <summary>
        /// Loads file, and returns Enumerable collection to be displayed. 
        /// </summary>
        /// <param name="pathToFile"></param>
        /// <returns></returns>
        public IEnumerable<DataRow> LoadFile(string pathToFile)
        {
            string[] ConversionFileContents = System.IO.File.ReadAllLines(pathToFile, Encoding.GetEncoding(1250));

            return ConversionFileContents.Select(line =>
            {
                string[] data = line.Split(';');

                DataRows.Add(new DataRow(data));

                return DataRows.LastOrDefault();
            });
        }
    }
}
