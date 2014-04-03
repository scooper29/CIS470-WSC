
namespace WSCAutomation.App
{
	/// <summary>The ways in which <see cref="EnterEditRecordFormBase"/> can be used</summary>
	public enum EnterEditRecordFormMode
	{
		/// <summary>Form is for presenting a read-only view of a record</summary>
		View,

		/// <summary>Form is for editing a pre-existing record</summary>
		Edit,

		/// <summary>Form is for creating a new record that will be saved to the database</summary>
		Create,
	};
}