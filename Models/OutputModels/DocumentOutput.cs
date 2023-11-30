using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityOfNottinghamAPI.Models.OutputModels
{
    public class DocumentOutput
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Document_ID { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Document_Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string File_Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Approval_Status { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Author_User_ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Author_Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Last_Modified_User_ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Last_Modified_User_Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Last_Accessed_User_Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Last_Accessed_User_ID { get; set; }
    }
}