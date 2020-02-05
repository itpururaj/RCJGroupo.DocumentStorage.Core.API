using System;

namespace RJCGroup.DocumentStorage.Service.Models
{
    public class DocumentModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal FileSize { get; protected set; }

        public int Order { get; set; }

        public DocumentContentModel FileContent { get; set; }
    }
}
