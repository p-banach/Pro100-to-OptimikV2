using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro100DoOptimika
{
    /// <summary>
    /// Holds information about a single component of a product. 
    /// Component may be either a piece of veneer, wood, ar an accessory.
    /// </summary>
    public class ProductComponent
    {
        public ProductComponent()
        {
        }

        /// <summary>
        /// First two fields are relative to each import.
        /// </summary>
        public String Name { get; set; }
        public String Code { get; set; }

        /// <summary>
        /// This field holds material code from Optimik's db. E.g. "płyta laminat 16 kronopol biała U511 SM".
        /// </summary>
        public String Material { get; set; }


        public int Amount { get; set; }

        /// <summary>
        /// Those are stored in mm.
        /// </summary>
        public int Length { get; set; }
        public int Width { get; set; }

        public String TempStripA { get; set; }
        public String TempStripB { get; set; }
        public String TempStripC { get; set; }
        public String TempStripD { get; set; }

        public EdgingStrip EStripA { get; set; }
        public EdgingStrip EStripB { get; set; }
        public EdgingStrip EStripC { get; set; }
        public EdgingStrip EStripD { get; set; }

        /// <summary>
        /// Edges with edging strip on them might need to be longer.
        /// </summary>
        public Double SurplusOnEdgesWithStrip { get; set; }

        /// <summary>
        /// Holds CNC command code.
        /// </summary>
        public String CNCCommand { get; set; }

        /// <summary>
        /// Holds material code in case of veneer items, and actual code in case of accesories.
        /// </summary>
        public String StorageItemCode { get; set; }

        /// <summary>
        /// Selects correct column from the data lane to save the name.
        /// </summary>
        /// <param name="data">Corresponding data row</param>
        public void FindComponentName(String[] data)
        {
            // That's just what it's set up like right now in Pro100 export settings.
            this.Name = data[4];
        }

        /// <summary>
        /// Selects correct column from the data lane to save the material.
        /// </summary>
        /// <param name="data">Corresponding data row</param>
        public void FindComponentMaterial(String[] data)
        {
            // That's just what it's set up like right now in Pro100 export settings.
            this.Material = data[1];
        }

        /// <summary>
        /// Selects correct column from the data lane to save the amount.
        /// </summary>
        /// <param name="data">Corresponding data row</param>
        public void FindComponentAmount(String[] data)
        {
            // That's just what it's set up like right now in Pro100 export settings.
            this.Amount = int.Parse(data[5]);
        }

        /// <summary>
        /// Selects correct column from the data lane to save the length and width.
        /// </summary>
        /// <param name="data">Corresponding data row</param>
        public void FindComponentLengthAndWidth(String[] data)
        {
            // That's just what it's set up like right now in Pro100 export settings.
            // also, pro100 exports data in cm, Optimik accepts it in mm.
            this.Length = int.Parse(data[7])*100;
            this.Width = int.Parse(data[8]) * 100;
        }

        /// <summary>
        /// Selects correct column from the data lane to save edging strips item code.
        /// </summary>
        /// <param name="data">Corresponding data row</param>
        public void FindComponentEdgingStripsAndSurplus(String[] data)
        {   
            // That's just what it's set up like right now in Pro100 export settings.
            // also, pro100 exports data in cm, Optimik accepts it in mm.
            this.TempStripA = data[9];
            this.TempStripB = data[12];
            this.TempStripC = data[15];
            this.TempStripD = data[18];

            // hardcoding surplus for now.
            this.SurplusOnEdgesWithStrip = 0.8;
        }

        /// <summary>
        /// Selects correct column from the data lane to save cnc setup code.
        /// </summary>
        /// <param name="data">Corresponding data row</param>
        public void FindComponentCNCCode(String[] data)
        {
            this.CNCCommand = this.Code;
        }


        /// <summary>
        /// Finds first letters of component name, and saves them in format of productCode_FIRSTLETTERSOFCOMPONENTNAME.
        /// </summary>
        /// <param name="data">Corresponding data row</param>
        public void FindComponentCode(String productSymbol)
        {
            // saving product code at first
            this.Code = productSymbol;

            // selecting first letter of every word
            string str = new string(this.Name.Split(' ') .Select(x => x.First()).ToArray());

            // adding first letters in uppercase
            this.Code += str.ToUpper();
            // might need this for later.
            //str.Split(' ').ToList().ForEach(i => this.Code += (i[0] + " "));
        }


    }
}
