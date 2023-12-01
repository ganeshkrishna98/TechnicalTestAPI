namespace UniversityOfNottinghamAPI.Models.DatabaseTableModels
{
    public class TableColumns
    {
        public const string DocumentsColumns = "documentId,documentName,fileName,approvalStatus,authorUserId,authorName,lastModifiedUserId,lastModifiedUserName,lastAccessedUserName,lastAccessedUserId";
        public const string UserAccountColumns = "userId,userEmail,userSecret,userName,lastAccessTime,lastAccessDevice,lastAccessIp,accountType";
        public const string Authentication = "";
    }
}