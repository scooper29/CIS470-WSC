using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;

namespace WSCAutomation.Database
{
    using Customers;

	partial class DatabaseManager
	{
        #region Customer table column names
        const string CUSTOMER_TABLE = "Customer";

        const string CUSTOMER_ID = "CustomerID";
        const string CUSTOMER_PAYMENT = "PaymentID";
        const string CUSTOMER_FIRST_NAME = "Cust_FirstName";
        const string CUSTOMER_LAST_NAME = "Cust_LastName";
        const string CUSTOMER_ADDRESS = "Cust_Address";
        const string CUSTOMER_CITY = "Cust_City";
        const string CUSTOMER_STATE = "Cust_State";
        const string CUSTOMER_ZIPCODE = "Cust_ZipCode";
        const string CUSTOMER_EMAIL = "Cust_Email";
        const string CUSTOMER_PHONE = "Cust_Phone";
        #endregion

        static SqlCeCommand BuildModificationQuery(SqlCeConnection connection, ModificationQueryType type,
            Customer cust)
        {
            var query = new ModificationQueryBuilder(connection, type, CUSTOMER_TABLE);

            query.AddIdParameter(CUSTOMER_ID, "custId", cust.Id);

			query.AddParameter(CUSTOMER_PAYMENT, "paymentId", cust.PaymentId);

            query.AddParameter(CUSTOMER_FIRST_NAME, "firstName", cust.FirstName);
            query.AddParameter(CUSTOMER_LAST_NAME, "lastName", cust.LastName);
            query.AddParameter(CUSTOMER_ADDRESS, "address", cust.Address);
            query.AddParameter(CUSTOMER_CITY, "city", cust.City);
            query.AddParameter(CUSTOMER_STATE, "state", cust.State);
            query.AddParameter(CUSTOMER_ZIPCODE, "zipcode", cust.ZipCode);
            query.AddParameter(CUSTOMER_EMAIL, "email", cust.Email);
            query.AddParameter(CUSTOMER_PHONE, "phone", cust.Phone);

            return query.ToDbCommand();
        }

        object PerformModificationQuery(ModificationQueryType type, Customer cust)
        {
            object result = null;

            // open a connection to the SQL DB
            using (var connection = OpenConnection())
            {
                var command = BuildModificationQuery(connection, type, cust);

                // try to perform the modification, committing it if successful
                try
                {
                    result = ExecuteModification(command, type);

                    command.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    // rollback the changes before we re-throw the exception
                    command.Transaction.Rollback();

                    throw ex;
                }
            }

            return result;
        }

		public int DBAddCustomer(Customer cust)
		{
            object idObj = PerformModificationQuery(ModificationQueryType.Insert, cust);

            if (idObj != null)
            {
                cust.Id = Convert.ToInt32(idObj);

                return cust.Id;
            }

            return -1;
  
		}

		public bool DBEditCustomer(Customer cust)
		{
            var rowsAffected = (int)PerformModificationQuery(ModificationQueryType.Update, cust);

            return rowsAffected == 1;
		}

        public List<Customer> DBGetCustomers(int customerId = -1, string cust_lastname = "")
        {
            VerifySearchParameter(customerId, "customerId");
            VerifySearchParameter(cust_lastname, "cust_lastname");

            var results = new List<Customer>();

            // open a connection to the SQL DB
            using (var connection = OpenConnection())
            {
                // create a SELECT query builder for the Employee table
                var command = new SelectQueryBuilder(connection, CUSTOMER_TABLE);

                // Add employeeId parameter
                if (!SkipSearchParameter(customerId))
                    command.AddParameter(CUSTOMER_ID, "customerId", customerId);

                // Add userId parameter
                if (!SkipSearchParameter(cust_lastname))
                    command.AddParameter(CUSTOMER_LAST_NAME, "cust_lastname", cust_lastname);

                using (var reader = command.ToDbCommand().ExecuteReader())
                {
                    // each Read() fetches the next record that matches our SELECT query
                    // build our code object from each record and add it to the list of results
                    while (reader.Read())
                    {
                        Customer cust = new Customer();
              
                        cust.Id = (int)reader[CUSTOMER_ID];

						cust.PaymentId = (int)reader[CUSTOMER_PAYMENT];

                        cust.FirstName = (string)reader[CUSTOMER_FIRST_NAME];
                        cust.LastName = (string)reader[CUSTOMER_LAST_NAME];
                        cust.Address = (string)reader[CUSTOMER_ADDRESS];
                        cust.City = (string)reader[CUSTOMER_CITY];
                        cust.State = (string)reader[CUSTOMER_STATE];
                        cust.ZipCode = (string)reader[CUSTOMER_ZIPCODE];
                        cust.Email = (string)reader[CUSTOMER_EMAIL];
                        cust.Phone = (string)reader[CUSTOMER_PHONE];                        

                        results.Add(cust);
                    }
                }
            }

            return results;
        }
	};
}