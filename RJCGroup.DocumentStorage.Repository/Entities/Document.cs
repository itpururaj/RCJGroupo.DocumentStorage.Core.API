using RJCGroup.DocumentStorage.Repository.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RJCGroup.DocumentStorage.Repository.Entities
{
    [Table("Documents")]
    public class Document
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal FileSize { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public DateTime DocumentDate { get; set; }

        public DocumentContent DocumentContent { get; set; }
    }
}
