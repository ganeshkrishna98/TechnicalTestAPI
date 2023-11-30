using Microsoft.AspNetCore.Mvc;

namespace UniversityOfNottinghamAPI.Services.Common
{
    public interface ICommonService
    {
        public Task<dynamic> ExecuteRequest(string serviceName, string queryType, dynamic inputParameters);
    }
}
