using System;
using System.Data;
using System.Data.SqlServerCe;

namespace WSCAutomation.Database
{
	// NOTE: All OpenConnection() and DbCommand.ExecuteReader() statements should be wrapped in a "using()" statement.
	// If this sounds alien to you, see this StackOverflow answer for more: http://stackoverflow.com/a/10057380

	public partial class DatabaseManager
	{
		public static DatabaseManager Instance = new DatabaseManager();

		/// <summary>
		/// Private constructor so no one besides this class can create an instance
		/// </summary>
		private DatabaseManager()
		{

		}

		/// <summary>Open an <see cref="IDbConnection"/> to the WSC database</summary>
		/// <returns></returns>
		SqlCeConnection OpenConnection()
		{
			var connection = new SqlCeConnection(
				Properties.Settings.Default.WSCDatabaseConnectionString);

			connection.Open();

			return connection;
		}

		/// <summary>Perform the matching Execute() function with <paramref name="command"/> based on the modification type</summary>
		/// <param name="command">DbCommand to execute</param>
		/// <param name="type">SQL query to perform</param>
		/// <returns>
		/// INSERT: new record's ID. 
		/// UPDATE: number of rows affected.
		/// </returns>
		static object ExecuteModification(SqlCeCommand command, ModificationQueryType type)
		{
			if (type == ModificationQueryType.Insert)
			{
				if (command.ExecuteNonQuery() <= 0)
					return null;

				// create the command for getting the new record's ID
				// See: http://stackoverflow.com/questions/6479949/sqlceparameter-return-auto-id-primary-key
				// http://stackoverflow.com/questions/14244563/identity-returns-null-when-in-transaction-in-sql-compact-edition
				var idCommand = command.Connection.CreateCommand();
				idCommand.Transaction = command.Transaction;
				// IDENTITY is returned as a 'decimal' according to the stackoverflow answers
				idCommand.CommandText = "SELECT @@IDENTITY";

				// returns the 1st column of the 1st row returned by the query (should be the ID value)
				return (decimal)idCommand.ExecuteScalar();
			}
			else if (type == ModificationQueryType.Update)
			{
				// returns the number of rows affected
				return command.ExecuteNonQuery();
			}

			// should never get here...
			throw new InvalidOperationException(type.ToString());
		}

		#region VerifySearchParameter overloads
		/// <summary>Default test to see if the parameter is invalid for using in SELECT queries</summary>
		/// <param name="parameter"></param>
		/// <param name="parameterName"></param>
		/// <exception cref="ArgumentOutOfRangeException">If the parameter is less than -1</exception>
		static void VerifySearchParameter(int parameter, string parameterName)
		{
			if (parameter < -1)
				throw new ArgumentOutOfRangeException(parameterName);
		}

		/// <summary>Default test to see if the parameter is invalid for using in SELECT queries</summary>
		/// <param name="parameter"></param>
		/// <param name="parameterName"></param>
		/// <exception cref="ArgumentNullException">If the parameter is null</exception>
		static void VerifySearchParameter(string parameter, string parameterName)
		{
			if (parameter == null)
				throw new ArgumentNullException(parameterName);
		}
		#endregion

		#region SkipSearchParameter overloads
		/// <summary>Default test to see if the parameter should be skipped from being added to a SELECT query</summary>
		/// <param name="parameter"></param>
		/// <returns>True if <paramref name="parameter"/> is -1</returns>
		static bool SkipSearchParameter(int parameter)
		{
			return parameter == -1;
		}

		/// <summary>Default test to see if the parameter should be skipped from being added to a SELECT query</summary>
		/// <param name="parameter"></param>
		/// <returns>True if <paramref name="parameter"/> is an empty string</returns>
		static bool SkipSearchParameter(string parameter)
		{
			return parameter == "";
		}
		#endregion
	};
}