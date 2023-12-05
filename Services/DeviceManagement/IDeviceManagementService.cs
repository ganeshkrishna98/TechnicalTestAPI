using TechnicalTestAPI.Models.ServiceModels;

namespace TechnicalTestAPI.Services.DeviceManagement
{
    public interface IDeviceManagementService
    {
        public Task<dynamic> ReadDevices();
        public Task<dynamic> CreateDevices(Devices deviceManagementInput);
        public Task<dynamic> UpdateDevices(Devices deviceManagementInput);
        public Task<dynamic> DeleteDevices(Devices deviceManagementInput);
    }
}
