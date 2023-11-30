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

        [HttpGet]
        [Route("get-documents")]
        public async Task<IActionResult> GetDocuments([FromQuery] string uid)
        {
            var result = await _documentService.GetDocuments();
            return Ok(result);
        }

        [HttpPost]
        [Route("create-documents")]
        public async Task<IActionResult> CreateDocument([FromBody] CreateDocumentInput createDocumentInput)
        {
            var result = await _documentService.CreateDocument(createDocumentInput);
            return Ok(result);
        }
    }
}