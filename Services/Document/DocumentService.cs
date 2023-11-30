using UniversityOfNottinghamAPI.ModelMapping;
using UniversityOfNottinghamAPI.Models.InputModels;
using UniversityOfNottinghamAPI.Models.OutputModels;
using UniversityOfNottinghamAPI.Services.Common;

namespace UniversityOfNottinghamAPI.Services.Document
{
    public class DocumentService : IDocumentService
    {
        private readonly ICommonService _commonService;
        private readonly IDocumentModelMapping _documentModelMapping;
        private string tableName = "Documents";

        public DocumentService(ICommonService commonService, IDocumentModelMapping documentModelMapping)
        {
            _commonService = commonService;
            _documentModelMapping = documentModelMapping;
        }

        public async Task<List<DocumentOutput>> GetDocuments()
        {
            string query = await _commonService.QueryBuilder(tableName, Constants.Constants.Read, null);
            var result = await _commonService.ExecuteRequest(tableName, Constants.Constants.Read, query);
            var output = _documentModelMapping.GetAllRecordsModelMapping(result);
            return output;
        }

        public async Task<dynamic> CreateDocument(CreateDocumentInput createDocumentInput)
        {
            string query = await _commonService.QueryBuilder(tableName, Constants.Constants.Create, createDocumentInput);
            var result = await _commonService.ExecuteRequest(tableName, null, query);
            return query;
        }
    }
}