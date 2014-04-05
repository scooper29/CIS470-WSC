﻿using System;

namespace WSCAutomation.Customers
{
	public class Payment
	{
		public int Id { get; set; }

		public string Type { get; set; }
		public string CardNumber { get; set; }
		public DateTime ExpirationDate { get; set; }

		public Payment()
		{
		}
	};
}