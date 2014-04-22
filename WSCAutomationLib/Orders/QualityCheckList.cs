using System;

namespace WSCAutomation.Orders
{
	public class QualityCheckList
	{
        public int Id { get; set; }

		public bool Pass { get; set; }
		public string Description { get; set; }

		public QualityCheckList()
		{
			Id = -1;

			Description = "";
		}
	};
}