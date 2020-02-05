using RJCGroup.DocumentStorage.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RJCGroup.DocumentStorage.Service
{
    public interface IDocumentService
    {
        Task<DocumentModel> GetDocumentAsync(Guid id);

        Task<IEnumerable<DocumentModel>> GetDocumentsAsync();

        Task<DocumentModel> UploadDocumentAsync(DocumentModel document);

        Task<IEnumerable<DocumentModel>> ReOrderDocumentsAsync(IEnumerable<DocumentModel> documents);

        void DeleteDocument(Guid documentId);

        Task<DocumentContentModel> DownloadDocumentsAsync(Guid documentId);
    }
}
