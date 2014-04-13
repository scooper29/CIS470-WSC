using System;

namespace WSCAutomation.Employees
{
	/// <summary>Code representation of the AccessCode table's IDs</summary>
	/// <remarks>
	/// The AccessCode table in the DB uses NCHAR for the ID of AccessCode records.
	/// For our business layer, we abstract this implementation detail using this Enum.
	/// Each member of the Enum is set to the character value (truncated to a byte) that
	/// is associated with the given access
	/// 
	/// Thus, when going to the DB, AccessCode values should be casted to 'char', then ToString()'d
	/// And when coming from the DB, column values should be casted to 'string' first, then 
	/// the first character should be casted to AccessCode
	/// 
	/// The DB's AccessCode table should be initialized with these values, except
	/// for 'None'.
	/// </remarks>
	public enum AccessCode : byte
	{
		/// <remarks>Equivalent to a NULL DB value</remarks>
		None = 0,

		Admin =			(byte)'a',
		Manager =		(byte)'m',
		Sales =			(byte)'s',
		Specialist =	(byte)'w', // w, as in "worker"
		StockClerk =	(byte)'c',
	};
}