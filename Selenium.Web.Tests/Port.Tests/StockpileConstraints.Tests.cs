using Microsoft.VisualStudio.TestTools.UnitTesting;
using MES.Portal.Test.Framework;
using OfficeOpenXml;
using System.IO;

namespace MES.Portal.Tests
{
    [TestClass]
    public class StockpileConstratins_Tests
    {
        private string testDataPath = @"C:\TestData\LST\";

        [TestInitialize]
        public void TestInitialize()
        {
            Browser.Initialize();
        }
        [TestMethod]
        public void SCR_203_034_StockpileAdjustOpeningBalance()
        {
            string stockpile = "";

            string testDataFile = this.testDataPath + @"SCR_203_034_StockpileAdjustOpeningBalance.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    StockpileConstraints.GoToStockpilesConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        StockpileConstraintPage stockpileConstraint = new StockpileConstraintPage();

                        stockpile = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (stockpile == string.Empty)
                            break;

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            stockpileConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                            stockpileConstraint.adjustOpeningBalance = workSheet.Cells[rowNumber, 3].Value.ToString();

                        StockpileConstraints.SCR_203_034_StockpileAdjustOpeningBalance(stockpile, stockpileConstraint);

                        StockpileConstraintPage stockpileConstraintPage = new StockpileConstraintPage();

                        StockpileConstraints.SCR_203_034_StockpileAdjustpeningBalance_Checking(stockpile, stockpileConstraintPage);
                                                
                        Assert.AreEqual(stockpileConstraint.adjustOpeningBalance, stockpileConstraintPage.adjustOpeningBalance);
                        Assert.AreEqual(stockpileConstraint.reason, stockpileConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }
        }

        [TestMethod]
        public void SCR_203_035_StockpileForceOpeningStatus()
        {
            string stockpile = "";

            string testDataFile = this.testDataPath + @"SCR_203_035_StockpileForceOpeningStatus.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    StockpileConstraints.GoToStockpilesConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        StockpileConstraintPage stockpileConstraint = new StockpileConstraintPage();

                        stockpile = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (stockpile == string.Empty)
                            break;

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            stockpileConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                            stockpileConstraint.forceOpeingStatus = workSheet.Cells[rowNumber, 3].Value.ToString();

                        StockpileConstraints.SCR_203_035_StockpileForceOpeningStatus(stockpile, stockpileConstraint);

                        StockpileConstraintPage stockpileConstraintPage = new StockpileConstraintPage();

                        StockpileConstraints.SCR_203_035_StockpileForceOpeningStatus_Checking(stockpile, stockpileConstraintPage);

                        Assert.AreEqual(stockpileConstraint.forceOpeingStatus, stockpileConstraintPage.forceOpeingStatus);
                        Assert.AreEqual(stockpileConstraint.reason, stockpileConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }
        }

        [TestMethod]
        public void SCR_203_036_StockpileForceOpeningGrade()
        {
            string stockpile = "";

            string testDataFile = this.testDataPath + @"SCR_203_036_StockpileForceOpeningGrade.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    StockpileConstraints.GoToStockpilesConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        StockpileConstraintPage stockpileConstraint = new StockpileConstraintPage();

                        stockpile = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (stockpile == string.Empty)
                            break;

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            stockpileConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                            stockpileConstraint.forceOpeningGradeAI2O3 = workSheet.Cells[rowNumber, 3].Value.ToString();

                        if (workSheet.Cells[rowNumber, 4].Value != null)
                            stockpileConstraint.forceOpeningGradeFe = workSheet.Cells[rowNumber, 4].Value.ToString();

                        if (workSheet.Cells[rowNumber, 5].Value != null)
                            stockpileConstraint.forceOpeningGradeH2O = workSheet.Cells[rowNumber, 5].Value.ToString();

                        if (workSheet.Cells[rowNumber, 6].Value != null)
                            stockpileConstraint.forceOpeningGradeP = workSheet.Cells[rowNumber, 6].Value.ToString();

                        if (workSheet.Cells[rowNumber, 7].Value != null)
                            stockpileConstraint.forceOpeningGradeSiO2 = workSheet.Cells[rowNumber, 7].Value.ToString();


                        StockpileConstraints.SCR_203_036_StockpileForceOpeningGrade(stockpile, stockpileConstraint);

                        StockpileConstraintPage stockpileConstraintPage = new StockpileConstraintPage();

                        StockpileConstraints.SCR_203_036_StockpileForceOpeningGrade_Checking(stockpile, stockpileConstraintPage);

                        Assert.AreEqual(stockpileConstraint.forceOpeningGradeAI2O3, stockpileConstraintPage.forceOpeningGradeAI2O3);
                        Assert.AreEqual(stockpileConstraint.forceOpeningGradeFe, stockpileConstraintPage.forceOpeningGradeFe);
                        Assert.AreEqual(stockpileConstraint.forceOpeningGradeH2O, stockpileConstraintPage.forceOpeningGradeH2O);
                        Assert.AreEqual(stockpileConstraint.forceOpeningGradeP, stockpileConstraintPage.forceOpeningGradeP);
                        Assert.AreEqual(stockpileConstraint.forceOpeningGradeSiO2, stockpileConstraintPage.forceOpeningGradeSiO2);
                        Assert.AreEqual(stockpileConstraint.reason, stockpileConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }
        }

