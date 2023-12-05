using TechnicalTestAPI.Models.ServiceModels;

namespace TechnicalTestAPI.ModelMapping.AccessLogs
{
    public class AccessLogsModelMapping : IAccessLogsModelMapping
    {
        public async Task<List<AccessLog>> AccessLogMapping(List<object[]> array)
        {
            var outputList = new List<AccessLog>();
            foreach (var item in array)
            {
                var output = new AccessLog
                {
                    userId = item[0].ToString(),
                    userEmail = item[1].ToString(),
                    userName = item[2].ToString(),
                    accessTime = item[3].ToString(),
                    accessDate = item[4].ToString(),
                    accessDevice = item[5].ToString(),
                    accessIp = item[6].ToString(),
                    accessedDocumentId = item[7].ToString(),
                    accessedDocumentName = item[8].ToString(),
                    actionPerformed = item[9].ToString()
                };
                outputList.Add(output);
            }
            return outputList;
        }
    }
}
