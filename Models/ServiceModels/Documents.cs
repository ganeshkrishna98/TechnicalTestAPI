namespace TechnicalTestAPI.Models.ServiceModels
{
    public class Documents
    {
        public string documentId { get; set; }
        public string documentName { get; set; }
        public string fileName { get; set; }
        public string approvalStatus { get; set; }
        public string authorUserId { get; set; }
        public string authorName { get; set; }
        public string lastModifiedUserId { get; set; }
        public string lastModifiedUserName { get; set; }
        public string lastAccessedUserName { get; set; }
        public string lastAccessedUserId { get; set; }
    }
}