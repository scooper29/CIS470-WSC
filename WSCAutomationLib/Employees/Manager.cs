using System;

namespace WSCAutomation.Employees
{
	public sealed class Manager : Employee
	{
		public Manager()
		{
		}

		public void VaidateOrder()
		{
		}
        
		public void PerformQualityCheck()
		{
		}

        public void EmailDepartment(Inventory.InventoryOrder invOrder)
        {
            // Create Email
            var fromAddress = new MailAddress("wscman60683@gmail.com"
                , "WSC Clerk Automated");
            var toAddress = new MailAddress("wscclerk60683@gmail.com"
                , "Specialist");
            const string FROM_PASSWORD = "senprojCIS470";
            const string SUBJECT = "Inventory order purchase made";
            string body = "The order you requested for inventory ID "
                + invOrder.InventoryId
                + "has been ordered from our supplier. Details below."
                + System.Environment.NewLine
                + System.Environment.NewLine
                + "Inventory ID: "
                + invOrder.InventoryId
                + System.Environment.NewLine
                + "Quantity Ordered: "
                + invOrder.Quantity
                + System.Environment.NewLine
                + "Order Date: "
                + invOrder.OrderDate
                + System.Environment.NewLine
                + "Expected Delivery Date: "
                + invOrder.ArrivalDate;

            // Use gmail SMTP client
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, FROM_PASSWORD)
            };

            // Send message
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = SUBJECT
                ,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
	};
}