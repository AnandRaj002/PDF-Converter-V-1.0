using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Word;
using Path = System.IO.Path;

namespace PDF_Converter_V_1._0.Model
{
    public class PdfProcessModel
    {
        Application WordApp = new Application();

        public string FileNameProcessing(string inputFile)
        {
            try
            {
                var namePdf = String.Format("{0}.pdf", Path.GetFileNameWithoutExtension(inputFile));
                return Path.Combine(Path.GetDirectoryName(inputFile), namePdf);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void ConvertPDF(string inputFile, string outputFile)
        {
            try
            {
                var wordDoc = WordApp.Documents.Open(inputFile);
                wordDoc.ExportAsFixedFormat(outputFile, WdExportFormat.wdExportFormatPDF, true);
                wordDoc.Close();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
