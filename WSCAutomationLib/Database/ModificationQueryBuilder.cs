using System;
using System.Data;
using System.Data.SqlServerCe;

namespace WSCAutomation.Database
{
	/// <summary>The types of "modification" queries we can perform</summary>
	enum ModificationQueryType
	{
		/// <summary>Modification is for an INSERT query</summary>
		Insert,
		/// <summary>Modification is for an UPDATE query</summary>
		Update,
	};

	/// <summary>
	/// Utility class to wrap the mundane details of building a DbCommand for INSERT or UPDATE-ing
	/// a record
	/// </summary>
	sealed class ModificationQueryBuilder
	{
		public SqlCeTransaction Transaction { get { return command.Transaction; } }

		SqlCeCommand command;
		System.Text.StringBuilder query;
		ModificationQueryType queryType;
		/// <summary>For INSERT queries only, contains the list of column names to be wrapped in ()</summary>
		System.Text.StringBuilder columnsList;
		/// <summary>For INSERT queries only, contains the list of parameter names to be wrapped in VALUES()</summary>
		System.Text.StringBuilder parametersList;
		/// <summary>For UPDATE queries only, contains the WHERE condition to match a </summary>
		string whereClause;
		/// <summary>True when a call to AddParameter has been previously made</summary>
		bool hasPreviousParameter;

		/// <summary>Construct the INSERT/UPDATE query builder</summary>
		/// <param name="connection">Connrection the command will be performed on</param>
		/// <param name="type">SQL query to perform</param>
		/// <param name="tableName">Name of the DB table which will be used in the modification query</param>
		public ModificationQueryBuilder(SqlCeConnection connection, ModificationQueryType type, string tableName)
		{
			command = connection.CreateCommand();
			command.Transaction = connection.BeginTransaction();

			query = new System.Text.StringBuilder();
			queryType = type;

			if (queryType == ModificationQueryType.Insert)
			{
				query.AppendFormat("INSERT into {0}", tableName);
				columnsList = new System.Text.StringBuilder();
				parametersList = new System.Text.StringBuilder();
			}
			else if (queryType == ModificationQueryType.Update)
			{
				query.AppendFormat("UPDATE {0} SET ", tableName);
				whereClause = "";
			}
		}

		/// <summary>Get a DbCommand which can be used for perform the SELECT query</summary>
		/// <returns></returns>
		public SqlCeCommand ToDbCommand()
		{
			if (!string.IsNullOrEmpty(command.CommandText))
				throw new InvalidOperationException("ToDbCommand() should only be called exactly once!");

			if (queryType == ModificationQueryType.Insert)
			{
				query.AppendFormat("({0}) ", columnsList.ToString());
				query.AppendFormat("VALUES({0})", parametersList.ToString());
			}
			else if (queryType == ModificationQueryType.Update)
			{
				if (whereClause == "")
					throw new InvalidOperationException("Someone forgot to call AddUpdateWhereClause");

				query.Append(whereClause);
			}

			command.CommandText = query.ToString();

			return command;
		}

		/// <summary>Add a query parameter and value that corresponds to a given table's column</summary>
		/// <param name="columnName">The column name as it appears in the table we're modifying</param>
		/// <param name="parameterName">The parameter name to use in the DbCommand</param>
		/// <param name="parameterValue">The value to use in the DbCommand</param>
		public void AddParameter(string columnName, string parameterName, object parameterValue)
		{
			// convention is to prefix DbCommand parameter names with '@'
			parameterName = "@" + parameterName;

			// if there was a previous parameter, the string contains a comma, else it's empty
			string commaOrBlank = hasPreviousParameter ? "," : "";

			if (queryType == ModificationQueryType.Insert)
			{
				columnsList.AppendFormat("{0}{1}", commaOrBlank, columnName);
				parametersList.AppendFormat("{0}{1}", commaOrBlank, parameterName);
			}
			else if (queryType == ModificationQueryType.Update)
			{
				query.AppendFormat("{0} {1} = {2}", commaOrBlank, columnName, parameterName);
			}

			command.Parameters.AddWithValue(parameterName, parameterValue);

			// we've added a parameter, so any further calls will need a comma added
			hasPreviousParameter = true;
		}

		/// <summary>Add a query parameter and value that corresponds to a given table's nullable FK column</summary>
		/// <param name="columnName">The nullable FK column name as it appears in the table we're modifying</param>
		/// <param name="parameterName">The parameter name to use in the DbCommand</param>
		/// <param name="parameterValue">The value to use in the DbCommand</param>
		public void AddNullableFkParameter(string columnName, string parameterName, int parameterValue)
		{
			object idObj = DBNull.Value;
			if (parameterValue != -1)
				idObj = parameterValue;

			AddParameter(columnName, parameterName, parameterValue);
		}

		/// <summary>Adds the WHERE clause details for UPDATE queries</summary>
		/// <param name="idColumnName">The column name of the table's ID</param>
		/// <param name="idParameterName">The parameter name to use in the DbCommand</param>
		/// <param name="id">The ID of the record we're UPDATE-ing</param>
		void AddUpdateWhereClause(string idColumnName, string idParameterName, object id)
		{
			// convention is to prefix DbCommand parameter names with '@'
			idParameterName = "@" + idParameterName;

			if (queryType != ModificationQueryType.Update)
				throw new InvalidOperationException("Can only add WHERE clause in UPDATE queries");

			whereClause = string.Format(" WHERE {0} = {1}", idColumnName, idParameterName);

			command.Parameters.AddWithValue(idParameterName, id);
		}

		/// <summary>Add the ID parameter and decide how to handle it for the modification type this query builder is for</summary>
		/// <param name="idColumnName">The column name of the table's ID</param>
		/// <param name="idParameterName">The parameter name to use in the DbCommand</param>
		/// <param name="id">The ID of the record we're UPDATE-ing</param>
		/// <remarks>
		/// If we're performing an INSERT modification, this does nothing.
		/// However, if we're performing an UPDATE modification, this sets the ID to be the WHERE clause in the UPDATE.
		/// </remarks>
		public void AddIdParameter(string idColumnName, string idParameterName, object id)
		{
			if (queryType == ModificationQueryType.Update)
				AddUpdateWhereClause(idColumnName, idParameterName, id);
		}
	};
}