using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WSCAutomation.App
{
	static class Program
	{
		#region States list
		public static readonly string[] ListOfStates = new string[] {
			"",
			"AL",
			"AK",
			"AZ",
			"AR",
			"CA",
			"CO",
			"CT",
			"DE",
			"DC",
			"FL",
			"GA",
			"HI",
			"ID",
			"IL",
			"IN",
			"IA",
			"KS",
			"KY",
			"LA",
			"ME",
			"MD",
			"MA",
			"MI",
			"MN",
			"MS",
			"MO",
			"MT",
			"NE",
			"NV",
			"NH",
			"NJ",
			"NM",
			"NY",
			"NC",
			"ND",
			"OH",
			"OK",
			"OR",
			"PA",
			"RI",
			"SC",
			"SD",
			"TN",
			"TX",
			"UT",
			"VT",
			"VA",
			"WA",
			"WV",
			"WI",
			"WY",
		};
		#endregion

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
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
				e.Handled = true;
		}
		public static void OnTextBoxKeyPressAllowNumbersOnlyAndNegativeSign(object sender, KeyPressEventArgs e)
		{
			OnTextBoxKeyPressAllowNumbersOnly(sender, e);

			// HACK: allow negative sign, to support "-1"
			bool keyIsMinus = e.KeyChar == (char)Keys.Subtract || e.KeyChar == '-';
			if (sender is TextBox && ((TextBox)sender).SelectionStart == 0 && keyIsMinus)
				e.Handled = false;
		}

		#region Boolean ComboBox binding
		public static readonly string[] BooleanComboItems = new string[] {
			"False",
			"True",
		};
		public static void StringToBoolean(object sender, ConvertEventArgs e)
		{
			if (e.DesiredType != typeof(bool)) return;
			if (e.Value.GetType() != typeof(string)) return;

			string str = (string)e.Value;
			e.Value = bool.Parse(str);
		}
		public static void BooleanToString(object sender, ConvertEventArgs e)
		{
			if (e.DesiredType != typeof(string)) return;
			if (e.Value.GetType() != typeof(bool)) return;

			bool b = (bool)e.Value;
			e.Value = b.ToString();
		}
		public static void SetBooleanComboBoxBinding(ComboBox control,
			object dataSource, string dataMember)
		{
			var binding = control.DataBindings.Add("Text", dataSource, dataMember);
			binding.Format += new ConvertEventHandler(Program.BooleanToString);
			binding.Parse += new ConvertEventHandler(Program.StringToBoolean);
		}
		#endregion

		#region NumericUpDown arrow fixing
		// fix found at:
		//http://www.codeproject.com/Messages/2079588/Fix-without-replacing-the-control.aspx

		/// <summary>
		/// Fixes behavior of NumericUpDown control by disabling or enabling up and down buttons
		/// according to its ReadOnly property.
		/// </summary>
		/// <param name="numericUpDown">NumericUpDown control to fix.</param>
		/// <exception cref="ArgumentNullException">Thrown when numericUpDown is set to null.</exception>
		static public void Fix(NumericUpDown numericUpDown)
		{
			if (numericUpDown == null)
				throw new ArgumentNullException("numericUpDown");

			foreach (Control control in numericUpDown.Controls)
			{
				TextBox textBox = control as TextBox;

				if (textBox != null)
				{
					textBox.ReadOnlyChanged -= numericUpDown_ReadOnlyChanged; // in case it was already fixed
					textBox.ReadOnlyChanged += numericUpDown_ReadOnlyChanged;
					numericUpDown_ReadOnlyChanged(textBox, EventArgs.Empty);
				}
			}
		}

		static void numericUpDown_ReadOnlyChanged(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			NumericUpDown numericUpDown = (NumericUpDown)textBox.Parent;

			foreach (Control control in numericUpDown.Controls)
				if (control.GetType().Name == "UpDownButtons")
					control.Enabled = !textBox.ReadOnly;
		}
		#endregion

		public static TRecord UserSearchForRecord<TDialog, TRecord>(
			IWin32Window owner)
			where TDialog : SearchRecordsDialogBase, new()
			where TRecord : class
		{
			var searchDialog = new TDialog();
			searchDialog.SearchDialogMode = SearchRecordsDialogMode.Selection;
			if (searchDialog.ShowDialog(owner) == DialogResult.OK)
			{
				return searchDialog.SelectedRecord as TRecord;
			}

			return null;
		}
	};
}