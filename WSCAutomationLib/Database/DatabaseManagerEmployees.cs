using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;

namespace WSCAutomation.Database
{
	using Employees;

	partial class DatabaseManager
	{
		#region Employee table column names
		const string EMPLOYEE_TABLE = "Employee";

		const string EMPLOYEE_ID = "EmployeeID";
		const string EMPLOYEE_ACCESS_CODE = "AccessCodeID";
		const string EMPLOYEE_FIRST_NAME = "Emp_FirstName";
		const string EMPLOYEE_LAST_NAME = "Emp_LastName";
		const string EMPLOYEE_EMAIL = "Emp_Email";
		const string EMPLOYEE_USER_ID = "Emp_UserID";
		const string EMPLOYEE_PASSWORD = "Emp_Password";
		#endregion

		/// <summary>Build the INSERT or UPDATE DbCommand for a given Employee object</summary>
		/// <param name="connection">Current connection to the DB</param>
		/// <param name="type">SQL query to perform</param>
		/// <param name="emp">Employee data to use in the query</param>
		/// <returns>A DbCommand which is able to INSERT or UPDATE the DB with the given Employee data</returns>
		static SqlCeCommand BuildModificationQuery(SqlCeConnection connection, ModificationQueryType type,
			Employee emp)
		{
			var query = new ModificationQueryBuilder(connection, type, EMPLOYEE_TABLE);

			query.AddIdParameter(EMPLOYEE_ID, "empId", emp.Id);

			// Internally, AccessCode is represented by an Enum, but the DB uses an NCHAR.
			// SqlServerCe's code treats NCHAR data as a string.
			// DbCommand uses reflection to determine how to serialize an object to the DB
			// Hence we explicitly cast Access to 'char' here and then put it in string form.
			// See Employees\AccessCode.cs for more details
			query.AddParameter(EMPLOYEE_ACCESS_CODE, "accessCode", ((char)emp.Access).ToString());

			query.AddParameter(EMPLOYEE_FIRST_NAME, "firstName", emp.FirstName);
			query.AddParameter(EMPLOYEE_LAST_NAME, "lastName", emp.LastName);
			query.AddParameter(EMPLOYEE_EMAIL, "email", emp.Email);

			query.AddParameter(EMPLOYEE_USER_ID, "userId", emp.UserName);
			query.AddParameter(EMPLOYEE_PASSWORD, "password", emp.Password);

			return query.ToDbCommand();
		}

		/// <summary>Try and perform an INSERT or UPDATE query on an Employee object</summary>
		/// <param name="type">SQL query to perform</param>
		/// <param name="emp">Employee data to use in the query</param>
		/// <returns>True if the query executed successfully</returns>
		object PerformModificationQuery(ModificationQueryType type,
			Employee emp)
		{
			object result = null;

			// open a connection to the SQL DB
			using (var connection = OpenConnection())
			{
				var command = BuildModificationQuery(connection, type, emp);

				// try to perform the modification, committing it if successful
				try {
					result = ExecuteModification(command, type);

					command.Transaction.Commit();
				} catch(Exception ex) {
					// rollback the changes before we re-throw the exception
					command.Transaction.Rollback();

					throw ex;
				}
			}

			return result;
		}

		/// <summary>Insert the employee data into a new record in the DB</summary>
		/// <param name="emp">Employee data to insert</param>
		/// <returns>ID of the successfully INSERT-ed Employee, or -1</returns>
		public int DBAddEmployee(Employee emp)
		{
			object idObj = PerformModificationQuery(ModificationQueryType.Insert, emp);

			// if the ID object is not null, then it executed successfully.
			// Cast the object to the EmployeeID type (int) and return it
			if (idObj != null)
			{
				emp.Id = Convert.ToInt32(idObj);

				return emp.Id;
			}

			return -1;
		}

		/// <summary>Update the employee data of an existing record in the DB</summary>
		/// <param name="emp">Employee to update</param>
		/// <returns>True if the update operation was successful</returns>
		public bool DBEditEmployee(Employee emp)
		{
			var rowsAffected = (int)PerformModificationQuery(ModificationQueryType.Update, emp);

			return rowsAffected == 1;
		}

		/// <summary>
		/// Search the DB for a collection of <see cref="Employee"/>s based a set of search parameters
		/// </summary>
		/// <param name="employeeId">Employee ID to use in the search. Use -1 to skip this search parameter</param>
		/// <param name="userId">Employee's user name to use in the search. Use an empty string to skip this search parameter</param>
		/// <param name="asEmployeeObjectsOnly"></param>
		/// <returns>A collection of 0 or more <see cref="Employee"/>s that match the search parameters</returns>
		public List<Employee> DBGetEmployees(int employeeId = -1, string userId = "", bool asEmployeeObjectsOnly = true)
		{
			VerifySearchParameter(employeeId, "employeeId");
			VerifySearchParameter(userId, "userId");

			var results = new List<Employee>();

			// open a connection to the SQL DB
			using (var connection = OpenConnection())
			{
				// create a SELECT query builder for the Employee table
				var command = new SelectQueryBuilder(connection, EMPLOYEE_TABLE);

				// Add employeeId parameter
				if (!SkipSearchParameter(employeeId))
					command.AddParameter(EMPLOYEE_ID, "employeeId", employeeId);

				// Add userId parameter
				if (!SkipSearchParameter(userId))
					command.AddParameter(EMPLOYEE_USER_ID, "userId", userId);

				using (var reader = command.ToDbCommand().ExecuteReader())
				{
					// each Read() fetches the next record that matches our SELECT query
					// build our code object from each record and add it to the list of results
					while (reader.Read())
					{
						// NCHAR is read as a 'string', so we have to convert to a string first then access the first, and only, character
						var accessString = (string)reader[EMPLOYEE_ACCESS_CODE];
						var access = (AccessCode)accessString[0];

						var emp = Employee.Create(access, asEmployeeObjectsOnly);
						emp.Id = (int)reader[EMPLOYEE_ID];
						
						emp.FirstName = (string)reader[EMPLOYEE_FIRST_NAME];
						emp.LastName = (string)reader[EMPLOYEE_LAST_NAME];
						emp.Email = (string)reader[EMPLOYEE_EMAIL];

						emp.UserName = (string)reader[EMPLOYEE_USER_ID];
						emp.Password = (string)reader[EMPLOYEE_PASSWORD];

						results.Add(emp);
					}
				}
			}

			return results;
		}
	};
}