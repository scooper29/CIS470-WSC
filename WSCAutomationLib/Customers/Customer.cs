using System;

namespace WSCAutomation.Customers
{
	public class Customer
	{
		public int Id { get; set; }

		public int PaymentId { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }

		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public string Phone { get; set; }

		public Customer()
		{
		}
	};
}