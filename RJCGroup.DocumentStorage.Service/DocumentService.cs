using AutoMapper;
using Microsoft.Extensions.Logging;
using RJCGroup.DocumentStorage.Repository;
using RJCGroup.DocumentStorage.Repository.Entities;
using RJCGroup.DocumentStorage.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RJCGroup.DocumentStorage.Service
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DocumentService> _logger;

        public DocumentService(IDocumentRepository documentRepository, IMapper mapper, ILogger<DocumentService> logger)
        {
            _documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<DocumentModel> GetDocumentAsync(Guid id)
        {
            _logger.LogDebug($"GetDocumentAsync Request Id: {id}");

            // Get the data from repository
            var repoResponse = await _documentRepository.GetDocumentAsync(id);

            // Using auto mapper to map the data to service model.
            var result = _mapper.Map<DocumentModel>(repoResponse);

            //result.Length = repoResult.DocumentContent.Content.Length;
            _logger.LogDebug($"GetDocumentAsync Response: {result}");

            return result;
        }

        public async Task<IEnumerable<DocumentModel>> GetDocumentsAsync()
        {
            var repoResponse = await _documentRepository.GetDocumentsAsync();
            var result = _mapper.Map<IEnumerable<DocumentModel>>(repoResponse);

            return result;
        }

        public async Task<IEnumerable<DocumentModel>> ReOrderDocumentsAsync(IEnumerable<DocumentModel> documents)
        {
            throw new NotImplementedException();
        }

        public async Task<DocumentModel> UploadDocumentAsync(DocumentModel document)
        {
            var repoDocModel = _mapper.Map<Document>(document);
            var repoResult = await _documentRepository.UploadDocumentAsync(repoDocModel);
            var result = _mapper.Map<DocumentModel>(repoResult);

            return result;
        }

        public void DeleteDocument(Guid documentId)
        {
            _documentRepository.DeleteDocument(documentId);
        }

        public Task<DocumentContentModel> DownloadDocumentsAsync(Guid documentId)
        {
            throw new NotImplementedException();
        }
    }
}
