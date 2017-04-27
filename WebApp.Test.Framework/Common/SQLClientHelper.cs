using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace WebApp.Test.Framework.Common
{
    public class SQLClientHelper
    {
        private string dbConnectionString;
        private int commandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings.Get("SQL_COMMAND_TIMEOUT"));

        public SQLClientHelper(string dbConnectionString)
        {
            this.dbConnectionString = dbConnectionString;
        }

        public DataSet ExecuteSQLCommandAndReturnResults(string sqlCmd)
        {
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd, dbConnectionString))
            {
                DataSet dataSet = new DataSet("RESULT");
                sqlDataAdapter.Fill(dataSet);
                return dataSet;
            }
        }

        public DataSet ExecuteSQLCommandWithIncreasedTimeoutAndReturnResults(string sqlCmd)
        {
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd, dbConnectionString))
            {
                sqlDataAdapter.SelectCommand.CommandTimeout = commandTimeout;
                DataSet dataSet = new DataSet("RESULT");
                sqlDataAdapter.Fill(dataSet);
                sqlDataAdapter.SelectCommand.ResetCommandTimeout();
                return dataSet;
            }
        }

        public void BulkCopy(DataTable testData, string table)
        {
            using (SqlConnection sqlConnection = new SqlConnection(dbConnectionString))
            {
                sqlConnection.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(sqlConnection))
                {
                    s.DestinationTableName = table;
                    foreach (var column in testData.Columns)
                    {
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    }
                    s.WriteToServer(testData);
                }
                sqlConnection.Close();
            }
        }
    }
}
