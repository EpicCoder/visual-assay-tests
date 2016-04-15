using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using test_report.Model;

namespace test_report
{
    public class ExcelReport
    {
        public static FileInfo ExcelFile;
        public static string ScreenshotDir;

        public ExcelReport(string outputDir)
        {
            CreateOutputDir(outputDir);
            ScreenshotDir = outputDir + "\\screenshots";
            CreateScreenshotDir(outputDir + "\\screenshots");
            CreateExcelFile(outputDir + "\\" +
                            DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + "-testResult..xlsx");
        }

        private void CreateExcelFile(string filePath)
        {
            ExcelFile = new FileInfo(filePath);
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet ws =
                    package.Workbook.Worksheets.Add("Test info");
                ws.Cells[1, 1].Value = "Test Group";
                ws.Cells[1, 2].Value = "Test Name";
                ws.Cells[1, 3].Value = "Status";
                ws.Cells[1, 4].Value = "Run Time";
                ws.Cells[1, 5].Value = "Key Step";
                ws.Cells[1, 6].Value = "Additional Info";
                ws.Column(1).Width = 20;
                ws.Column(2).Width = 20;
                ws.Column(3).Width = 20;
                ws.Column(4).Width = 20;
                ws.Column(5).Width = 20;
                ws.Column(6).Width = 20;
                package.SaveAs(ExcelFile);
            }
        }

        public static void WriteToMainSheet(TestModel test)
        {
            using (var package = new ExcelPackage(ExcelReport.ExcelFile))
            {
                ExcelWorksheet ws = package.Workbook.Worksheets["Test info"];
                int lastRow = ws.Dimension.Rows + 1;
                ws.Cells[lastRow, 1].Value = test.TestGroup;
                ws.Cells[lastRow, 2].Value = test.Name;
                ws.Cells[lastRow, 3].Value = test.Status;
                ws.Cells[lastRow, 4].Value = test.RunTime;
                package.Save();
            }
        }



        public static void WriteToGroupSheet(TestModel test)
        {
            using (var package = new ExcelPackage(ExcelReport.ExcelFile))
            {
                ExcelWorksheet ws =
                    package.Workbook.Worksheets.FirstOrDefault(wsheet => wsheet.Name == test.TestGroup);
                if (ws == null)
                {
                    ws = package.Workbook.Worksheets.Add(test.TestGroup);
                    ws.Cells[1, 1].Value = "Test Name";
                    ws.Cells[1, 2].Value = "Timestamp";
                    ws.Cells[1, 3].Value = "Status";
                    ws.Cells[1, 4].Value = "Step";
                    ws.Cells[1, 5].Value = "Additional Info";
                    ws.Column(1).Width = 20;
                    ws.Column(2).Width = 20;
                    ws.Column(3).Width = 20;
                    ws.Column(4).Width = 20;
                    ws.Column(5).Width = 20;
                }
                int lastRow = ws.Dimension.Rows + 1;
                ws.Cells[lastRow, 1].Value = test.Name;
                for (int i = 0; i < test.LogList.Count; i++)
                {
                    var log = test.LogList[i];
                    string timeStamp = String.Format("{0}:{1}:{2}", test.LogList[i].Timestamp.Hour,
                        test.LogList[i].Timestamp.Minute, test.LogList[i].Timestamp.Second);
                    ws.Cells[lastRow + i, 2].Value = timeStamp;
                    ws.Cells[lastRow + i, 3].Value = log.LogStatus;
                    ws.Cells[lastRow + i, 4].Value = log.StepName;
                    if (!String.IsNullOrEmpty(log.AdditionalInfo))
                    {
                        var currentFile = "CELL(\"filename\")";
                        var pathToFolder =
                            "LEFT(" + currentFile + ",FIND(\"|\",SUBSTITUTE(" + currentFile + ",\"\\\",\"|\",LEN(" +
                            currentFile + ")-LEN(SUBSTITUTE(" + currentFile + ",\"\\\",\"\")))))";
                        var relativePath = "HYPERLINK(" + pathToFolder + " & \"" + log.AdditionalInfo + "\",\"Link to File\")";
                        ws.Cells[lastRow + i, 5].Formula = relativePath;
                    }
                }
                package.Save();
            }
        }

        public void CreateOutputDir(string path)
        {
            Directory.CreateDirectory(path);
        }

        public void CreateScreenshotDir(string screenDir)
        {
            Directory.CreateDirectory(screenDir);
        }
    }
}