        [TestMethod]
        public void SCR_203_037_StockpileForceUnavailableForStacking()
        {
            string stockpile = "";

            string testDataFile = this.testDataPath + @"SCR_203_037_StockpileForceUnavailableForStacking.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    StockpileConstraints.GoToStockpilesConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        StockpileConstraintPage stockpileConstraint = new StockpileConstraintPage();

                        stockpile = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (stockpile == string.Empty)
                            break;

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            stockpileConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                        { 
                            stockpileConstraint.unavailableForStakingFromDatetime = workSheet.Cells[rowNumber, 3].Value.ToString();
                        }
                        else
                        {
                            //Add 7 hours
                            stockpileConstraint.unavailableForStakingFromDatetime = System.DateTime.Now.AddHours(7).ToLocalTime().ToString("dd/MM/yyyy HH:mm");
                        }

                        if (workSheet.Cells[rowNumber, 4].Value != null)
                        { 
                            stockpileConstraint.unavailableForStakingToDatetime = workSheet.Cells[rowNumber, 4].Value.ToString();
                        }
                        else
                        {
                            //Add 8 hours
                            stockpileConstraint.unavailableForStakingToDatetime = System.DateTime.Now.AddHours(8).ToLocalTime().ToString("dd/MM/yyyy HH:mm");
                        }

                        StockpileConstraints.SCR_203_037_StockpileForceUnavailableForStacking(stockpile, stockpileConstraint);

                        StockpileConstraintPage stockpileConstraintPage = new StockpileConstraintPage();

                        StockpileConstraints.SCR_203_037_StockpileForceUnavailableForStacking_Checking(stockpile, stockpileConstraintPage);

                        Assert.AreEqual(stockpileConstraint.unavailableForStakingFromDatetime, stockpileConstraintPage.unavailableForStakingFromDatetime);
                        Assert.AreEqual(stockpileConstraint.unavailableForStakingToDatetime, stockpileConstraintPage.unavailableForStakingToDatetime);

                        Assert.AreEqual(stockpileConstraint.reason, stockpileConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }
        }


        [TestMethod]
        public void SCR_203_038_StockpileForceUnavailableForReclaiming()
        {
            string stockpile = "";

            string testDataFile = this.testDataPath + @"SCR_203_038_StockpileForceUnavailableForReclaiming.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    StockpileConstraints.GoToStockpilesConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        StockpileConstraintPage stockpileConstraint = new StockpileConstraintPage();

                        stockpile = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (stockpile == string.Empty)
                            break;

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            stockpileConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                        { 
                            stockpileConstraint.unavailableForReclaimingFromDatetime = workSheet.Cells[rowNumber, 3].Value.ToString();
                        }
                        else
                        {
                            //Add 7 hours
                            stockpileConstraint.unavailableForReclaimingFromDatetime = System.DateTime.Now.AddHours(7).ToLocalTime().ToString("dd/MM/yyyy HH:mm");
                        }

                        if (workSheet.Cells[rowNumber, 4].Value != null)
                        { 
                            stockpileConstraint.unavailableForReclaimingToDatetime = workSheet.Cells[rowNumber, 4].Value.ToString();
                        }
                        else
                        {
                            //Add 8 hours
                            stockpileConstraint.unavailableForReclaimingToDatetime = System.DateTime.Now.AddHours(8).ToLocalTime().ToString("dd/MM/yyyy HH:mm");
                        }

                        StockpileConstraints.SCR_203_038_StockpileForceUnavailableForReclaiming(stockpile, stockpileConstraint);

                        StockpileConstraintPage stockpileConstraintPage = new StockpileConstraintPage();

                        StockpileConstraints.SCR_203_038_StockpileForceUnavailableForReclaiming_Checking(stockpile, stockpileConstraintPage);

                        Assert.AreEqual(stockpileConstraint.unavailableForReclaimingFromDatetime, stockpileConstraintPage.unavailableForReclaimingFromDatetime);
                        Assert.AreEqual(stockpileConstraint.unavailableForReclaimingToDatetime, stockpileConstraintPage.unavailableForReclaimingToDatetime);

                        Assert.AreEqual(stockpileConstraint.reason, stockpileConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Browser.Close();
        }
    }
}
