using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSCAutomation.App
{
	public partial class EnterEditOrderQualityDialog : WSCAutomation.App.EnterEditRecordFormBase
	{
		#region Grade formatting
		static readonly string[] GradeComboItems = new string[] {
			"Failed",
			"Pass",
		};
		static void StringToGrade(object sender, ConvertEventArgs e)
		{
			if (e.DesiredType != typeof(bool)) return;
			if (e.Value.GetType() != typeof(string)) return;

			string str = (string)e.Value;
			bool pass = Array.IndexOf(GradeComboItems, str) == 1;

			e.Value = pass;
		}
		static void GradeToString(object sender, ConvertEventArgs e)
		{
			if (e.DesiredType != typeof(string)) return;
			if (e.Value.GetType() != typeof(bool)) return;

			bool pass = (bool)e.Value;
			int gradeIndex = pass ? 1 : 0;
			e.Value = GradeComboItems[gradeIndex];
		}
		#endregion

		Orders.Order parentOrder;
		Orders.QualityCheckList qualityData;

		public EnterEditOrderQualityDialog()
		{
			InitializeComponent();

			base.recordKindName = "Order Quality Check List";

			// the ID of the Quality log isn't useful to the user, don't show it
			base.lblRecordId.Visible = false;
			base.txtRecordId.Visible = false;

			cbxGrade.Items.AddRange(GradeComboItems);
		}

		void DataBindToQualityData()
		{
			SetRecordIdDataBinding(qualityData);

			var gradeBinding = cbxGrade.DataBindings.Add("Text", qualityData, "Pass");
			gradeBinding.Format += new ConvertEventHandler(GradeToString);
			gradeBinding.Parse += new ConvertEventHandler(StringToGrade);

			txtQualityDescription.DataBindings.Add("Text", qualityData, "Description");
		}

		public override void SetEnterEditData(object enterEditData)
		{
			if (qualityData != null)
				throw new InvalidOperationException("data was previously set already");

			var quality = enterEditData as Orders.QualityCheckList;

			if (quality == null)
				throw new ArgumentNullException("enterEditData");

			qualityData = quality;
			DataBindToQualityData();
		}
		public void SetEnterEditData(Orders.QualityCheckList enterEditData, Orders.Order order)
		{
			if (order.Id == -1)
				throw new ArgumentOutOfRangeException("an uncommitted order tried get reviewed for quality");

			parentOrder = order;

			SetEnterEditData(enterEditData);
		}

		public override int GetRecordIdValue()
		{
			return qualityData.Id;
		}

		protected override bool PreSaveValidation()
		{
			bool valid = true;

			if (!qualityData.Pass && qualityData.Description == "")
			{
				valid = false;
				ShowValidationErrorMessage("The grade is fail, please provide a value for Description");
			}

			return valid;
		}

		protected override int AddEnterEditData()
		{
			var managerAccess = Program.CurrentUser.AsManager;

			parentOrder.QualityId = managerAccess.PerformQualityCheck(parentOrder.Id, qualityData);

			return qualityData.Id;
		}
		protected override bool SaveEnterEditData()
		{
			var managerAccess = Program.CurrentUser.AsManager;

			return managerAccess.ReevaluateQualityCheck(parentOrder.Id, qualityData);
		}
	};
}