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

		public Employees.Admin AsAdmin { get {
			System.Diagnostics.Debug.Assert(Authority == UserAuthorityType.Admin);

			return (Employees.Admin)EmployeeData;
		} }

		public Employees.Manager AsManager { get {
			System.Diagnostics.Debug.Assert(Authority == UserAuthorityType.Manager);

			return (Employees.Manager)EmployeeData;
		} }

		public Employees.Sales AsSales { get {
			System.Diagnostics.Debug.Assert(Authority == UserAuthorityType.Sales);

			return (Employees.Sales)EmployeeData;
		} }

		public Employees.Specialist AsSpecialist { get {
			System.Diagnostics.Debug.Assert(Authority == UserAuthorityType.Specialist);

			return (Employees.Specialist)EmployeeData;
		} }

		public Employees.Clerk AsStockClerk { get {
			System.Diagnostics.Debug.Assert(Authority == UserAuthorityType.StockClerk);

			return (Employees.Clerk)EmployeeData;
		} }
	};
}