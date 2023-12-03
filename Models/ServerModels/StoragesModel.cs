﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityOfNottinghamAPI.Models.ServerModels
{
    public class StoragesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string storageId { get; set; }
        public string stroageName { get; set; }
        public string createdDate { get; set; }
        public string createdTime { get; set; }
        public string createdUserId { get; set; }
        public string createdUserName { get; set; }
    }
}