using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.Services.Document
{
    public interface IDocumentService
    {
        public Task<dynamic> ReadDocuments();

        public Task<dynamic> CreateDocuments(Documents documentInput);

        public Task<dynamic> UpdateDocuments(Documents documentInput);

        public Task<dynamic> DeleteDocuments(Documents documentInput);

        public Task<dynamic> UploadDocuments(FileModel inputfile);
        public Task<dynamic> DownloadDocuments(string fileName);
    }
}