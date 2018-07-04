using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pro100DoOptimika
{
    /// <summary>
    /// Interaction logic for ConversionWindow.xaml
    /// </summary>
    public partial class ConversionWindow : Window
    {
        public ConversionProcess ConversionProcess;

        /// <summary>
        /// Used to carry out conversion, allow user to make changes during the process, and choose path for saving files.
        /// </summary>
        public ConversionWindow(ConversionProcess conversionProcess)
        {
            // at this point the preprocessed file is only loaded
            InitializeComponent();
            ConversionProcess = conversionProcess;

            // here data is being sorted by product.    
            ConversionProcess.AnalyzePreConversionFile();

            // todo: replace with actual listview preview of products with their components
            ProductName1.Text = ConversionProcess.Products[0].Name;
            Number1.Text = ConversionProcess.Products[0].Number.ToString();
            Symbol1.Text = ConversionProcess.Products[0].Symbol;

            ProductName2.Text = ConversionProcess.Products[1].Name;
            Number2.Text = ConversionProcess.Products[1].Number.ToString();
            Symbol2.Text = ConversionProcess.Products[1].Symbol;
        }

        /// <summary>
        /// Browser used to to choose destination folder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Browse_Click(object sender, RoutedEventArgs e)
        {
            // opens a folder browser for user to pick a file to convert.
            FolderBrowserDialog ofd = new FolderBrowserDialog();

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // shows the path to file
                pathToDestinationFolder.Text = ofd.SelectedPath;
            }
        }

        /// <summary>
        /// User decides whether he needs the info formatted as order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ConversionProcess.SaveAsOrder = true;
        }

        /// <summary>
        /// User decides whether he needs the info formatted as individual products to be added to database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ConversionProcess.SaveAsProducts = true;
        }

        /// <summary>
        /// Saves the formated info to folder choosen by user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton(object sender, RoutedEventArgs e)
        {
            ConversionProcess.DestinationPath = pathToDestinationFolder.Text;
            if (ConversionProcess.DestinationPath == "")
            {
                System.Windows.MessageBox.Show("Nie wybrano pliku do konwersji.");
            }
            else
            {
                ConversionProcess.SaveFiles();
                this.Close();
            }
        }
    }
}
