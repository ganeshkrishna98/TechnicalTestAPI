using TechnicalTestAPI.Models.ServiceModels;

namespace TechnicalTestAPI.Services.Common
{
    public interface ICommonService
    {
        public Task<dynamic> ExecuteRequest(string serviceName, string queryType, dynamic inputParameters);
        public Task<ErrorModel> ErrorResponseBuilder(string input);
        public Task<dynamic> DeleteAllValues(string tableName);
    }
}
