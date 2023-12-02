using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.ModelMapping
{
    public interface IDocumentModelMapping
    {
        public Task<List<Documents>> DocumentMapping(List<object[]> array);
    }
}
