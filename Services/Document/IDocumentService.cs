using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.Services.Document
{
    public interface IDocumentService
    {
        public Task<List<Documents>> ReadDocuments();

        public Task<dynamic> CreateDocument(Documents documentInput);

        public Task<dynamic> UpdateDocument(Documents documentInput);

        public Task<dynamic> DeleteDocument(Documents documentInput);
    }
}