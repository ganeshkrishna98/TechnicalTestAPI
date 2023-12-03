using Microsoft.AspNetCore.Mvc;
using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.Services.Common
{
    public interface ICommonService
    {
        public Task<dynamic> ExecuteRequest(string serviceName, string queryType, dynamic inputParameters);
        public Task<ErrorModel> ErrorResponseBuilder(string input);
    }
}
