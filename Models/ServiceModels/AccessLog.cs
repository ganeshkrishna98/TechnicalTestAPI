﻿namespace TechnicalTestAPI.Models.ServiceModels
{
    public class AccessLog
    {
        public string userId { get; set; }
        public string userEmail { get; set; }
        public string userName { get; set; }
        public string accessTime { get; set; }
        public string accessDate { get; set; }
        public string accessDevice { get; set; }
        public string accessIp { get; set; }
        public string accessedDocumentId { get; set; }
        public string accessedDocumentName { get; set; }
        public string actionPerformed { get; set; }
    }
}
