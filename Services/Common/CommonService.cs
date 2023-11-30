using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using UniversityOfNottinghamAPI.Models.DatabaseTableModels;

namespace UniversityOfNottinghamAPI.Services.Common
{
    public class CommonService : ICommonService
    {
        private readonly IConfiguration _configuration;

        public CommonService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<dynamic> ExecuteRequest(string serviceName, string queryType, string queryString)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("SQL"));
            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(queryString, sqlConnection);
            if (queryType == "Read")
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
                    return "Success";
                else
                    return "Failed";
            }
        }

        public async Task<string> QueryBuilder(string tableName, string queryType, dynamic inputParameters)
        {
            string columnNames = await GetSQLColumns(tableName);

            StringBuilder queryBuilder = new StringBuilder();

            switch (queryType)
            {
                case "Read":
                    queryBuilder.Append($"SELECT * FROM {tableName} ;");
                    break;

                case "Create":
                    queryBuilder.Append($"INSERT INTO {tableName} (");
                    queryBuilder.Append(columnNames);
                    queryBuilder.Append(") VALUES ( '");
                    queryBuilder.Append(inputParameters.Document_ID);
                    queryBuilder.Append("', '");
                    queryBuilder.Append(inputParameters.Document_Name);
                    queryBuilder.Append("', '");
                    queryBuilder.Append(inputParameters.File_Name);
                    queryBuilder.Append("', '");
                    queryBuilder.Append(inputParameters.Approval_Status);
                    queryBuilder.Append("', '");
                    queryBuilder.Append(inputParameters.Author_User_ID);
                    queryBuilder.Append("', '");
                    queryBuilder.Append(inputParameters.Author_Name);
                    queryBuilder.Append("', '");
                    queryBuilder.Append(inputParameters.Last_Modified_User_ID);
                    queryBuilder.Append("', '");
                    queryBuilder.Append(inputParameters.Last_Modified_User_Name);
                    queryBuilder.Append("', '");
                    queryBuilder.Append(inputParameters.Last_Accessed_User_Name);
                    queryBuilder.Append("', '");
                    queryBuilder.Append(inputParameters.Last_Accessed_User_ID);
                    queryBuilder.Append("');");
                    break;
            }
            string result = queryBuilder.ToString();
            return result;
        }

        internal string GetTableName(string serviceName)
        {
            return null;
        }

        internal async Task<string> GetSQLColumns(string serviceName)
        {
            string columns = string.Empty;
            switch (serviceName)
            {
                case "Documents":
                    columns = TableColumns.DocumentColumns;
                    break;

                case "UserAccounts":
                    columns = TableColumns.UserAccountColumns;
                    break;
            }
            return columns;
        }
    }
}