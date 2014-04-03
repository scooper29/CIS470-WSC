
namespace WSCAutomation.App
{
	/// <summary>The ways in which <see cref="SearchRecordsDialogBase"/> can be used</summary>
	public enum SearchRecordsDialogMode
	{
		/// <summary>Dialog is for querying the database for Viewing or Editing the record</summary>
		Query,

		/// <summary>Dialog is for finding a specific record, for populating a FK in a EnterEdit form</summary>
		Selection,
	};
}