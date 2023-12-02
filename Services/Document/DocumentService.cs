using UniversityOfNottinghamAPI.ModelMapping.Document;
using UniversityOfNottinghamAPI.Models.ServiceModels;
using UniversityOfNottinghamAPI.Services.Common;
using Constant = UniversityOfNottinghamAPI.Constants.Constants;

namespace UniversityOfNottinghamAPI.Services.Document
{
    public class DocumentService : IDocumentService
    {
        private readonly ICommonService _commonService;
        private readonly IDocumentModelMapping _documentModelMapping;

        public DocumentService(ICommonService commonService, IDocumentModelMapping documentModelMapping)
        {
            _commonService = commonService;
            _documentModelMapping = documentModelMapping;
        }

        public async Task<List<Documents>> ReadDocuments()
        {
            var result = await _commonService.ExecuteRequest(typeof(DocumentService).Name.ToString(), Constant.Read, string.Empty);
            return await _documentModelMapping.DocumentMapping(result);
        }

        public async Task<dynamic> CreateDocuments(Documents documentInput)
        {
            documentInput.documentId = Guid.NewGuid().ToString();
            return await _commonService.ExecuteRequest(typeof(DocumentService).Name.ToString(), Constant.Create, documentInput);
        }

        public async Task<dynamic> UpdateDocuments(Documents documentInput)
        {
            return await _commonService.ExecuteRequest(typeof(DocumentService).Name.ToString(), Constant.Update, documentInput);
        }

        public async Task<dynamic> DeleteDocuments(Documents documentInput)
        {
            return await _commonService.ExecuteRequest(typeof(DocumentService).Name.ToString(), Constant.Delete, documentInput);
        }
    }
}