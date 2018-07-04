﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro100DoOptimika
{
    /// <summary>
    /// Holds all information about a single product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Preprocessed info marked with this product's index get assigned there.
        /// </summary>
        public List<String[]> PreprocessedInfo { get; set; }

        /// <summary>
        /// Pretty self-explanatory.
        /// </summary>
        public String Symbol { get; set; }
        public String Name { get; set; }

        public int Number { get; set; }

        /// <summary>
        /// Number is always needed to initialize a product.
        /// </summary>
        /// <param name="number"></param>
        public Product(int number)
        {
            Number = number;
            PreprocessedInfo = new List<String[]>();
        }

        /// <summary>
        /// Extracts product's symbol from assigned data.
        /// </summary>
        public void FindProductSymbol()
        {
            // first, program looks for first data row, in which the first column contains '-' char.
            // it's the pre-estabilished mark for product code.
            int index = 0;
            while (this.PreprocessedInfo[index++][0].LastIndexOf('-') == -1) ;
           
            // creating a temp var for convenience
            String temp = this.PreprocessedInfo[index - 1][0];
            int dashIndex = temp.LastIndexOf('-');
            int floorIndex = temp.LastIndexOf('_');

            Symbol = PreprocessedInfo[--index][0].Substring(dashIndex+1, floorIndex - (dashIndex + 1));
        }

        /// <summary>
        /// Extracts product's name from assigned data.
        /// </summary>
        public void FindProductName()
        {
            // first, program looks for first data row, in which the first column contains '~' char.
            // it's the pre-estabilished mark for product name.
            int index = 0;
            while (this.PreprocessedInfo[index++][0].IndexOf('~') == -1) ;

            // creating a temp var for convenience
            String temp = this.PreprocessedInfo[index - 1][0];
            int tildeIndex = temp.LastIndexOf('~');

            Name = PreprocessedInfo[--index][0].Substring(tildeIndex+1);
        }
    }
}
