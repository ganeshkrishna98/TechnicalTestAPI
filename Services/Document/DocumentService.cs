using UniversityOfNottinghamAPI.ModelMapping;
using UniversityOfNottinghamAPI.Models.InputModels;
using UniversityOfNottinghamAPI.Models.OutputModels;
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

        public async Task<List<DocumentOutput>> ReadDocuments()
        {
            var result = await _commonService.ExecuteRequest(typeof(DocumentService).Name.ToString(), Constant.Read, string.Empty);
            return _documentModelMapping.DocumentMapping(result);
        }

        public async Task<dynamic> CreateDocument(DocumentInput documentInput)
        {
            return await _commonService.ExecuteRequest(typeof(DocumentService).Name.ToString(), Constant.Create, documentInput);
        }

        public async Task<dynamic> UpdateDocument(DocumentInput documentInput)
        {
            return await _commonService.ExecuteRequest(typeof(DocumentService).Name.ToString(), Constant.Update, documentInput);
        }

        public async Task<dynamic> DeleteDocument(DocumentInput documentInput)
        {
            return await _commonService.ExecuteRequest(typeof(DocumentService).Name.ToString(), Constant.Delete, documentInput);
        }
    }
}