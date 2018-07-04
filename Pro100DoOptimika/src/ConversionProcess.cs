using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pro100DoOptimika
{
    /// <summary>
    /// Holds all information needed to carry out conversion.
    /// </summary>
    public class ConversionProcess
    {
        /// <summary>
        /// Data from file is loaded into FileContentsPreConversion as is.
        /// </summary>
        public FileContentsPreConversion FileContentsPreConversion { get; set; }

        /// <summary>
        /// A list of all products found in file. 
        /// Product numbers are not identical to indexes!
        /// </summary>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Information about whether to save Products info into files 
        /// prepared for either import as products, or to load them as an order.
        /// </summary>
        public bool SaveAsProducts { get; set; }
        public bool SaveAsOrder { get; set; }

        /// <summary>
        /// Destination path for output files.
        /// </summary>
        public string DestinationPath { get; set; }

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public ConversionProcess()
        {
            Products = new List<Product>();
            FileContentsPreConversion = new FileContentsPreConversion();
            SaveAsProducts = false;
            SaveAsOrder = false;
        }

        /// <summary>
        /// Carries out all data processing necessery to print out
        /// files accepted by Optimik software.
        /// </summary>
        public void AnalyzePreConversionFile()
        {
            // assigning rows of data to products
            SortRowsByProduct();

            //finding correct product symbol and name in assigned data
            foreach(Product prod in Products)
            {
                prod.FindProductSymbol();
                prod.FindProductName();
            }
        }

        /// <summary>
        /// todo : get component info
        /// </summary>
        public void AnalyzeProductsData()
        {

        }

        /// <summary>
        /// After transforming data, this function saves it (will do so)
        /// to requested files.
        /// </summary>
        public void SaveFiles()
        {

        }

        /// <summary>
        /// Decides which product's info is stored in all rows of preprocessed file
        /// (info is randomized, for whatever reason).
        /// </summary>
        private void SortRowsByProduct()
        {
            foreach(DataRow row in FileContentsPreConversion.DataRows)
            {
                // extracting product number from the data row
                int productNumber = FindProductNumber(row.Data[0]);

                // skip the line if it doesn't exist
                if (productNumber == -1)
                    break;

                // looking for product with number that was found in the list of products
                int productIndexInList = Products.FindIndex(x => x.Number == productNumber);

                if(productIndexInList >= 0)
                {
                    // simply adding another row of info
                    Products[productIndexInList].PreprocessedInfo.Add(row.Data);
                }
                else
                {
                    // creating a new produc and adding first line of info
                    Product newProduct = new Product(productNumber);
                    newProduct.PreprocessedInfo.Add(row.Data);
                    Products.Add(newProduct);
                }
            }

        }

        /// <summary>
        /// Finding product number is carried out here,
        /// and not in Product class, because it's
        /// necessery to decide whether the line belongs
        /// to new, or already existing product.
        /// </summary>
        /// <param name="line"> Self-explanatory.</param>
        /// <returns>Found number ( n>=0) or -1 if none was found.</returns>
        private int FindProductNumber(string line)
        {
            int ret = -1;

            int idx = line.LastIndexOf('~');
            if (idx != -1)
            {
                try { 
                ret = int.Parse(line.Substring(0, idx));
                }
                catch (System.FormatException)
                {
                }
            }

            return ret;
        }
    }
}
