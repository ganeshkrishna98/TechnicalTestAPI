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
        public async Task<IActionResult> ReadDocuments()
        {
            var result = await _documentService.ReadDocuments();
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("create-documents")]
        public async Task<IActionResult> CreateDocuments([FromBody] Documents documentInput)
        {
            var result = await _documentService.CreateDocuments(documentInput);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("update-documents")]
        public async Task<IActionResult> UpdateDocuments([FromBody] Documents documentInput)
        {
            var result = await _documentService.UpdateDocuments(documentInput);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete-documents")]
        public async Task<IActionResult> DeleteDocuments([FromBody] Documents documentInput)
        {
            var result = await _documentService.DeleteDocuments(documentInput);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("upload-documents")]
        public async Task<IActionResult> UploadDocuments([FromForm] FileModel inputfile)
        {
            var result = await _documentService.UploadDocuments(inputfile);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("download-documents")]
        public async Task<IActionResult> DownloadDocuments([FromQuery] string fileName)
        {
            var result = await _documentService.DownloadDocuments(fileName);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            return Ok(File(result, "application/octet-stream", fileName));
        }
    }
}