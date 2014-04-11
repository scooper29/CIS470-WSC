using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;

namespace WSCAutomation.Database
{
	using Employees;

	partial class DatabaseManager
	{
		#region AccessCode table column names
		const string ACCESS_CODE_TABLE = "AccessCode";

		const string ACCESS_CODE_ID = "AccessCodeID";
		const string ACCESS_CODE_DESC = "Access_Desc";

		const string ACCESS_CODE_PARAM_ID = "accessId";
		const string ACCESS_CODE_PARAM_DESC = "accessDesc";
		#endregion

		/// <summary>
		/// Set the INSERT parameters in the pre-filled DbCommand based the <paramref name="code"/> and execute the INSERT
		/// </summary>
		/// <param name="command">pre-filled INSERT command for the AccessCode table</param>
		/// <param name="code">The code we are to add to the DB</param>
		/// <returns>True if the command executed successfully</returns>
		static bool DBAddAccessCode(SqlCeCommand command, AccessCode code)
		{
			command.Parameters[ACCESS_CODE_PARAM_ID].Value = (char)code;
			command.Parameters[ACCESS_CODE_PARAM_DESC].Value = code.ToString();

			return command.ExecuteNonQuery() == 1;
		}
		/// <summary>
		/// Add all the usable <see cref="Employees.AccessCode"/> members to the database
		/// </summary>
		/// <returns>True if all the different codes were added successfully</returns>
		public bool InitializeAccessCodes()
		{
			bool success = false;

			// open a connection to the SQL DB
			using (var connection = OpenConnection())
			{
				var query = new ModificationQueryBuilder(connection, ModificationQueryType.Insert,
					ACCESS_CODE_TABLE);

				// initialize the INSERT parameters, but with bunk values (will be reset in DBAddAccessCode)
				query.AddParameter(ACCESS_CODE_ID, ACCESS_CODE_PARAM_ID, '\0');
				query.AddParameter(ACCESS_CODE_DESC, ACCESS_CODE_PARAM_DESC, string.Empty);

				var command = query.ToDbCommand();
				try {
					success = true;
					success &= DBAddAccessCode(command, AccessCode.Admin);
					success &= DBAddAccessCode(command, AccessCode.Manager);
					success &= DBAddAccessCode(command, AccessCode.Sales);
					success &= DBAddAccessCode(command, AccessCode.Specialist);
					success &= DBAddAccessCode(command, AccessCode.StockClerk);

					command.Transaction.Commit();
				} catch(Exception ex) {
					command.Transaction.Rollback();
					success = false;

					throw ex;
				}
			}

			return success;
		}
	};
}