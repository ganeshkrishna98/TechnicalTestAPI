using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UniversityOfNottinghamAPI.Models.DatabaseTableModels;
using UniversityOfNottinghamAPI.Models.ServiceModels;
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
            if (tableName.IsNullOrEmpty())
                return await ErrorResponseBuilder(String.Empty);
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
                    return await ErrorResponseBuilder(Constant.Failed);
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
                case Constant.AccessLogsService:
                    table = Constant.AccessLogs;
                    break;
                case Constant.DeviceManagementService:
                    table = Constant.Devices;
                    break;
                case Constant.DocumentService:
                    table = Constant.Documents;
                    break;
                case Constant.NotificationManagementService:
                    table = Constant.Notifications;
                    break;
                case Constant.StorageManagementService:
                    table = Constant.Storages;
                    break;
                case Constant.UserManagementService:
                    table = Constant.UserAccounts;
                    break;
            }
            return table;
        }

        internal static async Task<List<string>> GetSQLColumns(string tableName)
        {
            List<string> columns = new List<string>();
            switch (tableName)
            {
                case Constant.AccessLogs:
                    columns.AddRange(TableColumns.AccessLogsColumns.Split(','));
                    break;
                case Constant.Devices:
                    columns.AddRange(TableColumns.DevicesColumns.Split(','));
                    break;
                case Constant.Documents:
                    columns.AddRange(TableColumns.DocumentsColumns.Split(','));
                    break;
                case Constant.Notifications:
                    columns.AddRange(TableColumns.NotificationsColumns.Split(','));
                    break;
                case Constant.Storages:
                    columns.AddRange(TableColumns.StoragesColumns.Split(','));
                    break;
                case Constant.UserAccounts:
                    columns.AddRange(TableColumns.UserAccountColumns.Split(','));
                    break;
            }
            return columns;
        }

        #endregion Internal Functions To Fetch Data and Generate Query

        #region Error Response Builder
        public async Task<ErrorModel> ErrorResponseBuilder(string input)
        {
            ErrorModel error = new ErrorModel();
            if (!input.IsNullOrEmpty())
                error.Message = input;
            else
                error.Message = "Undefined Error";
            error.ErrorCode = "400";
            return error;
        }
        #endregion Error Response Builder
    }
}