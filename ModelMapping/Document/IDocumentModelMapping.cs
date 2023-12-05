using TechnicalTestAPI.Models.ServiceModels;

namespace TechnicalTestAPI.ModelMapping.Document
{
    public interface IDocumentModelMapping
    {
        public Task<List<Documents>> DocumentMapping(List<object[]> array);
    }
}
