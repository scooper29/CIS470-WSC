using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;

namespace WSCAutomation.Database
{
    using Customers;

	partial class DatabaseManager
	{
        #region Inventory table column names
        const string PAYMENT_TABLE = "Payment";

        const string PAYMENT_ID = "PaymentID";
        const string PAYMENT_TYPE = "Pay_Type";
        const string PAYMENT_CARD_NUMBER = "Pay_CardNum";
        const string PAYMENT_EXP_DATE = "Pay_ExpDate";
        #endregion

        static SqlCeCommand BuildModificationQuery(SqlCeConnection connection, ModificationQueryType type,
            Payment pay)
        {
            var query = new ModificationQueryBuilder(connection, type, PAYMENT_TABLE);

            query.AddParameter(PAYMENT_ID, "payId", pay.Id);

            query.AddParameter(PAYMENT_TYPE, "payType", pay.Type);
            query.AddParameter(PAYMENT_CARD_NUMBER, "paymentCardNumber", pay.CardNumber);
            query.AddParameter(PAYMENT_EXP_DATE, "expirationDate", pay.ExpirationDate);

            return query.ToDbCommand();
        }

        object PerformModificationQuery(ModificationQueryType type, Payment pay)
        {
            object result = null;

            // open a connection to the SQL DB
            using (var connection = OpenConnection())
            {
                var command = BuildModificationQuery(connection, type, pay);

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

        public int DBAddPayment(Payment pay)
		{
            object Obj = PerformModificationQuery(ModificationQueryType.Insert, pay);

            if (Obj != null)
            {
                pay.Id = Convert.ToInt32(Obj);

                return pay.Id;
            }

            return -1;
		}

		public bool DBEditPayment(Payment pay)
		{
            var rowsAffected = (int)PerformModificationQuery(ModificationQueryType.Update, pay);

            return rowsAffected == 1;
		}

		public List<Payment> DBGetPayments(int payId = -1, string type = "", string cardNumber = "")
		{
			VerifySearchParameter(payId, "payId");
			VerifySearchParameter(type, "type");
			VerifySearchParameter(cardNumber, "pay_CardNumber");
            
            var results = new List<Payment>();

            // open a connection to the SQL DB
            using (var connection = OpenConnection())
            {
                // create a SELECT query builder for the Customertable
                var command = new SelectQueryBuilder(connection, PAYMENT_TABLE);

                // Add Payment Id parameter
				if (!SkipSearchParameter(payId))
					command.AddParameter(PAYMENT_ID, "payId", payId);

                // Add PAYMENT TYPE parameter
				if (!SkipSearchParameter(type))
					command.AddParameter(PAYMENT_TYPE, "type", type);

                // Add PAYMENT CARD NUMBER parameter
				if (!SkipSearchParameter(cardNumber))
					command.AddParameter(PAYMENT_CARD_NUMBER, "cardNumber", cardNumber);

                using (var reader = command.ToDbCommand().ExecuteReader())
                {
                    // each Read() fetches the next record that matches our SELECT query
                    // build our code object from each record and add it to the list of results
                    while (reader.Read())
                    {
                        Payment pay = new Payment();

                        pay.Id = (int)reader[PAYMENT_ID];
                        pay.Type = (string)reader[PAYMENT_TYPE];
                        pay.CardNumber = (string)reader[PAYMENT_CARD_NUMBER];
                        pay.ExpirationDate = (DateTime)reader[PAYMENT_EXP_DATE];

                        results.Add(pay);
                    }
                }
            }
            return results;
		}
	};
}