using UniversityOfNottinghamAPI.Models.OutputModels;

namespace UniversityOfNottinghamAPI.ModelMapping
{
    public class DocumentModelMapping:IDocumentModelMapping
    {
        public List<DocumentOutput> DocumentMapping(List<object[]> array)
        {
            var outputList = new List<DocumentOutput>();
            foreach (var item in array)
            {
                var output = new DocumentOutput
                {
                    Document_ID = item[0].ToString(),
                    Document_Name = item[1].ToString(),
                    File_Name = item[2].ToString(),
                    Approval_Status = item[3].ToString(),
                    Author_User_ID = item[4].ToString(),
                    Author_Name = item[5].ToString(),
                    Last_Modified_User_ID = item[6].ToString(),
                    Last_Modified_User_Name = item[7].ToString(),
                    Last_Accessed_User_Name = item[8].ToString(),
                    Last_Accessed_User_ID = item[9].ToString()
                };
                outputList.Add(output);
            }
            return outputList;
        }
    }
}
