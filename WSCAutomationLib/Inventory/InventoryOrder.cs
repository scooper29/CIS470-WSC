using System;
using System.Net;
using System.Net.Mail;

namespace WSCAutomation.Inventory
{
	public class InventoryOrder
	{
		public int Id { get; set; }

		public int InventoryId { get; set; }
		public int Quantity { get; set; }
		public bool Completed { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime ArrivalDate { get; set; }

		public InventoryOrder()
		{
		}

        /// <summary>
        /// Procedure for taking the parameters from the PurchaseInventoryRequest class,
        /// sending an email to the appropriate party, and updating the database.
        /// </summary>
        /// <param name="orderDate">Order date entered in PurchaseInventoryRequest.cs</param>
        /// <param name="deliveryDate">
        /// Expected delivery date entered in PurchaseInventoryRequest.cs
        /// </param>
        /// <param name="inventoryQTY">
        /// Inventory Quantity entered in PurchaseInventoryRequest.cs
        /// </param>
        /// <param name="inventoryID">Inventory ID entered in PurchaseInventoryRequest.cs
        /// </param>
        private void OrderInventoryProcedure(DateTime orderDate, DateTime deliveryDate
            ,decimal inventoryQTY, string inventoryID)
        {
            // Rough logic, will clean up when related areas of database access completed.
            // Declare
            bool validationStringToInt;
            bool validationStringLength;
            bool validationOrderDates;

            // Initialize
            validationStringLength = false;
            validationStringToInt = false;
            validationOrderDates = false;

            // Validate
            validationStringLength = StringLengthValidation(inventoryID.Length);
            validationStringToInt = StringToIntegerValidation(inventoryID);
            validationOrderDates = DateValidation(orderDate, deliveryDate);

            if (validationStringLength == false || validationStringToInt == false
                || validationOrderDates == false)
            {
                return;
            }

            // Mainline
            InventoryId = int.Parse(inventoryID);
            Quantity = (int)inventoryQTY;
            OrderDate = orderDate;
            ArrivalDate = deliveryDate;

            EmailDepartment();

            // Format Results
            // Return
            // DATABASE ACCESS PROCEDURES FOR ORDERING INVENTORY COMPLETION REQUIRED
        }

        /// <summary>
        /// Accepts int value, makes sure it is a four digit integer, returns validation
        /// success result.
        /// </summary>
        /// <param name="stringLengthToValidate">
        /// An int to validate is a four digit integer
        /// </param>
        /// <returns>Bool value stating whether validation successful.</returns>
        private bool StringLengthValidation (int stringLengthToValidate)
        {
            if (stringLengthToValidate != 4)
            {
                //MessageBox.Show(this
                //    , "Invalid inventory ID length. Please enter a four digit inventory ID."
                //    , "Inventory ID length error"
                //    , MessageBoxButtons.OK
                //    , MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        /// <summary>
        /// accepts string value, checks to see if it is an integer, return validation
        /// results.
        /// </summary>
        /// <param name="stringToValidate">
        /// String to check if characters are all integers.
        /// </param>
        /// <returns>Bool value stating whether validation successful.</returns>
        private bool StringToIntegerValidation (string stringToValidate)
        {
            try
            {
                int i = int.Parse(stringToValidate);

                return true;
            }
            catch
            {
                //MessageBox.Show(this
                //    , "Invalid inventory ID. Please enter a four digit inventory ID."
                //    , "Invalid inventory ID error"
                //    , MessageBoxButtons.OK
                //    , MessageBoxIcon.Error);

                return false;
            }
        }

        /// <summary>
        /// Accepts two DateTime values, makes sure the first date is not greater than or
        /// equal to the second date, returns validation results.
        /// </summary>
        /// <param name="firstDate">The date that comes first chronologically</param>
        /// <param name="secondDate">The date that comes second chronologically</param>
        /// <returns>Bool value stating whether validation successful.</returns>
        private bool DateValidation (DateTime firstDate, DateTime secondDate)
        {
            if (firstDate >= secondDate)
            {
                //MessageBox.Show(this
                //    , "Please make sure the delivery date comes after the order date."
                //    , "Invalid order/delivery date error"
                //    , MessageBoxButtons.OK
                //    , MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        /// <summary>
        /// Creates and sends the Email.
        /// </summary>
        private void EmailDepartment()
        {
            // Create Email
            var fromAddress = new MailAddress("wscclerk60683@gmail.com"
                , "WSC Clerk Automated");
            var toAddress = new MailAddress("wscspec60683@gmail.com"
                , "Specialist");
            const string FROM_PASSWORD = "senprojCIS470";
            const string SUBJECT = "Inventory order purchase made";
            string body = "The order you requested for inventory ID "
                + InventoryId
                + "has been ordered from our supplier. Details below."
                + System.Environment.NewLine
                + System.Environment.NewLine
                + "Inventory ID: "
                + InventoryId
                + System.Environment.NewLine
                + "Quantity Ordered: "
                + Quantity
                + System.Environment.NewLine
                + "Order Date: "
                + OrderDate
                + System.Environment.NewLine
                + "Expected Delivery Date: "
                + ArrivalDate;

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