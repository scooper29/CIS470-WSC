using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WSCAutomation.App
{
	static class Program
	{
		/// <summary>User information of the Employee currently logged in</summary>
		internal static UserInfo CurrentUser { get; set; }

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// HACK: temporary way of setting up the database.
			// Will need to be removed for 'production'.
			// This needs to happen as the .SDF is copied from the Lib\Database\ folder
			// and thus should have NO records of any kind
			// NOTE: You need to "rebuild" the App project in order to start from a clean DB
			if (MessageBox.Show("Perform initial DB setup?", "WSC", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				var setup = new WSCAutomation.InitialSetup();
				setup.Perform();
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	};
}