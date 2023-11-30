using UniversityOfNottinghamAPI.Models.OutputModels;

namespace UniversityOfNottinghamAPI.ModelMapping
{
    public interface IDocumentModelMapping
    {
        public List<DocumentOutput> GetAllRecordsModelMapping(List<object[]> array);
    }
}
