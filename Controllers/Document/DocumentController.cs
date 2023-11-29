using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UniversityOfNottinghamAPI.Database;
using UniversityOfNottinghamAPI.Models.InputModels;
using UniversityOfNottinghamAPI.Services.Document;

namespace UniversityOfNottinghamAPI.Controllers.Document
{
    [Route("api/document")]
    [EnableCors]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;

        public DocumentController(DatabaseContext context, IDocumentService documentService)
        {
            _documentService = documentService;
        }
        [HttpPost]
        [Route("create-document")]
        public async Task<IActionResult> CreateDocument(CreateDocumentInput createDocumentInput)
        {
            var result = await _documentService.CreateDocument(createDocumentInput);
            return result;
        }
    }
}
