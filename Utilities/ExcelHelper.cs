using ClosedXML.Excel;
using System.IO;

namespace Lab8.Utilities
{
    public class ExcelHelper
    {
        static string filePath = "TestReport.xlsx";

        public static void WriteResult(string testName, string status, string screenshotPath)
        {
            XLWorkbook workbook;

            if (File.Exists(filePath))
                workbook = new XLWorkbook(filePath);
            else
                workbook = new XLWorkbook();

            var sheet = workbook.Worksheets.Count > 0
                ? workbook.Worksheet(1)
                : workbook.AddWorksheet("Results");

            int row = sheet.LastRowUsed()?.RowNumber() + 1 ?? 1;

            sheet.Cell(row, 1).Value = testName;
            sheet.Cell(row, 2).Value = status;
            sheet.Cell(row, 3).Value = screenshotPath;

            workbook.SaveAs(filePath);
        }
    }
}