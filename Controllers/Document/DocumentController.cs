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
        public async Task<IActionResult> CreateDocument([FromBody] DocumentInput documentInput)
        {
            var result = await _documentService.CreateDocument(documentInput);
            return Ok(result);
        }

        [HttpPost]
        [Route("update-documents")]
        public async Task<IActionResult> UpdateDocument([FromBody] DocumentInput documentInput)
        {
            var result = await _documentService.UpdateDocument(documentInput);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete-documents")]
        public async Task<IActionResult> DeleteDocument([FromBody] string docID)
        {
            var result = await _documentService.DeleteDocument(docID);
            return Ok(result);
        }
    }
}