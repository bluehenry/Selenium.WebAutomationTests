using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace Selenium.WebTest.Framework.Support.Excel
{
    public static class ExcelHelper
    {
        //Caculate Column Number, like A is 1, AA is 27
        public static int GetColumnNumber(string name)
        {
            int number = 0;
            int pow = 1;
            for (int i = name.Length - 1; i >= 0; i--)
            {
                number += (name[i] - 'A' + 1) * pow;
                pow *= 26;
            }

            return number;
        }

        public static int GetLastRowNumberInSheet(ExcelWorksheet workSheet, int columnNumber, int startRow = 1)
        {
            int currentRow = startRow;
            string str = "";

            while (workSheet.Cells[currentRow, columnNumber].Value != null)
            {
                str = workSheet.Cells[currentRow, columnNumber].Value.ToString();
                if (str == string.Empty)
                    break;

                currentRow++;
            }

            return (currentRow - 1);

        }

        //Get last non empty row number
        public static int GetLastRowNumber(string excelFilePath, string sheetName, int columnNumber, int startRow = 1)
        {
            int rowNumber;

            using (FileStream stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            { 
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];
                    rowNumber = GetLastRowNumberInSheet(workSheet, columnNumber, startRow);
                }
            }
            return rowNumber;
        }


        //Read KeyValuePair from a Excel file, it can be used as getting parameters and values
        //By default key columan name is "A", value column is "B" and KeyValuePair are from the second row. 
        public static List<KeyValuePair<string, string>> ReadKeyValuePair(string excelFilePath, string sheetName,
            string keyColumnName = "A", string valueColumnName = "B", int startRow = 2)
        {
            var list = new List<KeyValuePair<string, string>>();


            using (FileStream stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int keyColumnNumber = GetColumnNumber(keyColumnName);
                    int valueColumnNumber = GetColumnNumber(valueColumnName);

                    int endRow = GetLastRowNumberInSheet(workSheet, keyColumnNumber, startRow);

                    for (int i = startRow; i <= endRow; i++)
                    {
                        string key = workSheet.Cells[i, keyColumnNumber].Value.ToString();
                        string value = workSheet.Cells[i, valueColumnNumber].Value.ToString();
                        list.Add(new KeyValuePair<string, string>(key, value));
                    }
                }
            }

            return list;
        }



        //Convert CSV to Excel using EPPLUS 
        public static void CSVtoExcel(string csvFilePath, string excelFilePath, string sheetName, char Delimiter = ',', string EOL = @"\r", char TextQualifier = '"')
        {
            bool firstRowIsHeader = false;

            var excelTextFormat = new ExcelTextFormat();
            excelTextFormat.Delimiter = Delimiter;
            excelTextFormat.EOL = EOL;
            //excelTextFormat.TextQualifier = '"';

            var excelFileInfo = new FileInfo(excelFilePath);
            var csvFileInfo = new FileInfo(csvFilePath);

            using (ExcelPackage package = new ExcelPackage(excelFileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(sheetName);
                worksheet.Cells["A1"].LoadFromText(csvFileInfo, excelTextFormat, OfficeOpenXml.Table.TableStyles.Medium25, firstRowIsHeader);
                package.Save();
                package.Dispose();
            }
        }
    }
}
