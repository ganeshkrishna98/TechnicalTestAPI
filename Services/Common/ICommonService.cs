using Microsoft.AspNetCore.Mvc;

namespace UniversityOfNottinghamAPI.Services.Common
{
    public interface ICommonService
    {
        public Task<IActionResult> ExecuteRequest(string serviceName, dynamic inputParameters);
        public Task<string> QueryBuilder(string tableName, dynamic inputParameters);
    }
}
