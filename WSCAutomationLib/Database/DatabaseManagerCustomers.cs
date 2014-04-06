using System;
using System.Data.OleDb;
using System.Data;
using System.Collections.Generic;

namespace WSCAutomation.Database
{
	// TODO: DatabaseManager methods relating to the Customer tables should go here

	partial class DatabaseManager
	{
		public void DBAddCustomer(string Cust_FirstName, string Cust_LastName, string Cust_Address, string Cust_City, string Cust_State, string Cust_ZipCode, string Cust_Email, string Cust_Phone)
		{
            bool CustomerSaved;

            OleDbTransaction ThisTransaction = null;

            try
            {
                //OleDbConnection conn = new OleDbConnection(

                //OleDbCommand command = 

                //ThisTransaction = conn.BeginTransaction();

                //command.Transaction = ThisTransaction;

                //strSQL = "INSERT into Customer " + "(Cust_FirstName, Cust_LastName, Cust_Address, Cust_City, Cust_State, Cust_ZipCode, Cust_Email, Cust_Phone) values
                ('" + Cust_FirstName + "', '" + Cust_LastName + '", '" + Cust_Address + "', '" + Cust_City + "', '" + Cust_ZipCode + "', '" + Cust_Email + "', '" + Cust_Phone "');

                ThisTransaction.Commit();

                conn.Close();
                CustomerSaved = true;
            }

            catch (Exception ex)
            {
                ThisTransaction.Rollback();

                CustomerSaved = false;

            }
  
		}

		public void DBEditCustomer()
		{

		}

		public List<Customers.Customer> DBGetCustomers(string CustomerSearch)
		{
        
            var list = new List<Customers.Customer>();
       
            OleDbConnection sqlConn;
            OleDbDataAdapter sqlDA;

            //assign the connection
            sqlConn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + Database);
        
            //assign the adapter
            if (CustomerSearch == "")
                sqlDA = new OleDbDataAdapter("select * from Customer", sqlConn);
            else
                sqlDA = new OleDbDataAdapter("select * from Customer where Cust_LastName = '" + CustomerSearch + "'", sqlConn);
            


            return list;
		}
	};
}