using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystemTestProject
{
	[TestClass]
	public class CanadianIncomeTaxManagerTest
	{
		[TestMethod]
		[DataRow(439, "C:\\Users\\ahoffschild1\\Downloads\\CanadianPersonalIncomeTaxRates.csv")]
		public void VerifyContent_LoadFromCsvFile_CorrectNumberOfLines(int expectedLines, string csvFilePath)
		{
			// Get object to test
			var dataManager = new CanadianIncomeTaxManager();
			List<string> actualList = new List<string>();
			// Act on object
			actualList = dataManager.LoadFromCsvFile(csvFilePath);
			// Assert expected on object
			Assert.AreEqual(expectedLines, actualList.Count);
		}

		[TestMethod]
		[DataRow("CAN", "Canada", 2023, 0, 53359, 0.15, 0)]
		public void VerifyRow_ConvertToCanadianIncomeTax_GoodValues(string rAbbreviation, string rName, int taxYear, decimal sIncome, decimal eIncome, double taxRate, decimal baseTaxAmount)
		{
			// Get objects to test
			CanadianIncomeTaxData expectedItem = new CanadianIncomeTaxData(rAbbreviation, rName, taxYear, sIncome, eIncome, taxRate, baseTaxAmount);
			List<CanadianIncomeTaxData> actualList = new List<CanadianIncomeTaxData>();
			List<string> listFromFile = new List<string>();
			var dataManager = new CanadianIncomeTaxManager();
			// Act on objects
			listFromFile = dataManager.LoadFromCsvFile("C:\\Users\\ahoffschild1\\Downloads\\CanadianPersonalIncomeTaxRates.csv");
			actualList = dataManager.ConvertToCanadianIncomeTax(listFromFile);
			// Assert
			Assert.AreEqual(expectedItem.RegionAbbreviation, actualList[1].RegionAbbreviation);
		}
	}
}
