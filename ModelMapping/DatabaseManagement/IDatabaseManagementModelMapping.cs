using TechnicalTestAPI.Models.ServiceModels;

namespace TechnicalTestAPI.ModelMapping.DatabaseManagement
{
    public interface IDatabaseManagementModelMapping
    {
        public Task<List<Databases>> DatabaseManagementMapping(List<object[]> array);
    }
}
