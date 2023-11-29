namespace UniversityOfNottinghamAPI.Models.InputModels
{
    public class CreateDocumentInput
    {
        public string Document_ID { get; set; }
        public string Document_Name { get; set; }
        public string File_Name { get; set; }
        public string Approval_Status { get; set; }
        public string Author_User_ID { get; set; }
        public string Author_Name { get; set; }
        public string Last_Modified_User_ID { get; set; }
        public string Last_Modified_User_Name { get; set; }
        public string Last_Accessed_User_Name { get; set; }
        public string Last_Accessed_User_ID { get; set; }
    }
}