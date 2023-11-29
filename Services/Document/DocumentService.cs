using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using UniversityOfNottinghamAPI.Database;
using UniversityOfNottinghamAPI.Models.InputModels;
using UniversityOfNottinghamAPI.Services.Common;

namespace UniversityOfNottinghamAPI.Services.Document
{
    public class DocumentService:IDocumentService
    {
        private readonly ICommonService _commonService;
        private string serviceName = "Document";
        public DocumentService(ICommonService commonService)
        {
            _commonService = commonService;            
        }
        public async Task<IActionResult> CreateDocument(CreateDocumentInput createDocumentInput)
        {
            string query = _commonService.QueryBuilder(serviceName,createDocumentInput).ToString();
            return null;
        }
    }
}
