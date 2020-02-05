
using RJCGroup.DocumentStorage.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RJCGroup.DocumentStorage.Repository
{
    public interface IDocumentRepository
    {
        Task<Document> GetDocumentAsync(Guid id);

        Task<IEnumerable<Document>> GetDocumentsAsync();

        Task<Document> UploadDocumentAsync(Document document);

        Task<IEnumerable<Document>> ReOrderDocumentsAsync(IEnumerable<Document> documents);

        void DeleteDocument(Guid documentId);
    }
}
