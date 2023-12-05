using UniversityOfNottinghamAPI.Constants;
using UniversityOfNottinghamAPI.ModelMapping.Document;
using UniversityOfNottinghamAPI.Models.ServiceModels;
using UniversityOfNottinghamAPI.Services.Common;

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

        public async Task<dynamic> ReadDocuments()
        {
            var result = await _commonService.ExecuteRequest(typeof(DocumentService).Name.ToString(), Constant.Read, string.Empty);
            if (result.GetType() == typeof(ErrorModel))
            {
                return result;
            }
            else
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

        public async Task<dynamic> UploadDocuments(FileModel inputfile)
        {
            if (inputfile.File == null)
                return await _commonService.ErrorResponseBuilder(Constant.FileNotSelected);
            if (inputfile.File.Length == 0)
                return await _commonService.ErrorResponseBuilder(Constant.FileIsEmpty);
            var fileName = Path.GetFileName(inputfile.File.FileName);
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Downloads", "wwwroot", "Uploads", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await inputfile.File.CopyToAsync(stream);
            }

            return Constant.Success;
        }

        public async Task<dynamic> DownloadDocuments(string fileName)
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Downloads", "wwwroot", "Uploads", fileName);
            if (!File.Exists(filePath))
            {
                return await _commonService.ErrorResponseBuilder(Constant.FileNotFound);
            }
            else
                return File.ReadAllBytes(filePath);
        }
    }
}