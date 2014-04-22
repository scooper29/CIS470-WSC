using System;
using System.Data;
using System.Data.SqlServerCe;

namespace WSCAutomation.Database
{
	/// <summary>
	/// Utility class to wrap the mundane details of building a DbCommand for SELECT-ing
	/// a records based on search parameters
	/// </summary>
	sealed class SelectQueryBuilder
	{
		public SqlCeTransaction Transaction { get { return command.Transaction; } }

		SqlCeCommand command;
		System.Text.StringBuilder query;
		/// <summary>True when a call to AddParameter has been previously made</summary>
		bool hasPreviousParameter;

		/// <summary>Construct the SELECT query builder</summary>
		/// <param name="connection">Connrection the command will be performed on</param>
		/// <param name="tableName">Name of the DB table which will be used in the SELECT</param>
		public SelectQueryBuilder(SqlCeConnection connection, string tableName)
		{
			command = connection.CreateCommand();
			command.Transaction = connection.BeginTransaction();

			query = new System.Text.StringBuilder();
			query.AppendFormat("SELECT * FROM {0} ", tableName);
		}

		/// <summary>Get a DbCommand which can be used for perform the SELECT query</summary>
		/// <returns></returns>
		public SqlCeCommand ToDbCommand()
		{
			if (!string.IsNullOrEmpty(command.CommandText))
				throw new InvalidOperationException("ToDbCommand() should only be called exactly once!");

			command.CommandText = query.ToString();

			return command;
		}

		/// <summary>Add a search parameter and value that corresponds to a given table's column</summary>
		/// <param name="columnName">The column name as it appears in the table we're SELECT-ing on</param>
		/// <param name="parameterName">The parameter name to use in the DbCommand</param>
		/// <param name="parameterValue">The value to use in the DbCommand</param>
		/// <remarks>Multiple parameters will be WHERE conditioned with AND</remarks>
		public void AddParameter(string columnName, string parameterName, object parameterValue,
			bool useLikeOperator = false)
		{
			// convention is to prefix DbCommand parameter names with '@'
			parameterName = "@" + parameterName;

			// this is the first parameter we're adding, so begin a WHERE clause
			if (command.Parameters.Count == 0)
				query.Append(" WHERE");

			if (hasPreviousParameter)
				query.Append(" AND");

			// figure out the WHERE condition operator we need to use
			string conditionOperator = "=";
			if (useLikeOperator)
				conditionOperator = "LIKE";

			// append the query with the WHERE condition
			query.AppendFormat(" {0} {1} {2}", columnName, conditionOperator, parameterName);
			// add the parameter to the DbCommand's parameters list
			command.Parameters.AddWithValue(parameterName, parameterValue);

			// we've added a parameter, so any further calls will need AND appended
			hasPreviousParameter = true;
		}
	};
}