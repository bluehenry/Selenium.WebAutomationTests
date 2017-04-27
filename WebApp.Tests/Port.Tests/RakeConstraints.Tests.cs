using Microsoft.VisualStudio.TestTools.UnitTesting;
using MES.Portal.Test.Framework;
using OfficeOpenXml;
using System.IO;

namespace MES.Portal.Tests
{
    [TestClass]
    public class RakeConstraints_Tests
    {
        private string testDataPath = @"C:\TestData\LST\";

        [TestInitialize]
        public void TestInitialize()
        {
            Browser.Initialize();
        }

        [TestMethod]
        public void SCR_203_002_RakeForceNewArrivalTime()
        {
            string rakeCode = "";

            string testDataFile = this.testDataPath + @"SCR_203_002_RakeForceNewArrivalTime.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    RakeConstraints.GoToRakesConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        rakeCode = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (rakeCode == string.Empty)
                            break;

                        RakeConstraintPage rakeConstraint = new RakeConstraintPage();

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            rakeConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                        { 
                            rakeConstraint.newArrivalDatetime = workSheet.Cells[rowNumber, 3].Value.ToString();
                        }
                        else
                        {
                            //Add 8 hours
                            rakeConstraint.newArrivalDatetime = System.DateTime.Now.AddHours(8).ToLocalTime().ToString("dd/MM/yyyy HH:mm");
                        }

                        RakeConstraints.SCR_203_002_RakeForceNewArrivalTime(rakeCode, rakeConstraint);

                        RakeConstraintPage rakeConstraintPage = new RakeConstraintPage();

                        RakeConstraints.SCR_203_002_RakeForceNewArrivalTime_Checking(rakeCode, rakeConstraintPage);

                        Assert.AreEqual(rakeConstraint.newArrivalDatetime, rakeConstraintPage.newArrivalDatetime);
                        Assert.AreEqual(rakeConstraint.reason, rakeConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }

        }

