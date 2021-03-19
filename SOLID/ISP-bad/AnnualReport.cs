using System;

namespace ISP_bad
{
    public class AnnualReport : IExportable
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
