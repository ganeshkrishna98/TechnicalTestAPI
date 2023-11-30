using Microsoft.AspNetCore.Mvc;
using UniversityOfNottinghamAPI.Models.InputModels;
using UniversityOfNottinghamAPI.Models.OutputModels;

namespace UniversityOfNottinghamAPI.Services.Document
{
    public interface IDocumentService
    {
        public Task<List<DocumentOutput>> GetDocuments();
        public Task<dynamic> CreateDocument(CreateDocumentInput createDocumentInput);
    }
}
