﻿namespace TechnicalTestAPI.Models.ServiceModels
{
    public class UserAccounts
    {
        public string userId { get; set; }
        public string userEmail { get; set; }
        public string userName { get; set; }
        public string lastAccessTime { get; set; }
        public string lastAccessDevice { get; set; }
        public string lastAccessIp { get; set; }
        public string accountType { get; set; }
    }
}
