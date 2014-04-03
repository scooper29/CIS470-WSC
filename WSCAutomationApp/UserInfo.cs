using System;

namespace WSCAutomation.App
{
	// TODO: When the Employees.Employee class comes online, update EmployeeData's object type

	/// <summary>State data representing a user of this app</summary>
	internal class UserInfo
	{
		/// <summary>The <see cref="Employees.Employee"/> object of this user</summary>
		public object/*Employees.Employee*/ EmployeeData { get; private set; }

		/// <summary>The authority which this user has for interfacing with the app</summary>
		public UserAuthorityType Authority { get; private set; }

		public UserInfo(object employeeData)
		{
			// TODO: When the Employees.Employee class comes online
		}
		// HACK: temporary constructor, until the Employee class comes online
		public UserInfo(UserAuthorityType authority)
		{
			Authority = authority;
		}
	};
}