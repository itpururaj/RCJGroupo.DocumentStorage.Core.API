using System;
using System.Collections.Generic;
using System.Text;

namespace RJCGroup.DocumentStorage.Service.Models
{
    public class DocumentContentModel
    {
        public Guid Id { get; set; }

        public Guid DocumentId { get; set; }

        public byte[] Content { get; set; }

        public DateTime UploadDate { get; set; }
    }
}
