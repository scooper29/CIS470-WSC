﻿using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace WSCAutomation.Employees
{
	public sealed class Clerk : Employee
	{
		public Clerk()
		{
		}

        public int AddInventory(Inventory.Inventory invIn)
        {
            // returns itemID from DBAddInventory after item added
            return Database.DatabaseManager.Instance.DBAddInventory(invIn);
        }

        public bool UpdateInventory(Inventory.Inventory invIN)
        {
            // creates instance of the DBManager
            var dbm = Database.DatabaseManager.Instance;

            // returns results from DBGetInventory
            var results = dbm.DBGetInventory(inventoryID: invIN.InventoryID);

            // this throws an excpetion if more or less that 1 result is returned
            // should never happen here
            if (results.Count != 1)
            {
                throw new InvalidOperationException("Unexpected inventory results");
            }

            // creates inv object from the returned list (only one)
            var inv = results[0];

            // increases the qty sold field
            inv.Manufacturer = invIN.Manufacturer;
            inv.Name = invIN.Name;
            inv.Quantity = invIN.Quantity;

            // returns true of the edit is successful
            return dbm.DBEditInventory(inv);
        }



#region OrderInventory
        /// <summary>
        /// Procedure for taking the parameters from the PurchaseInventoryRequest class,
        /// sending an email to the appropriate party, and updating the database.
        /// </summary>
        /// <param name="invOrder">InventoryOrder Class Object</param>
        public int OrderInventoryProcedure(Inventory.InventoryOrder invOrder)
        {
            // Declare
            // N/A

            // Initialize
            // N/A

            // Validate
            // N/A

            // Mainline
            EmailDepartment(invOrder);

            // Format Results
            // N/A

            // Return
            return Database.DatabaseManager.Instance.DBAddInventory(invOrder);
        }

        /// <summary>
        /// Creates and sends email using properties in InventoryOrder
        /// </summary>
        /// <param name="invOrder">InventoryOrder class object</par
        #region Other Email Code
       public static void OnlineMail()
       {
                
        MailAddress to = new MailAddress ("wscspec60683@gmail.com", "Specialist");
        message.Subject = ("Inventory order purchase made");
        message.SubjectEncoding = System.Text.Encoding.UTF8;
        MailAddress From = new MailAddress("wscclerk60683@gmail.com", "WSC Clerk Automated",System.Text.Encoding.UTF8);
        MailMessage message = new MailMessage(from, to);
        message.body = "The order you requested for inventory ID "+ invOrder.InventoryId + ", has been ordered from our supplier. Details below";
        message.body += System.Environment.NewLine;
        message.body += "Inventory ID: "+ invOrder.InventoryId;
        message.body += System.Environment.NewLine;
        message.body += "Quantity Ordered: " + invOrder.Quantity;
        message.body += System.Environment.NewLine;
        message.body += "Quantity Ordered: " + invOrder.Quantity;
        message.body += System.Environment.NewLine;
        message.body += "Expected Delivery Date: "+ invOrder.ArrivalDate;
        message.BodyEncoding =  System.Text.Encoding.UTF8;

        SmtpClient smtp = new SmtpClient("stmp.gmail.com");
        smtp.Send(message);
       }
#endregion

        private void EmailDepartment(Inventory.InventoryOrder invOrder)
        {
            // Create Email
            var fromAddress = new MailAddress("wscclerk60683@gmail.com"
                , "WSC Clerk Automated");
            var toAddress = new MailAddress("wscspec60683@gmail.com"
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
#endregion
    };
}