using TechnicalTestAPI.Models.ServiceModels;

namespace TechnicalTestAPI.ModelMapping.DeviceManagement
{
    public interface IDeviceManagementModelMapping
    {
        public Task<List<Devices>> DeviceManagementMapping(List<object[]> array);
    }
}
