using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace WSCAutomation.App
{
    public partial class PurchaseInventoryRequest : WSCAutomation.App.EnterEditRecordFormBase
    {
        public PurchaseInventoryRequest()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Rough logic, will clean up when related areas of database access completed.
            // Declare
            DateTime orderDate;
            DateTime deliveryDate;

            decimal inventoryQTY;

            string inventoryID;


            // Initialize
            inventoryID = txbInvReqID.Text;
            inventoryQTY = upDownInventoryQty.Value;

            orderDate = dateTimePickerOrderDate.Value;
            deliveryDate = dateTimePickerDelieveryDate.Value;

            // Validate

            // Make sure entered inventory ID is the right length
            if (inventoryID.Length != 4)
            {
                MessageBox.Show(this
                    , "Invalid inventory ID length. Please enter a four digit inventory ID."
                    , "Inventory ID length error"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                return;
            }

            // Make sure the entered inventory ID is an integer
            try
            {
                int i = int.Parse(inventoryID);
            }
            catch
            {
                MessageBox.Show(this
                    , "Invalid inventory ID. Please enter a four digit inventory ID."
                    , "Invalid inventory ID error"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                return;
            }

            // make sure delivery date is later than the order date
            if (orderDate >= deliveryDate)
            {
                MessageBox.Show(this
                    , "Please make sure the delivery date comes after the order date."
                    , "Invalid order/delivery date error"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                return;
            }
            
            // Mainline

            // Create email
            var fromAddress = new MailAddress("wscclerk60683@gmail.com"
                , "WSC Clerk Automated");
            var toAddress = new MailAddress("wscspec60683@gmail.com"
                , "Specialist");
            const string FROM_PASSWORD = "senprojCIS470";
            const string SUBJECT = "Inventory order purchase made";
            string body = "The order you requested for inventory ID "
                + inventoryID
                + "has been ordered from our supplier. Details below."
                + System.Environment.NewLine
                + System.Environment.NewLine
                + "Inventory ID: "
                + inventoryID
                + System.Environment.NewLine
                + "Quantity Ordered: "
                + inventoryQTY
                + System.Environment.NewLine
                + "Order Date: "
                + orderDate
                + System.Environment.NewLine
                + "Expected Delivery Date: "
                + deliveryDate;

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
                , Body = body
            })
            {
                smtp.Send(message);
            }

            // Format Results
            // DATABASE ACCESS PROCEDURES FOR ORDERING INVENTORY COMPLETION REQUIRED


            /*if dateTimePickerOrderDate >= dateTimePickerDelieveryDate
             * then error "InVaild Delievery Date"
             * else
             * txbInvReqID 
             * upDownInventoryQty
             * MailMessage mailMsg = new MailMessage(); 
             * MailAddress mailAddress = null; 
             * mailMsg.To.Add(Specialist@WSC.com);
             * 
             * mailAddress =new MailAddress(Muhilan@maa.com.my); 
             * mailMsg.From = mailAddress;
             * mailMsg.Subject = "Automatic mailing"; 
             * MailMsg.Body = "Please order upDownInventoryQty of txbInvReqID";
             * SmtpClient smtpClient = new SmtpClient("97.0.0.6", Convert.ToInt32(25)); 
             * System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(); 
             * smtpClient.Credentials = credentials; 
             * 
             * smtpClient.Send(mailMsg);
            */
        }   
    };
}