using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WSCAutomation.App
{
	public partial class LogInDialog : Form
	{
		public LogInDialog()
		{
			InitializeComponent();
		}
		/// <summary>Provided user name</summary>
		public string UserName { get { return txtUserName.Text; } }
		/// <summary>Provided user password</summary>
		public string Password { get { return txtPassword.Text; } }

		private void OnLogInClick(object sender, EventArgs e)
		{
		}
	};
}