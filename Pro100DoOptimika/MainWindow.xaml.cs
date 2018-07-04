using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Pro100DoOptimika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        ConversionProcess ConversionProcess;

        /// <summary>
        /// Used to chose file to convert, preview it's contents, and start conversion process.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            ConversionProcess = new ConversionProcess();
        }

        /// <summary>
        /// Browser used to to choose file to convert.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Browse_Click(object sender, RoutedEventArgs e)
        {
            // opens a folder browser for user to pick a file to convert.
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // shows the path to file
                PathToLoadedFileBox.Text = ofd.FileName;

                // loads pre-conversion file info
                PreconversionFilePreviewBox.ItemsSource = ConversionProcess.FileContentsPreConversion.LoadFile(PathToLoadedFileBox.Text);
            }
        }

        /// <summary>
        /// Starts conversion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void Convert_Click(object sender, RoutedEventArgs e)
        {
            if (PathToLoadedFileBox.Text == "")
            {
                System.Windows.MessageBox.Show("Nie wybrano pliku do konwersji.");
            }
            else
            {
                ConversionWindow conversionWindow = new ConversionWindow(ConversionProcess);
                conversionWindow.Show();
            }
        }
    }
}
