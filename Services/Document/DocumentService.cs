using Microsoft.AspNetCore.Components.Forms;
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

        public async Task<dynamic> UploadDocuments(FileModel inputfile)
        {
            if (inputfile.File == null)
                return Constant.FileNotSelected;
            if (inputfile.File.Length == 0)
                return Constant.FileIsEmpty;
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
                return Constant.FileNotFound;
            }
            else
                return File.ReadAllBytes(filePath);
        }
    }
}