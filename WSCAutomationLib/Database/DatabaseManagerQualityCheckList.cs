using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;

namespace WSCAutomation.Database
{
    using Orders;

	partial class DatabaseManager
	{
        #region Inventory table column names
        const string QUALITY_TABLE = "QUALITY";

        const string QUALITY_ID = "QUALITY_ID";
        const string ORDER_ID = "Order_Id";
        const string QUAl_Description = "QUAl_Description";
        const string QUAl_Pass = "Quality_Pass";
        #endregion
        static SqlCeCommand BuildModificationQuery(SqlCeConnection connection, ModificationQueryType type,
            QualityCheckList qual)
        {
            var query = new ModificationQueryBuilder(connection, type, QUALITY_TABLE);

            query.AddParameter(QUALITY_ID, "quallogId", qual.Id);

            query.AddParameter(ORDER_ID, "orderId", qual.OrderId);
            query.AddParameter(QUAl_Pass, "QualityPass", qual.Pass);
            query.AddParameter(QUAl_Description, "QualityDescription ", qual.Description);

            return query.ToDbCommand();
        }

        object PerformModificationQuery(ModificationQueryType type, QualityCheckList qual)
        {
            object result = null;

            // open a connection to the SQL DB
            using (var connection = OpenConnection())
            {
                var command = BuildModificationQuery(connection, type, qual);

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

        public int DBAddQualityCheckList(QualityCheckList qual)
        {

            object Obj = PerformModificationQuery(ModificationQueryType.Insert, qual);

            if (Obj != null)
            {
                qual.Id = Convert.ToInt32(Obj);

                return qual.Id;
            }

            return -1;
        }

        public List<QualityCheckList> DBGetInventory(string QUALITY_Log_ID, string QUAl_Pass, string QUAl_Description = "")
        {
            VerifySearchParameter(QUALITY_ID, "quality_log_Id");
            VerifySearchParameter(QUAl_Pass, "qual_pass");
            VerifySearchParameter(QUAl_Description, "qual_description");

            var results = new List<QualityCheckList>();

            // open a connection to the SQL DB
            using (var connection = OpenConnection())
            {
                // create a SELECT query builder for the Employee table
                var command = new SelectQueryBuilder(connection, QUALITY_TABLE);

                // Add QUALITY Log ID
                if (!SkipSearchParameter(QUALITY_ID))
                    command.AddParameter(QUALITY_Log_ID, "quallogId", QUALITY_ID);

                // Add Quality Description
                if (!SkipSearchParameter(QUAl_Description))
                    command.AddParameter(QUAl_Description, "qual_description", QUAl_Description);

                // Add QUALITY Pass
                if (!SkipSearchParameter(QUAl_Pass))
                    command.AddParameter(QUAl_Pass, "qual_pass", QUAl_Pass);

                using (var reader = command.ToDbCommand().ExecuteReader())
                {
                    // each Read() fetches the next record that matches our SELECT query
                    // build our code object from each record and add it to the list of results
                    while (reader.Read())
                    {
                        QualityCheckList qual = new QualityCheckList();

                        qual.Id = (int)reader[QUALITY_Log_ID];
                        qual.OrderId = (int)reader[ORDER_ID];
                        qual.Description = (string)reader[QUAl_Description];
                        qual.Pass = (QualityPassCode)reader[QUAl_Pass];

                        results.Add(qual);
                    }
                }
            }

            return results;
        }
	};
}