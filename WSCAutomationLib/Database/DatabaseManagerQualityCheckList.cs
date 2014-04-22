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

        const string QUALITY_ID = "QualityID";
		const string QUALITY_DESCRIPTION = "Qual_Description";
		const string QUALITY_PASS = "Qual_Pass";
        #endregion

        static SqlCeCommand BuildModificationQuery(SqlCeConnection connection, ModificationQueryType type,
            QualityCheckList qual)
        {
            var query = new ModificationQueryBuilder(connection, type, QUALITY_TABLE);

            query.AddIdParameter(QUALITY_ID, "id", qual.Id);

			query.AddParameter(QUALITY_PASS, "pass", qual.Pass);
			query.AddParameter(QUALITY_DESCRIPTION, "description", qual.Description);

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
            object idObj = PerformModificationQuery(ModificationQueryType.Insert, qual);

			if (idObj != null)
            {
				qual.Id = Convert.ToInt32(idObj);

                return qual.Id;
            }

            return -1;
        }

        public bool DBEditQualityChecklist(QualityCheckList qual)
        {
            var rowsAffected = (int)PerformModificationQuery(ModificationQueryType.Update, qual);

            return rowsAffected == 1;
        }

        public List<QualityCheckList> DBGetQualityCheckList(int qualityId = -1)
        {
			VerifySearchParameter(qualityId, "qualityId");

            var results = new List<QualityCheckList>();

            // open a connection to the SQL DB
            using (var connection = OpenConnection())
            {
                // create a SELECT query builder for the Employee table
                var command = new SelectQueryBuilder(connection, QUALITY_TABLE);

                // Add QUALITY Log ID
				if (!SkipSearchParameter(qualityId))
					command.AddParameter(QUALITY_ID, "qualityId", qualityId);

                using (var reader = command.ToDbCommand().ExecuteReader())
                {
                    // each Read() fetches the next record that matches our SELECT query
                    // build our code object from each record and add it to the list of results
                    while (reader.Read())
                    {
                        QualityCheckList qual = new QualityCheckList();

                        qual.Id = (int)reader[QUALITY_ID];
                        qual.Description = (string)reader[QUALITY_DESCRIPTION];
                        qual.Pass = (bool)reader[QUALITY_PASS];

                        results.Add(qual);
                    }
                }
            }

            return results;
        }
	};
}