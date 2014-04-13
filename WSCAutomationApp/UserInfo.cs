using System;

namespace WSCAutomation.App
{
	/// <summary>State data representing a user of this app</summary>
	internal class UserInfo
	{
		/// <summary>The <see cref="Employees.Employee"/> object of this user</summary>
		public Employees.Employee EmployeeData { get; private set; }

		/// <summary>The authority which this user has for interfacing with the app</summary>
		public UserAuthorityType Authority { get; private set; }

		public UserInfo(Employees.Employee employeeData)
		{
			EmployeeData = employeeData;

			switch (EmployeeData.Access)
			{
				case Employees.AccessCode.Admin:
					Authority = UserAuthorityType.Admin;
					break;

				case Employees.AccessCode.Manager:
					Authority = UserAuthorityType.Manager;
					break;

				case Employees.AccessCode.Sales:
					Authority = UserAuthorityType.Sales;
					break;

				case Employees.AccessCode.Specialist:
					Authority = UserAuthorityType.Specialist;
					break;

				case Employees.AccessCode.StockClerk:
					Authority = UserAuthorityType.StockClerk;
					break;

				default:
					Authority = UserAuthorityType.None;
					break;
			}
		}
		// HACK: temporary constructor, until the Employee class comes online
		public UserInfo(UserAuthorityType authority)
		{
			Authority = authority;
		}
	};
}