using Microsoft.VisualStudio.TestTools.UnitTesting;
using MES.Portal.Test.Framework;
using OfficeOpenXml;
using System.IO;

namespace MES.Portal.Tests
{
    [TestClass]
    public class NominationConstraints_Tests
    {
        private string testDataPath = @"C:\TestData\LST\";

        [TestInitialize]
        public void TestInitialize()
        {
            Browser.Initialize();
        }


        [TestMethod]
        public void SCR_203_016_NominationRemainUnallocated()
        {
            string nomination = "";            

            string testDataFile = this.testDataPath + @"SCR_203_016_NominationRemainUnallocated.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    NominationConstraints.GoToNominationsConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        nomination = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (nomination == string.Empty)
                            break;

                        NominationConstraintPage nominationConstraint = new NominationConstraintPage();

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            nominationConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        nominationConstraint.vesselRemainUnallocated = true;
                        NominationConstraints.SCR_203_016_NominationRemainUnallocated(nomination, nominationConstraint);

                        NominationConstraintPage nominationConstraintPage = new NominationConstraintPage();

                        NominationConstraints.SCR_203_016_NominationRemainUnallocated_Checking(nomination, nominationConstraintPage);

                        Assert.IsTrue(nominationConstraintPage.vesselRemainUnallocated);
                        Assert.AreEqual(nominationConstraint.reason, nominationConstraintPage.reason);

                        // Change vesselRemainUnallocated back to 'No', so that other tests can go on
                        nominationConstraint.vesselRemainUnallocated = false;
                        NominationConstraints.SCR_203_016_NominationRemainUnallocated(nomination, nominationConstraint);
                        
                        rowNumber++;
                    }
                }
            }

        }

        [TestMethod]
        public void SCR_203_017_NominationForceVesselToBerthASAP()
        {
            string nomination = "";

            string testDataFile = this.testDataPath + @"SCR_203_017_NominationForceVesselToBerthASAP.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    NominationConstraints.GoToNominationsConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        nomination = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (nomination == string.Empty)
                            break;

                        NominationConstraintPage nominationConstraint = new NominationConstraintPage();

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            nominationConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                        { 
                            nominationConstraint.forceVesselToBerthASAP = workSheet.Cells[rowNumber, 3].Value.ToString();
                        }
                        else
                        {
                            //Add 6 hours
                            nominationConstraint.forceVesselToBerthASAP = System.DateTime.Now.AddHours(6).ToLocalTime().ToString("dd/MM/yyyy HH:mm");
                        }

                        NominationConstraints.SCR_203_017_NominationForceVesselToBerthASAP(nomination, nominationConstraint);

                        NominationConstraintPage nominationConstraintPage = new NominationConstraintPage();

                        NominationConstraints.SCR_203_017_NominationForceVesselToBerthASAP_Checking(nomination, nominationConstraintPage);

                        Assert.AreEqual(nominationConstraint.forceVesselToBerthASAP, nominationConstraintPage.forceVesselToBerthASAP);
                        Assert.AreEqual(nominationConstraint.reason, nominationConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }

        }


        [TestMethod]
        public void SCR_203_019_NominationForcedtoTerminal()
        {
            string nomination = "";

            string testDataFile = this.testDataPath + @"SCR_203_019_NominationForcedtoTerminal.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    NominationConstraints.GoToNominationsConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        nomination = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (nomination == string.Empty)
                            break;

                        NominationConstraintPage nominationConstraint = new NominationConstraintPage();

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            nominationConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                            nominationConstraint.forceVesselToTerminal = workSheet.Cells[rowNumber, 3].Value.ToString();

                        NominationConstraints.SCR_203_019_NominationForcedtoTerminal(nomination, nominationConstraint);

                        NominationConstraintPage nominationConstraintPage = new NominationConstraintPage();

                        NominationConstraints.SCR_203_019_NominationForcedtoTerminal_Checking(nomination, nominationConstraintPage);

                        Assert.AreEqual(nominationConstraint.forceVesselToTerminal, nominationConstraintPage.forceVesselToTerminal);
                        Assert.AreEqual(nominationConstraint.reason, nominationConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }

        }

        [TestMethod]
        public void SCR_203_020_NominationForcedtoBerth()
        {
            string nomination = "";

            string testDataFile = this.testDataPath + @"SCR_203_020_NominationForcedtoBerth.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    NominationConstraints.GoToNominationsConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        nomination = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (nomination == string.Empty)
                            break;

                        NominationConstraintPage nominationConstraint = new NominationConstraintPage();

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            nominationConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                            nominationConstraint.forceVesselToBerth = workSheet.Cells[rowNumber, 3].Value.ToString();

                        NominationConstraints.SCR_203_020_NominationForcedtoBerth(nomination, nominationConstraint);

                        NominationConstraintPage nominationConstraintPage = new NominationConstraintPage();

                        NominationConstraints.SCR_203_020_NominationForcedtoBerth_Checking(nomination, nominationConstraintPage);

                        Assert.AreEqual(nominationConstraint.forceVesselToBerth, nominationConstraintPage.forceVesselToBerth);
                        Assert.AreEqual(nominationConstraint.reason, nominationConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }

        }

        [TestMethod]
        public void SCR_203_021_NominationForcedPOBInbound()
        {
            string nomination = "";

            string testDataFile = this.testDataPath + @"SCR_203_021_NominationForcedPOBInbound.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    NominationConstraints.GoToNominationsConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        nomination = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (nomination == string.Empty)
                            break;

                        NominationConstraintPage nominationConstraint = new NominationConstraintPage();

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            nominationConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                        { 
                            nominationConstraint.POBInBound = workSheet.Cells[rowNumber, 3].Value.ToString();
                        }
                        else
                        {
                            //Add 7 hours
                            nominationConstraint.POBInBound = System.DateTime.Now.AddHours(7).ToLocalTime().ToString("dd/MM/yyyy HH:mm");
                        }

                        NominationConstraints.SCR_203_021_NominationForcedPOBInbound(nomination, nominationConstraint);

                        NominationConstraintPage nominationConstraintPage = new NominationConstraintPage();

                        NominationConstraints.SCR_203_021_NominationForcedPOBInbound_Checking(nomination, nominationConstraintPage);

                        Assert.AreEqual(nominationConstraint.POBInBound, nominationConstraintPage.POBInBound);
                        Assert.AreEqual(nominationConstraint.reason, nominationConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }

        }

        [TestMethod]
        public void SCR_203_022_NominationForcedPOBOutbound()
        {
            string nomination = "";

            string testDataFile = this.testDataPath + @"SCR_203_022_NominationForcedPOBOutbound.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    NominationConstraints.GoToNominationsConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        nomination = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (nomination == string.Empty)
                            break;

                        NominationConstraintPage nominationConstraint = new NominationConstraintPage();

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            nominationConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                        { 
                            nominationConstraint.POBOutBound = workSheet.Cells[rowNumber, 3].Value.ToString();
                        }
                        else
                        {
                            //Add 8 hours
                            nominationConstraint.POBOutBound = System.DateTime.Now.AddHours(8).ToLocalTime().ToString("dd/MM/yyyy HH:mm");
                        }

                    NominationConstraints.SCR_203_022_NominationForcedPOBOutbound(nomination, nominationConstraint);

                        NominationConstraintPage nominationConstraintPage = new NominationConstraintPage();

                        NominationConstraints.SCR_203_022_NominationForcedPOBOutbound_Checking(nomination, nominationConstraintPage);

                        Assert.AreEqual(nominationConstraint.POBOutBound, nominationConstraintPage.POBOutBound);
                        Assert.AreEqual(nominationConstraint.reason, nominationConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }

        }

        [TestMethod]
        public void SCR_203_023_NominationLoadingRates()
        {
            string nomination = "";

            string testDataFile = this.testDataPath + @"SCR_203_023_NominationLoadingRates.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    NominationConstraints.GoToNominationsConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        nomination = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (nomination == string.Empty)
                            break;

                        NominationConstraintPage nominationConstraint = new NominationConstraintPage();

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            nominationConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                            nominationConstraint.shiploadingRatesTph = workSheet.Cells[rowNumber, 3].Value.ToString();

                        if (workSheet.Cells[rowNumber, 4].Value != null)
                        { 
                            nominationConstraint.shiploadingRatesFromDateTime = workSheet.Cells[rowNumber, 4].Value.ToString();
                        }
                        else
                        {
                            //Add 7 hours
                            nominationConstraint.shiploadingRatesFromDateTime = System.DateTime.Now.AddHours(7).ToLocalTime().ToString("dd/MM/yyyy HH:mm");
                        }

                        if (workSheet.Cells[rowNumber, 5].Value != null)
                        { 
                            nominationConstraint.shiploadingRatesToDateTime = workSheet.Cells[rowNumber, 5].Value.ToString();
                        }
                        else
                        {
                            //Add 8 hours
                            nominationConstraint.shiploadingRatesToDateTime = System.DateTime.Now.AddHours(8).ToLocalTime().ToString("dd/MM/yyyy HH:mm");
                        }

                        NominationConstraints.SCR_203_023_NominationLoadingRates(nomination, nominationConstraint);

                        NominationConstraintPage nominationConstraintPage = new NominationConstraintPage();

                        NominationConstraints.SCR_203_023_NominationLoadingRates_Checking(nomination, nominationConstraintPage);

                        Assert.AreEqual(nominationConstraint.shiploadingRatesFromDateTime, nominationConstraintPage.shiploadingRatesFromDateTime);
                        Assert.AreEqual(nominationConstraint.shiploadingRatesToDateTime, nominationConstraintPage.shiploadingRatesToDateTime);
                        Assert.AreEqual(nominationConstraint.shiploadingRatesTph, nominationConstraintPage.shiploadingRatesTph);
                        Assert.AreEqual(nominationConstraint.reason, nominationConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }
        }

        [TestMethod]
        public void SCR_203_024_NominationShiploadingDelays()
        {
            string nomination = "";
            
            string testDataFile = this.testDataPath + @"SCR_203_024_NominationShiploadingDelays.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    NominationConstraints.GoToNominationsConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        nomination = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (nomination == string.Empty)
                            break;

                        NominationConstraintPage nominationConstraint = new NominationConstraintPage();

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            nominationConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                            nominationConstraint.allFastDays = workSheet.Cells[rowNumber, 3].Value.ToString();

                        if (workSheet.Cells[rowNumber, 4].Value != null)
                            nominationConstraint.allFastHours = workSheet.Cells[rowNumber, 4].Value.ToString();

                        if (workSheet.Cells[rowNumber, 5].Value != null)
                            nominationConstraint.loadingHaltDays = workSheet.Cells[rowNumber, 5].Value.ToString();

                        if (workSheet.Cells[rowNumber, 6].Value != null)
                            nominationConstraint.loadingHaltHours = workSheet.Cells[rowNumber, 6].Value.ToString();

                        if (workSheet.Cells[rowNumber, 7].Value != null)
                            nominationConstraint.loadingHaltTonnes = workSheet.Cells[rowNumber, 7].Value.ToString();

                        if (workSheet.Cells[rowNumber, 8].Value != null)
                            nominationConstraint.completeLoadDays = workSheet.Cells[rowNumber, 8].Value.ToString();

                        if (workSheet.Cells[rowNumber, 9].Value != null)
                            nominationConstraint.completeLoadHours = workSheet.Cells[rowNumber, 9].Value.ToString();

                        NominationConstraints.SCR_203_024_NominationShiploadingDelays(nomination, nominationConstraint);

                        NominationConstraintPage nominationConstraintPage = new NominationConstraintPage();

                        NominationConstraints.SCR_203_024_NominationShiploadingDelays_Checking(nomination, nominationConstraintPage);

                        Assert.AreEqual(nominationConstraint.allFastDays, nominationConstraintPage.allFastDays);
                        Assert.AreEqual(nominationConstraint.allFastHours, nominationConstraintPage.allFastHours);
                        Assert.AreEqual(nominationConstraint.loadingHaltDays, nominationConstraintPage.loadingHaltDays);
                        Assert.AreEqual(nominationConstraint.loadingHaltHours, nominationConstraintPage.loadingHaltHours);
                        Assert.AreEqual(nominationConstraint.loadingHaltTonnes, nominationConstraintPage.loadingHaltTonnes);
                        Assert.AreEqual(nominationConstraint.completeLoadDays, nominationConstraintPage.completeLoadDays);
                        Assert.AreEqual(nominationConstraint.completeLoadHours, nominationConstraintPage.completeLoadHours);
                        Assert.AreEqual(nominationConstraint.reason, nominationConstraintPage.reason);

                        rowNumber++;
                    }
                }
            }
        }

        [TestMethod]
        public void SCR_203_025_NominationShiploadingSource()
        {
            string nomination = "";

            string testDataFile = this.testDataPath + @"SCR_203_025_NominationShiploadingSource.xlsx";
            string sheetName = "TestData";

            using (FileStream stream = File.Open(testDataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                    int rowNumber = 2;

                    Dashboard.GoTo();
                    NominationConstraints.GoToNominationsConstraints();

                    while (workSheet.Cells[rowNumber, 1].Value != null)
                    {
                        nomination = workSheet.Cells[rowNumber, 1].Value.ToString();
                        if (nomination == string.Empty)
                            break;

                        NominationConstraintPage nominationConstraint = new NominationConstraintPage();

                        if (workSheet.Cells[rowNumber, 2].Value != null)
                            nominationConstraint.reason = workSheet.Cells[rowNumber, 2].Value.ToString();

                        if (workSheet.Cells[rowNumber, 3].Value != null)
                            nominationConstraint.shiploadingSourceStockpile = workSheet.Cells[rowNumber, 3].Value.ToString();

                        if (workSheet.Cells[rowNumber, 4].Value != null)
                            nominationConstraint.shiploadingSourceMaxTones = workSheet.Cells[rowNumber, 4].Value.ToString();

                        NominationConstraints.SCR_203_025_NominationShiploadingSource(nomination, nominationConstraint);

                        NominationConstraintPage nominationConstraintPage = new NominationConstraintPage();

                        NominationConstraints.SCR_203_025_NominationShiploadingSource_Checking(nomination, nominationConstraintPage);

                        Assert.AreEqual(nominationConstraint.shiploadingSourceStockpile, nominationConstraintPage.shiploadingSourceStockpile);
                        Assert.AreEqual(nominationConstraint.shiploadingSourceMaxTones, nominationConstraintPage.shiploadingSourceMaxTones);
                        Assert.AreEqual(nominationConstraint.reason, nominationConstraintPage.reason);

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
