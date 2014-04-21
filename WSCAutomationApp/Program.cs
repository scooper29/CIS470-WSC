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

		/// <summary>Instance of the currently running MainForm</summary>
		internal static MainForm MainForm { get; set; }

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
			Application.Run(Program.MainForm = new MainForm());
		}

		/// <summary>
		/// Event handler for TextBox's KeyPress to limit input to digits and backspace (for deleting previous input)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>http://stackoverflow.com/a/14659892</remarks>
		public static void OnTextBoxKeyPressAllowNumbersOnly(object sender, KeyPressEventArgs e)
		{
			if (!(char.IsDigit(e.KeyChar) && (e.KeyChar == (char)Keys.Back)))
				e.Handled = true;
		}

		public static void StringToBoolean(object sender, ConvertEventArgs e)
		{
			if (e.DesiredType != typeof(bool)) return;
			if (e.Value.GetType() != typeof(string)) return;

			string str = (string)e.Value;
			e.Value = bool.Parse(str);
		}
		static void BooleanToString(object sender, ConvertEventArgs e)
		{
			if (e.DesiredType != typeof(string)) return;
			if (e.Value.GetType() != typeof(bool)) return;

			bool b = (bool)e.Value;
			e.Value = b.ToString();
		}
	};
}