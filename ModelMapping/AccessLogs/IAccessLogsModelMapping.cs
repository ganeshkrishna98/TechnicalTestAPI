using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.ModelMapping.AccessLogs
{
    public interface IAccessLogsModelMapping
    {
        public Task<List<AccessLog>> AccessLogMapping(List<object[]> array);
    }
}
