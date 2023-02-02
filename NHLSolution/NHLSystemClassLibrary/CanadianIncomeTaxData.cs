using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystemClassLibrary
{
	public struct CanadianIncomeTaxData
	{
		public string RegionAbbreviation { get; private set; }
		public string RegionName { get; private set; }
		public int TaxYear { get; private set; }
		public decimal StartingIncome { get; private set; }
		public decimal EndingIncome { get; private set; }
		public double TaxRate { get; private set; }
		public decimal BaseTaxAmount { get; private set; }

		public CanadianIncomeTaxData(string rAbbreviation, string rName, int taxYear, decimal sIncome, decimal eIncome, double taxRate, decimal baseTaxAmount)
		{
			RegionAbbreviation = rAbbreviation;
			RegionName = rName;
			TaxYear = taxYear;
			StartingIncome = sIncome;
			EndingIncome = eIncome;
			TaxRate = taxRate;
			BaseTaxAmount = baseTaxAmount;
		}
	}
}
