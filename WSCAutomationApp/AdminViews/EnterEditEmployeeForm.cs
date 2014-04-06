using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSCAutomation.App
{
	public partial class EnterEditEmployeeForm : WSCAutomation.App.EnterEditRecordFormBase
	{
		public EnterEditEmployeeForm()
		{
			InitializeComponent();

			base.recordKindName = "User";
		}
	};
}