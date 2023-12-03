using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.Services.AccessLogs
{
    public interface IAccessLogsService
    {
        public Task<dynamic> ReadAccessLogs();
        public Task<dynamic> CreateAccessLogs(AccessLog accessLogsInput);
        public Task<dynamic> UpdateAccessLogs(AccessLog accessLogsInput);
        public Task<dynamic> DeleteAccessLogs(AccessLog accessLogsInput);
    }
}
