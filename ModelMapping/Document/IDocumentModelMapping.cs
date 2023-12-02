using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.ModelMapping.Document
{
    public interface IDocumentModelMapping
    {
        public Task<List<Documents>> DocumentMapping(List<object[]> array);
    }
}
