using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RJCGroup.DocumentStorage.Repository.Entities
{
    [Table("DocumentContent")]
    public class DocumentContent
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid DocumentId { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        public DateTime UploadDate { get; set; }

        public Document Document { get; set; }
    }
}
