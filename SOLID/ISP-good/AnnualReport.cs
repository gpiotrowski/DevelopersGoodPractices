using System;

namespace ISP_good
{
    public class AnnualReport : IExportableToWord, IExportableToPdf
    {
        public void ExportToPdf()
        {
            Console.WriteLine("Exporting to PDF...");
        }

        public void ExportToWord()
        {
            Console.WriteLine("Exporting to Word...");
        }
    }
}
