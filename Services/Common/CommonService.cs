using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Text;
using UniversityOfNottinghamAPI.Models.DatabaseTableModels;

namespace UniversityOfNottinghamAPI.Services.Common
{
    public class CommonService : ICommonService
    {        
        private readonly TableColumns _tableColumns;
        private readonly IConfiguration _configuration;

        public CommonService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> ExecuteRequest(string serviceName, dynamic inputParameters)
        {
            SqlConnection _sqlConnection = new SqlConnection(_configuration.GetConnectionString("SQL"));

            return null;
        }
        public async Task<string> QueryBuilder(string tableName, dynamic inputParameters)
        {
            string columnNames = await GetSQLColumns(tableName);
            if (columnNames.Length != inputParameters.Length)
            {
                throw new ArgumentException("Column names count must match values count");
            }

            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append($"INSERT INTO {tableName} (");

            queryBuilder.Append(columnNames);

            queryBuilder.Append(") VALUES (");
            queryBuilder.Append(inputParameters);

            queryBuilder.Append(");");

            return queryBuilder.ToString();
        }
        internal async Task<string> GetSQLColumns(string serviceName)
        {
            string columns = string.Empty;
            switch (serviceName)
            {
                case "Document":
                    columns = _tableColumns.DocumentColumns;
                    break;

                case "User":
                    columns = _tableColumns.UserAccountColumns;
                    break;
            }
            return columns;
        }

        
    }
}