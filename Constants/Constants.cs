namespace UniversityOfNottinghamAPI.Constants
{
    public class Constants
    {
        #region Status Constants
        public const string Success = "Success";
        public const string Failed = "Failed";
        public const string FileNotSelected = "File is not selected";
        public const string FileIsEmpty = "File is empty";
        public const string FileNotFound = "File not found";
        #endregion
        #region CRED Constants
        public const string Create = "Create";
        public const string Read = "Read";
        public const string Update = "Update";
        public const string Delete = "Delete";
        #endregion
        #region Service Names
        public const string AccessLogsService = "AccessLogsService";
        public const string DatabaseManagementService = "DatabaseManagementService";
        public const string DeviceManagementService = "DeviceManagementService";
        public const string DocumentService = "DocumentService";
        public const string NotificationManagementService = "NotificationManagementService";
        public const string StorageManagementService = "StorageManagementService";
        public const string UserManagementService = "UserManagementService";
        #endregion
        #region Database Table Names
        public const string AccessLogs = "AccessLogs";
        public const string Devices = "Devices";
        public const string Documents = "Documents";
        public const string Notifications = "Notifications";
        public const string Storages = "Storages";
        public const string UserAccounts = "UserAccounts";
        #endregion
    }
}
