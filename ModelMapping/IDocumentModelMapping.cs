using UniversityOfNottinghamAPI.Models.OutputModels;

namespace UniversityOfNottinghamAPI.ModelMapping
{
    public interface IDocumentModelMapping
    {
        public List<DocumentOutput> DocumentMapping(List<object[]> array);
    }
}
