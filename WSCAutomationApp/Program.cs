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
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	};
}