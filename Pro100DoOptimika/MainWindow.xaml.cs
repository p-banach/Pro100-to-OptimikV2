using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Pro100DoOptimika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.pathToFile.Text = ofd.FileName;
            }
        }

        public void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (this.pathToFile.Text == "")
            {
                System.Windows.MessageBox.Show("Nie wybrano pliku do konwersji.");
            }
            else
            {
                System.Windows.MessageBox.Show("Rozpoczynam konwersję.");
                Conversion conversion = new Conversion();
                FileContentsBox.Text = pathToFile.Text;

                conversion.StartConversion(pathToFile.Text);
                FileContentsBox.Text = string.Join("\n", conversion.FileContents);
            }
        }


    }


}
