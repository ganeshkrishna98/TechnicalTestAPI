namespace UniversityOfNottinghamAPI.Models.DatabaseTableModels
{
    public class TableColumns
    {
        public const string AccessLogs = "userId,userEmail,userName,accessTime,accessDate,accessDevice,accessIp,accessedDocumentId,accessedDocumentName,actionPerformed";
        public const string Devices = "deviceId,deviceName,deviceType,deviceOs,userId,userName,lastAccessedDate,lastAccessedTime";
        public const string DocumentsColumns = "documentId,documentName,fileName,approvalStatus,authorUserId,authorName,lastModifiedUserId,lastModifiedUserName,lastAccessedUserName,lastAccessedUserId";
        public const string Notifications = "notificationId,notificationName,notificationContent,createdDate,createdTime,createdUserId,createdUserName";
        public const string Storages = "storageId,stroageName,createdDate,createdTime,createdUserId,createdUserName";
        public const string UserAccountColumns = "userId,userEmail,userName,lastAccessTime,lastAccessDevice,lastAccessIp,accountType";
    }
}