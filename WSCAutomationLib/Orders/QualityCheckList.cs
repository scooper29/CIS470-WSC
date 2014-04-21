using System;

namespace WSCAutomation.Orders
{
	public class QualityCheckList
	{
		//took out old datatype create "QualityPassCode" because it was unnecessary and hindered call of quality check method - Andy
        public int Id { get; set; }

		public int OrderId { get; set; }
		public bool Pass { get; set; }
		public string Description { get; set; }

		public QualityCheckList()
		{
		}
	};
}