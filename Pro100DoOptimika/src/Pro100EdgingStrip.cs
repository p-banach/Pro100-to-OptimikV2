using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro100DoOptimika
{
    public class EdgingStrip
    {
        public EdgingStrip(string code, string name, int type, string storageItemCode, double size)
        {
            Code = code;
            Name = name;
            Type = type;
            StorageItemCode = storageItemCode;
            Size = size;
        }

        public String Code { get; set; }
        public String Name { get; set; }

        /// <summary>
        /// Check out Optimik's manual for Types reference. In general values from -1 to 5.
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Code of actual product in Optimik's database. E.g Code might be "OB1", short for EdgingStrip1, while StorageItemCode is "ABS 0,8/22-U511 SM #16mm"
        /// </summary>
        public String StorageItemCode { get; set; }

        public Double Size { get; set; }
    }
}
