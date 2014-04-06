using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSCAutomation.App
{
    public partial class EnterEditCustomerForm : WSCAutomation.App.EnterEditRecordFormBase
    {
        public EnterEditCustomerForm()
        {
            InitializeComponent();

			base.recordKindName = "Customer";
        }
    };
}