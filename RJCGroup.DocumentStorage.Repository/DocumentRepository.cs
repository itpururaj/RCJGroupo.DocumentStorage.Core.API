using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RJCGroup.DocumentStorage.Repository.Context;
using RJCGroup.DocumentStorage.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RJCGroup.DocumentStorage.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DocumentContext _documentContext;
        private readonly ILogger<DocumentRepository> _logger;

        public DocumentRepository(DocumentContext documentContext, ILogger<DocumentRepository> logger)
        {
            _documentContext = documentContext ?? throw new ArgumentNullException(nameof(documentContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Document> GetDocumentAsync(Guid id)
        {
            _logger.LogDebug($"GetDocumentAsync Request Id: {id}");

            var result = await _documentContext.Documents.Include(x => x.DocumentContent)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            _logger.LogDebug($"GetDocumentAsync Response: {result}");

            return await _documentContext.Documents.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<Document>> GetDocumentsAsync()
        {
            return await _documentContext.Documents.ToListAsync();
        }

        // TODO: Document Order can be separated in different model. So no need to send whole documents.
        public async Task<IEnumerable<Document>> ReOrderDocumentsAsync(IEnumerable<Document> documents)
        {
            // TODO: Reorder codd here.

            await _documentContext.SaveChangesAsync();

            return _documentContext.Documents;
        }

        public async Task<Document> UploadDocumentAsync(Document document)
        {
            // We can use automapper to map the models but showing different approach here.
            var documentId = Guid.NewGuid();
            var docDate = DateTime.Now;

            var newDocument = new Document()
            {
                Id = documentId,
                Name = document.Name,
                FileSize = document.DocumentContent.Content.Length,
                DocumentContent = new DocumentContent()
                {
                    Id = Guid.NewGuid(),
                    Content = document.DocumentContent.Content,
                    DocumentId = documentId,
                    UploadDate = docDate
                },
                Order = _documentContext.Documents.Count() + 1,
                DocumentDate = docDate
            };

            _documentContext.Documents.Add(newDocument);

            await _documentContext.SaveChangesAsync();

            return newDocument;
        }

        public void DeleteDocument(Guid documentId)
        {
            var document = _documentContext.Documents.FirstOrDefault(x => x.Id.Equals(documentId));

            if (document != null)
            {
                _documentContext.Documents.Remove(document);
                _documentContext.SaveChanges();
            }
        }
    }
}
