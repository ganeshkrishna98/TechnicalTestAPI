namespace UniversityOfNottinghamAPI.Models.ServiceModels
{
    public class UserManagement
    {
        public string User_ID { get; set; }
        public string User_Email { get; set; }
        public string User_Secret { get; set; }
        public string User_Name { get; set; }
        public string Last_Access_Time { get; set; }
        public string Last_Access_Device { get; set; }
        public string Last_Access_IP { get; set; }
        public string Account_Type { get; set; }
    }
}
