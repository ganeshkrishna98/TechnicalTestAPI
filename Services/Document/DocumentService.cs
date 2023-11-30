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
            string query = await _commonService.QueryBuilder(tableName, Constants.Constants.Read, string.Empty);
            var result = await _commonService.ExecuteRequest(tableName, Constants.Constants.Read, query);
            var output = _documentModelMapping.DocumentMapping(result);
            return output;
        }

        public async Task<dynamic> CreateDocument(DocumentInput documentInput)
        {
            string query = await _commonService.QueryBuilder(tableName, Constants.Constants.Create, documentInput);
            var result = await _commonService.ExecuteRequest(tableName, null, query);
            return result;
        }

        public async Task<dynamic> UpdateDocument(DocumentInput documentInput)
        {
            string query = await _commonService.QueryBuilder(tableName, Constants.Constants.Update, documentInput);
            var result = await _commonService.ExecuteRequest(tableName, null, query);
            return result;
        }

        public async Task<dynamic> DeleteDocument(string docID)
        {
            string query = await _commonService.QueryBuilder(tableName, Constants.Constants.Delete, docID);
            var result = await _commonService.ExecuteRequest(tableName, null, query);
            return result;
        }
    }
}