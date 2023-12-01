using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityOfNottinghamAPI.Models.ServerModels
{
    public class DocumentsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string documentId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string documentName { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string fileName { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string approvalStatus { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string authorUserId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string authorName { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string lastModifiedUserId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string lastModifiedUserName { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string lastAccessedUserName { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string lastAccessedUserId { get; set; }
    }
}
