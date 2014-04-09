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