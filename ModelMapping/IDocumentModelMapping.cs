using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.ModelMapping
{
    public interface IDocumentModelMapping
    {
        public List<Documents> DocumentMapping(List<object[]> array);
    }
}
