using Microsoft.Win32;
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
using PDF_Converter_V_1._0.ViewModel;

namespace PDF_Converter_V_1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string inputFile;
        public string outputFile;        
        

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new PdfProcessViewModel();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{            
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    var File = openFileDialog.ShowDialog();

        //    if(File == true)
        //    {
        //        inputFile = openFileDialog.FileName;
        //        FileName.Text = inputFile;                
        //    }
        //}

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(inputFile))
        //    {
        //        //Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application();
        //        //outputFile = docToPdfProcessor.FileNameProcessing(inputFile);
        //        //docToPdfProcessor.ConvertPDF(inputFile, outputFile);
        //        //var wordDoc = WordApp.Documents.Open(inputFile);
        //        //wordDoc.ExportAsFixedFormat(outputFile, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF, true);
        //        Console.WriteLine(inputFile);
        //    }
            
        //}
    }
}
