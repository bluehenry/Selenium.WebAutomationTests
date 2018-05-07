using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Selenium.WebTest.Framework.Support.DB
{
    public class SqlClientHelper
    {
        private string _dbConnectionString;
        private int _commandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SQL_CommandTimeout"]);

        public SqlClientHelper(string dbConnectionString)
        {
            this._dbConnectionString = dbConnectionString;
        }

        public DataSet ExecuteSqlCommandAndReturnResults(string sqlCmd)
        {
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd, _dbConnectionString))
            {
                DataSet dataSet = new DataSet("RESULT");
                sqlDataAdapter.Fill(dataSet);
                return dataSet;
            }
        }

        public DataSet ExecuteSqlCommandWithIncreasedTimeoutAndReturnResults(string sqlCmd)
        {
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd, _dbConnectionString))
            {
                sqlDataAdapter.SelectCommand.CommandTimeout = _commandTimeout;
                DataSet dataSet = new DataSet("RESULT");
                sqlDataAdapter.Fill(dataSet);
                sqlDataAdapter.SelectCommand.ResetCommandTimeout();
                return dataSet;
            }
        }

        public void BulkCopy(DataTable testData, string table)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_dbConnectionString))
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
