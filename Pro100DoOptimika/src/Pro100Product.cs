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

        public List<ProductComponent> ComponentsList { get; set; }

        /// <summary>
        /// Holds all possible Edging Strips for Product.
        /// String part holds the name of the edging strip.
        /// Just for convenience, so it's easier to avoid duplicates.
        /// </summary>
        public Dictionary<String, EdgingStrip> EdgingStripsList { get; set; }

        /// <summary>
        /// Number is always needed to initialize a product.
        /// </summary>
        /// <param name="number"></param>
        public Product(int number)
        {
            Number = number;
            PreprocessedInfo = new List<String[]>();
            ComponentsList = new List<ProductComponent>();
            EdgingStripsList = new Dictionary<String, EdgingStrip>();
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

        /// <summary>
        /// Checks all product components for existing edging strips,
        /// and creats correspoding instances of EdgingStrip class.
        /// </summary>
        public void PrepareEdgingStripsList()
        {
            int edgingStripsCount = 1;
            foreach(ProductComponent component in ComponentsList)
            {
                if (!String.IsNullOrEmpty(component.EdgingStripStorageNameA))
                {
                    EdgingStrip newStrip = new EdgingStrip("OB" + edgingStripsCount, "Obrzeże " + edgingStripsCount, 3, component.EdgingStripStorageNameA, 0.8);
                    EdgingStripsList[component.EdgingStripStorageNameA] = newStrip;
                    edgingStripsCount++;
                }

                if (!String.IsNullOrEmpty(component.EdgingStripStorageNameB))
                {
                    EdgingStrip newStrip = new EdgingStrip("OB" + edgingStripsCount, "Obrzeże " + edgingStripsCount, 3, component.EdgingStripStorageNameB, 0.8);
                    EdgingStripsList[component.EdgingStripStorageNameB] = newStrip;
                    edgingStripsCount++;
                }

                if (!String.IsNullOrEmpty(component.EdgingStripStorageNameC))
                {
                    EdgingStrip newStrip = new EdgingStrip("OB" + edgingStripsCount, "Obrzeże " + edgingStripsCount, 3, component.EdgingStripStorageNameC,0.8);
                    EdgingStripsList[component.EdgingStripStorageNameC] = newStrip;
                    edgingStripsCount++;
                }

                if (!String.IsNullOrEmpty(component.EdgingStripStorageNameD)
                {
                    EdgingStrip newStrip = new EdgingStrip("OB" + edgingStripsCount, "Obrzeże " + edgingStripsCount, 3, component.EdgingStripStorageNameD, 0.8);
                    edgingStripsCount++;
                    EdgingStripsList[component.EdgingStripStorageNameD] = newStrip;
                }
            }
        }

        /// <summary>
        /// Goes through preprocessed info and extracts Component info and existing EdgingStrips.
        /// </summary>
        public void SortIntoComponents()
        {
            foreach(string[] data in PreprocessedInfo)
            {
                ProductComponent component = new ProductComponent();
                component.FindComponentName(data);
                component.FindComponentMaterial(data);
                component.FindComponentAmount(data);
                component.FindComponentLengthAndWidth(data);
                component.FindComponentEdgingStripsAndSurplus(data);
                component.FindComponentCNCCode(data);
                component.FindComponentCode(this.Symbol);
            }
        }
    }
}
