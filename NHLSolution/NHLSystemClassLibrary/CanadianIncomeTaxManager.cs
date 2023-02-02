using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystemClassLibrary
{
	public class CanadianIncomeTaxManager
	{
		public List<CanadianIncomeTaxData> ConvertToCanadianIncomeTax(List<string> lines)
		{
			List<CanadianIncomeTaxData> dataList = new List<CanadianIncomeTaxData>();
			string[] values = new string[6];
			for (int i = 1; i < lines.Count; i++)
			{
				values = lines[i].Split(',');
				dataList.Add(new CanadianIncomeTaxData(values[0], values[1], int.Parse(values[2]), decimal.Parse(values[3]), decimal.Parse(values[4]), double.Parse(values[5]), decimal.Parse(values[6])));
			}
			return dataList;
		}
		public List<string> LoadFromCsvFile(string csvFilePath)
		{
			List<string> dataList = new List<string>();
			string dataLine;
			using StreamReader sr = new StreamReader(csvFilePath);
			{
				sr.ReadLine();
				while ((dataLine = sr.ReadLine()) != null)
				{
					dataList.Add(dataLine);
				}
			}
			return dataList;
		}
	}
}
