using TechnicalTestAPI.Models.ServiceModels;

namespace TechnicalTestAPI.ModelMapping.AccessLogs
{
    public interface IAccessLogsModelMapping
    {
        public Task<List<AccessLog>> AccessLogMapping(List<object[]> array);
    }
}
