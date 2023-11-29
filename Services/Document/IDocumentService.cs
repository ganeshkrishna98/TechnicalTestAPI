using Microsoft.AspNetCore.Mvc;
using UniversityOfNottinghamAPI.Models.InputModels;

namespace UniversityOfNottinghamAPI.Services.Document
{
    public interface IDocumentService
    {
        public Task<dynamic> CreateDocument(CreateDocumentInput createDocumentInput);
    }
}
