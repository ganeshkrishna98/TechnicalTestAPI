using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.ModelMapping.DatabaseManagement
{
    public interface IDatabaseManagementModelMapping
    {
        public Task<List<Databases>> DatabaseManagementMapping(List<object[]> array);
    }
}
