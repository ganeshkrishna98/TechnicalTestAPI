using UniversityOfNottinghamAPI.Models.InputModels;
using UniversityOfNottinghamAPI.Services.Common;

namespace UniversityOfNottinghamAPI.Services.Document
{
    public class DocumentService : IDocumentService
    {
        private readonly ICommonService _commonService;
        private string tableName = "Documents";

        public DocumentService(ICommonService commonService)
        {
            _commonService = commonService;
        }

        public async Task<dynamic> CreateDocument(CreateDocumentInput createDocumentInput)
        {
            string query = await _commonService.QueryBuilder(tableName, Constants.Constants.Create, createDocumentInput);
            var result = await _commonService.ExecuteRequest(tableName, query);
            return query;
        }
    }
}