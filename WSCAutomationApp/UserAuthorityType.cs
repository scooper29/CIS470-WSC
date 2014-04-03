
namespace WSCAutomation.App
{
	/// <summary>The broad authority types for system users which the View layer acknowledges</summary>
	public enum UserAuthorityType
	{
		/// <summary>Only for internal use (mainly UI prototyping). Should never encounter this in production</summary>
		None,
		/// <summary>User has Admin rights</summary>
		Admin,
		/// <summary>User has Operations Manager rights</summary>
		Manager,
		/// <summary>User has Sales rights</summary>
		Sales,
		/// <summary>User has Printing/Engraving Specialist rights</summary>
		Specialist,
		/// <summary>User has Stock Room Clerk rights</summary>
		StockClerk,
	};
}