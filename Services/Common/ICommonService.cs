using Microsoft.AspNetCore.Mvc;

namespace UniversityOfNottinghamAPI.Services.Common
{
    public interface ICommonService
    {
        public Task<IActionResult> ExecuteRequest(string serviceName, string queryString);
        public Task<string> QueryBuilder(string tableName, string queryType, dynamic inputParameters);
    }
}
