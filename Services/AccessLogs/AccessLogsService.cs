using Microsoft.AspNetCore.Mvc;
using TechnicalTestAPI.Constants;
using TechnicalTestAPI.ModelMapping.AccessLogs;
using TechnicalTestAPI.Models.ServiceModels;
using TechnicalTestAPI.Services.Common;

namespace TechnicalTestAPI.Services.AccessLogs
{
    public class AccessLogsService : IAccessLogsService
    {
        private readonly ICommonService _commonService;
        private readonly IAccessLogsModelMapping _accessLogsModelMapping;

        public AccessLogsService(ICommonService commonService, IAccessLogsModelMapping accessLogsModelMapping)
        {
            _commonService = commonService;
            _accessLogsModelMapping = accessLogsModelMapping;
        }

        public async Task<dynamic> ReadAccessLogs()
        {
            var result = await _commonService.ExecuteRequest(typeof(AccessLogsService).Name.ToString(), Constant.Read, string.Empty);
            if (result.GetType() == typeof(ErrorModel))
            {
                return result;
            }
            else
                return await _accessLogsModelMapping.AccessLogMapping(result);
        }

        public async Task<dynamic> CreateAccessLogs(AccessLog accessLogsInput)
        {
            return await _commonService.ExecuteRequest(typeof(AccessLogsService).Name.ToString(), Constant.Create, accessLogsInput);
        }

        public async Task<dynamic> UpdateAccessLogs(AccessLog accessLogsInput)
        {
            return await _commonService.ExecuteRequest(typeof(AccessLogsService).Name.ToString(), Constant.Update, accessLogsInput);
        }

        public async Task<dynamic> DeleteAccessLogs(AccessLog accessLogsInput)
        {
            var result = await _commonService.ExecuteRequest(typeof(AccessLogsService).Name.ToString(), Constant.Delete, accessLogsInput);
            if (result is ErrorModel)
            {
                return result;
            }

            var jsonResult = result as string;
            return new JsonResult(jsonResult)
            {
                StatusCode = 200,
            };
        }
    }
}