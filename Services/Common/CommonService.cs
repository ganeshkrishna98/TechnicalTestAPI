using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using UniversityOfNottinghamAPI.Models.DatabaseTableModels;
using Constant = UniversityOfNottinghamAPI.Constants.Constants;

namespace UniversityOfNottinghamAPI.Services.Common
{
    public class CommonService : ICommonService
    {
        private readonly IConfiguration _configuration;

        public CommonService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<dynamic> ExecuteRequest(string serviceName, string queryType, dynamic inputParameters)
        {
            #region Get Table Name

            var tableName = GetTableName(serviceName);

            #endregion Get Table Name

            #region Generate Query

            var queryString = await QueryBuilder(tableName, queryType, inputParameters);

            #endregion Generate Query

            #region SQL Execution Part

            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("SQL"));
            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(queryString, sqlConnection);
            if (queryType == Constant.Read)
            {
                DataTable dataTable = new DataTable();
                await Task.Run(() => sqlDataAdapter.Fill(dataTable));
                List<object[]> array = new();
                foreach (DataRow row in dataTable.Rows)
                {
                    array.Add(row.ItemArray);
                }
                return array;
            }
            else
            {
                var response = await sqlCommand.ExecuteNonQueryAsync();
                if (response == 1)
                    return Constant.Success;
                else
                    return Constant.Failed;
            }

            #endregion SQL Execution Part
        }

        #region Internal Functions To Fetch Data and Generate Query

        internal async Task<string> QueryBuilder(string tableName, string queryType, dynamic inputParameters)
        {
            List<string> columnNames = await GetSQLColumns(tableName);
            StringBuilder queryBuilder = new StringBuilder();

            switch (queryType)
            {
                case Constant.Read:
                    queryBuilder.Append($"SELECT * FROM {tableName} ;");
                    break;

                case Constant.Create:
                    queryBuilder.Append($"INSERT INTO {tableName} (");
                    foreach (string item in columnNames)
                    {
                        queryBuilder.Append($" {item}");
                        if (item != columnNames.LastOrDefault())
                            queryBuilder.Append(",");
                    }
                    queryBuilder.Append(") VALUES ( ");
                    foreach (string item in columnNames)
                    {
                        var property = inputParameters.GetType().GetProperty(item);
                        var value = property.GetValue(inputParameters, null);
                        queryBuilder.Append($" '{value}'");
                        if (item != columnNames.LastOrDefault())
                            queryBuilder.Append(',');
                        else
                            queryBuilder.Append(");");
                    }
                    break;

                case Constant.Delete:
                    queryBuilder.Append($"DELETE FROM {tableName} WHERE ");
                    var inputProp = inputParameters.GetType().GetProperty(columnNames.FirstOrDefault());
                    var inputPropVal = inputProp.GetValue(inputParameters, null);
                    if (inputPropVal != null)
                        queryBuilder.Append($"{columnNames.FirstOrDefault()} = '{inputPropVal}';");
                    break;

                case Constant.Update:
                    queryBuilder.Append($"UPDATE {tableName} SET ");
                    foreach (string item in columnNames)
                    {
                        if (item != columnNames.FirstOrDefault())
                        {
                            var property = inputParameters.GetType().GetProperty(item);
                            var value = property.GetValue(inputParameters, null);
                            queryBuilder.Append($" {item} = '{value}'");
                            if (item != columnNames.LastOrDefault())
                                queryBuilder.Append(',');
                            else
                            {
                                property = inputParameters.GetType().GetProperty(columnNames.FirstOrDefault());
                                value = property.GetValue(inputParameters, null);
                                queryBuilder.Append($"WHERE {columnNames.FirstOrDefault()} = '{value}';");
                            }
                        }
                    }
                    break;
            }
            string result = queryBuilder.ToString();
            return result;
        }

        public string GetTableName(string serviceName)
        {
            string table = string.Empty;
            switch (serviceName)
            {
                case Constant.DocumentService:
                    table = Constant.Documents;
                    break;
            }
            return table;
        }

        internal static async Task<List<string>> GetSQLColumns(string serviceName)
        {
            List<string> columns = new List<string>();
            switch (serviceName)
            {
                case Constant.Documents:
                    columns.AddRange(TableColumns.DocumentsColumns.Split(','));
                    break;

                case Constant.UserAccounts:
                    columns.AddRange(TableColumns.UserAccountColumns.Split(','));
                    break;
            }
            return columns;
        }

        #endregion Internal Functions To Fetch Data and Generate Query
    }
}