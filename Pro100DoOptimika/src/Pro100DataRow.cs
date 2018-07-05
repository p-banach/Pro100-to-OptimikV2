using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro100DoOptimika
{
    /// <summary>
    /// Stores a single row of data from .csv file, divided by column.
    /// </summary>
    public class DataRow
    {
        public String[] Data { get; set; }

        public DataRow(String[] data)
        {
            this.Data = data;
        }
    }
}
