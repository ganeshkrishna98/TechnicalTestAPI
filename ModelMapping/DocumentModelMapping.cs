using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.ModelMapping
{
    public class DocumentModelMapping:IDocumentModelMapping
    {
        public async Task<List<Documents>> DocumentMapping(List<object[]> array)
        {
            var outputList = new List<Documents>();
            foreach (var item in array)
            {
                var output = new Documents
                {
                    documentId = item[0].ToString(),
                    documentName = item[1].ToString(),
                    fileName = item[2].ToString(),
                    approvalStatus = item[3].ToString(),
                    authorUserId = item[4].ToString(),
                    authorName = item[5].ToString(),
                    lastModifiedUserId = item[6].ToString(),
                    lastModifiedUserName = item[7].ToString(),
                    lastAccessedUserName = item[8].ToString(),
                    lastAccessedUserId = item[9].ToString()
                };
                outputList.Add(output);
            }
            return outputList;
        }
    }
}