        [TestMethod]
        public void SCR_203_003_RakeForceUnallocated()
        {
            string rakeCode = "";
           
            string testDataFile = this.testDataPath + @"SCR_203_003_RakeForceUnallocated.xlsx";
            string sheetName = "TestData";
            
            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    RakeConstraints.GoToRakesConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        rakeCode = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (rakeCode == string.Empty)
                            break;

                        RakeConstraintPage rakeConstraint = new RakeConstraintPage();

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            rakeConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        rakeConstraint.forceRakeToRemainUnallocated = true;
                        RakeConstraints.SCR_203_003_RakeForceUnallocated(rakeCode, rakeConstraint);

                        RakeConstraintPage rakeConstraintPage = new RakeConstraintPage();

                        RakeConstraints.SCR_203_003_RakeForceUnallocated_Checking(rakeCode, rakeConstraintPage);

                        Assert.IsTrue(rakeConstraintPage.forceRakeToRemainUnallocated);
                        Assert.AreEqual(rakeConstraint.reason, rakeConstraintPage.reason);

                        //Change forceRakeToRemainUnallocated back to 'No' so that other tests can go on
                        rakeConstraint.forceRakeToRemainUnallocated = false;
                        RakeConstraints.SCR_203_003_RakeForceUnallocated(rakeCode, rakeConstraint);

                        rowNumber++;
                    }
                }
            }

        }

        [TestMethod]
        public void SCR_203_004_RakeForceToYardforMaintenance()
        {
            string rakeCode = "";

            string testDataFile = this.testDataPath + @"SCR_203_004_RakeForceToYardForMaintenance.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    RakeConstraints.GoToRakesConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        rakeCode = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (rakeCode == string.Empty)
                            break;

                        RakeConstraintPage rakeConstraint = new RakeConstraintPage();

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            rakeConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                            rakeConstraint.forceRakeToYard = workSheet.Cells[rowNumber, 3].Value.ToString();

                        RakeConstraints.SCR_203_004_RakeForceToYardforMaintenance(rakeCode, rakeConstraint);

                        RakeConstraintPage rakeConstraintPage = new RakeConstraintPage();

                        RakeConstraints.SCR_203_004_RakeForceToYardforMaintenance_Checking(rakeCode, rakeConstraintPage);

                        Assert.AreEqual(rakeConstraint.forceRakeToYard, rakeConstraintPage.forceRakeToYard);
                        Assert.AreEqual(rakeConstraint.reason, rakeConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }

        }

        [TestMethod]
        public void SCR_203_006_RakeForceRakeToDumperASAP()
        {
            string rakeCode = "";

            string testDataFile = this.testDataPath + @"SCR_203_006_RakeForceRakeToDumperASAP.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    RakeConstraints.GoToRakesConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        rakeCode = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (rakeCode == string.Empty)
                            break;

                        RakeConstraintPage rakeConstraint = new RakeConstraintPage();

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            rakeConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                        { 
                            rakeConstraint.forceRakeToDumperASAP = workSheet.Cells[rowNumber, 3].Value.ToString();
                        }
                        else
                        {
                            //Add 8 hours
                            rakeConstraint.forceRakeToDumperASAP = System.DateTime.Now.AddHours(8).ToLocalTime().ToString("dd/MM/yyyy HH:mm");
                        }

                        RakeConstraints.SCR_203_006_RakeForceRakeToDumperASAP(rakeCode, rakeConstraint);

                        RakeConstraintPage rakeConstraintPage = new RakeConstraintPage();

                        RakeConstraints.SCR_203_006_RakeForceRakeToDumperASAP_Checking(rakeCode, rakeConstraintPage);

                        Assert.AreEqual(rakeConstraint.forceRakeToDumperASAP, rakeConstraintPage.forceRakeToDumperASAP);
                        Assert.AreEqual(rakeConstraint.reason, rakeConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }
        }

        [TestMethod]
        public void SCR_203_008_RakeForceBypassofLRP()
        {
            string rakeCode = "";                     

            string testDataFile = this.testDataPath + @"SCR_203_008_RakeForceBypassofLRP.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    RakeConstraints.GoToRakesConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        rakeCode = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (rakeCode == string.Empty)
                            break;

                        RakeConstraintPage rakeConstraint = new RakeConstraintPage();

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            rakeConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        RakeConstraints.SCR_203_008_RakeForceBypassofLRP(rakeCode, rakeConstraint);

                        RakeConstraintPage rakeConstraintPage = new RakeConstraintPage();

                        RakeConstraints.SCR_203_008_RakeForceBypassofLRP_Checking(rakeCode, rakeConstraintPage);

                        Assert.IsTrue(rakeConstraintPage.forceBypassLRP);
                        Assert.AreEqual(rakeConstraint.reason, rakeConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }
        }

        [TestMethod]
        public void SCR_203_014_RakeForcedToSpecifiedCD()
        {
            string rakeCode = "";

            string testDataFile = this.testDataPath + @"SCR_203_014_RakeForcedToSpecifiedCD.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    RakeConstraints.GoToRakesConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        rakeCode = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (rakeCode == string.Empty)
                            break;

                        RakeConstraintPage rakeConstraint = new RakeConstraintPage();

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            rakeConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                            rakeConstraint.carDumper = workSheet.Cells[rowNumber, 3].Value.ToString();

                        RakeConstraints.SCR_203_014_RakeForcedToSpecifiedCD(rakeCode, rakeConstraint);

                        RakeConstraintPage rakeConstraintPage = new RakeConstraintPage();

                        RakeConstraints.SCR_203_014_RakeForcedToSpecifiedCD_Checking(rakeCode, rakeConstraintPage);

                        Assert.AreEqual(rakeConstraint.carDumper, rakeConstraintPage.carDumper);
                        Assert.AreEqual(rakeConstraint.reason, rakeConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }
        }


        [TestMethod]
        public void SCR_203_015_RakeDumpingSplit()
        {
            string rakeCode = "";

            string testDataFile = this.testDataPath + @"SCR_203_015_RakeDumpingSplit.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    RakeConstraints.GoToRakesConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        rakeCode = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (rakeCode == string.Empty)
                            break;

                        RakeConstraintPage rakeConstraint = new RakeConstraintPage();

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            rakeConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                            rakeConstraint.forceToStockpile1 = workSheet.Cells[rowNumber, 3].Value.ToString();

                        if (workSheet.Cells[rowNumber, 4].Value != null)
                            rakeConstraint.splitFromOreCar = workSheet.Cells[rowNumber, 4].Value.ToString();

                        if (workSheet.Cells[rowNumber, 5].Value != null)
                            rakeConstraint.forceToStockpile2 = workSheet.Cells[rowNumber, 5].Value.ToString();

                        RakeConstraints.SCR_203_015_RakeDumpingSplit(rakeCode, rakeConstraint);

                        RakeConstraintPage rakeConstraintPage = new RakeConstraintPage();

                        RakeConstraints.SCR_203_015_RakeDumpingSplit_Checking(rakeCode, rakeConstraintPage);

                        Assert.AreEqual(rakeConstraint.forceToStockpile1, rakeConstraintPage.forceToStockpile1);
                        Assert.AreEqual(rakeConstraint.forceToStockpile2, rakeConstraintPage.forceToStockpile2);
                        Assert.AreEqual(rakeConstraint.reason, rakeConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }
        }

        [TestMethod]
        public void SCR_203_009_RakeForceDumpingDurationOffset()
        {
            string rakeCode = "";

            string testDataFile = this.testDataPath + @"SCR_203_009_RakeForceDumpingDurationOffset.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    RakeConstraints.GoToRakesConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        rakeCode = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (rakeCode == string.Empty)
                            break;

                        RakeConstraintPage rakeConstraint = new RakeConstraintPage();

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            rakeConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                            rakeConstraint.dumpingDurationOffset = workSheet.Cells[rowNumber, 3].Value.ToString();

                        RakeConstraints.SCR_203_009_RakeForceDumpingDurationOffset(rakeCode, rakeConstraint);

                        RakeConstraintPage rakeConstraintPage = new RakeConstraintPage();

                        RakeConstraints.SCR_203_009_RakeForceDumpingDurationOffset_Checking(rakeCode, rakeConstraintPage);

                        Assert.AreEqual(rakeConstraint.dumpingDurationOffset, rakeConstraintPage.dumpingDurationOffset);
                        Assert.AreEqual(rakeConstraint.reason, rakeConstraintPage.reason);

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
