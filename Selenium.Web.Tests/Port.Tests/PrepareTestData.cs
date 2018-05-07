using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using OfficeOpenXml;

namespace Test_Project.LST.Tests
{
    [TestClass]
    public class PrepareTestData
    {
        private string testDataPath = @"C:\TestData\LST\";
        [TestMethod]
        public void PrepareConstraintsTestData()
        {
            string rakeNumber = "";
            string nomination = "";
            string stockpile = "";

            string testDataFile = this.testDataPath + @"Constraints_TestData.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    if (workSheet.Cells[2, 1].Value != null)
                    {
                        rakeNumber = workSheet.Cells[2, 1].Value.ToString();
                    }

                    if (workSheet.Cells[2, 2].Value != null)
                    {
                        nomination = workSheet.Cells[2, 2].Value.ToString();
                    }

                    if (workSheet.Cells[2, 3].Value != null)
                    {
                        stockpile = workSheet.Cells[2, 3].Value.ToString();
                    }
                }
            }

            string[] rakeTestDataFiles = Directory.GetFiles(this.testDataPath, "*Rake*");
            foreach (string file in rakeTestDataFiles)
            {
                var excelFile = new FileInfo(file);

                using (ExcelPackage package = new ExcelPackage(excelFile))
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    workSheet.Cells[2, 1].Value = rakeNumber;

                    package.Save();
                    package.Dispose();
                }

            }

            string[] nominationTestDataFiles = Directory.GetFiles(this.testDataPath, "*Nomination*");
            foreach (string file in nominationTestDataFiles)
            {
                var excelFile = new FileInfo(file);

                using (ExcelPackage package = new ExcelPackage(excelFile))
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    workSheet.Cells[2, 1].Value = nomination;

                    package.Save();
                    package.Dispose();
                }

            }

            string[] stockpileTestDataFiles = Directory.GetFiles(this.testDataPath, "*Stockpile*");
            foreach (string file in stockpileTestDataFiles)
            {
                var excelFile = new FileInfo(file);

                using (ExcelPackage package = new ExcelPackage(excelFile))
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    workSheet.Cells[2, 1].Value = stockpile;

                    package.Save();
                    package.Dispose();
                }

            }
        }

    }
}
