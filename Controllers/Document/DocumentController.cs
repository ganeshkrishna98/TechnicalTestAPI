using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UniversityOfNottinghamAPI.Database;
using UniversityOfNottinghamAPI.Models.ServiceModels;
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
        [Route("read-documents")]
        public async Task<IActionResult> ReadDocuments([FromQuery] string uid)
        {
            var result = await _documentService.ReadDocuments();
            return Ok(result);
        }

        [HttpPost]
        [Route("create-documents")]
        public async Task<IActionResult> CreateDocument([FromBody] Documents documentInput)
        {
            var result = await _documentService.CreateDocument(documentInput);
            return Ok(result);
        }

        [HttpPost]
        [Route("update-documents")]
        public async Task<IActionResult> UpdateDocument([FromBody] Documents documentInput)
        {
            var result = await _documentService.UpdateDocument(documentInput);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete-documents")]
        public async Task<IActionResult> DeleteDocument([FromBody] Documents documentInput)
        {
            var result = await _documentService.DeleteDocument(documentInput);
            return Ok(result);
        }
    }
}