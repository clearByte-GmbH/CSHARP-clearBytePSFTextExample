using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace clearBytePSFTextExample
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

        private void BtnReadTxt_Click(object sender, RoutedEventArgs e)
        {
            /// MSIX Works string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)}\\ClearbyteMSIXSample\\test.txt";
            string path = $"{Environment.CurrentDirectory}\\PSFExample.txt";
            FilePath.Text = path;
            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                TxtInput.Text = content;
            }
            else
            {
                FilePath.Text = "Datei fehlt";
            }

        }

        private void BtnWriteTxt_Click(object sender, RoutedEventArgs e)
        {
            FilePath.Text = "";
            string path = $"{Environment.CurrentDirectory}\\PSFExample.txt";
            try
            {
                string createText = TxtInput.Text + " " + DateTime.Now.ToString("dd.MM.yyyy_HH:mm:ss");
                File.WriteAllText(path, createText);
                MessageBox.Show("Text konnte geschrieben werden ", "clearBytePSFTextExsample");
            }
            catch (Exception ex)
            {
                string[] trace = ex.StackTrace.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                string msg = ex.Message + Environment.NewLine + trace[0];
                MessageBox.Show(msg, "Unexpected error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }
    }
}
