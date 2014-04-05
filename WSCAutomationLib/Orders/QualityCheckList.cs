using System;

namespace WSCAutomation.Orders
{
	public enum QualityPassCode : byte
	{
		Null = 0,

		Yes = 'y',
		No = 'n',
	};

	public class QualityCheckList
	{
		public int Id { get; set; }

		public int OrderId { get; set; }
		public QualityPassCode Pass { get; set; }
		public string Description { get; set; }

		public QualityCheckList()
		{
		}
	};
}