using Microsoft.AspNetCore.Mvc;

namespace UniversityOfNottinghamAPI.Services.Common
{
    public interface ICommonService
    {
        public Task<dynamic> ExecuteRequest(string serviceName, string queryType, string queryString);
        public Task<string> QueryBuilder(string tableName, string queryType, dynamic inputParameters);
    }
}
