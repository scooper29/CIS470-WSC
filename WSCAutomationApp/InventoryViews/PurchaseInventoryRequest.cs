using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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
            MailAddress from = new MailAddress("Clerk@WSC.com");
            MailAddress to = new MailAddress("Specialist@WSC.com");
            MailMessage message = new MailMessage(from, to);

            message.Subject = "Inventory order purchase made";
            message.Body = @"The order you requested for inventory ID " 
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

            SmtpClient client = new SmtpClient(server); //NEED SERVER

            // Attempt to send email
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this
                    , "Exception caught while attempting to send email in btnSave_Click(): {0}"
                    , "email send error"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                return;
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