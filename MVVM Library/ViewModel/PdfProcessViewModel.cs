using Microsoft.Win32;
using MVVM_Library.NotifyProperty;
using PDF_Converter_V_1._0.Command;
using PDF_Converter_V_1._0.Model;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace PDF_Converter_V_1._0.ViewModel
{
    public class PdfProcessViewModel : ObjectPropertyNotifier
    {
        public ICommand ConvertBtnCommand { get; set; }
        public ICommand BrowseBtnCommand { get; set; }

        private string _inputPath;
        
        public string InputPath {
            get 
            {
                if(string.IsNullOrEmpty(_inputPath))
                {
                    return "File Path";
                }
                return _inputPath;
            }
            set 
            {
                _inputPath = value;
                OnPropertyChanged("InputPath");
            } 
        }

        public Visibility ProgressBarVisibility
        {
            get
            {
                return (DownloadPercentage == 100) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private int mDownloadPercentage;
        public int DownloadPercentage
        {
            get { return mDownloadPercentage; }
            set
            {
                if (mDownloadPercentage == value)
                {
                    return;
                }
                else
                {
                    mDownloadPercentage = Math.Min(Math.Abs(value), 100);
                    OnPropertyChanged("DownloadPercentage");
                    OnPropertyChanged("ProgressBarVisibility");
                }
            }
        }

        public string OutputPath { get; set; }


        public PdfProcessViewModel()
        {
            ConvertBtnCommand = new RelayCommand(ConvertPDFCommand);
            BrowseBtnCommand = new RelayCommand(BrowseDocCommand);
        }

        public void ConvertPDFCommand(object parameter)
        {
            DownloadPercentage = 100;
            try
            {                
                PdfProcessModel pdfProcessModel = new PdfProcessModel();                
                OutputPath = pdfProcessModel.FileNameProcessing(InputPath);
                pdfProcessModel.ConvertPDF(InputPath, OutputPath);
                DownloadPercentage = 0;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("File is not word document or file is currupted", "PDF Converter App", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void BrowseDocCommand(object parameter)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                var File = openFileDialog.ShowDialog();

                if (File == true)
                {
                    InputPath = openFileDialog.FileName;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Error is file selections.", "PDF Converter App" , MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
