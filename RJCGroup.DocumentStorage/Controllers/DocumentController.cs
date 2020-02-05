using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RJCGroup.DocumentStorage.Service;
using RJCGroup.DocumentStorage.Service.Models;
using System;
using System.Threading.Tasks;

namespace RJCGroup.DocumentStorage.Controllers
{
    [ApiController]
    [Route("api/Document")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly ILogger<DocumentController> _logger;

        public DocumentController(IDocumentService documentService, ILogger<DocumentController> logger)
        {
            _documentService = documentService ?? throw new ArgumentNullException(nameof(_documentService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDocument(Guid id)
        {
            _logger.LogDebug($"Get Request Id: {id}");
            var document = await _documentService.GetDocumentAsync(id);
            _logger.LogDebug($"Get Response: {document}");
            return Ok(document);
        }

        [HttpGet]
        [Route("")]
        [Route("/")]
        public async Task<IActionResult> GetDocuments()
        {
            var documents = await _documentService.GetDocumentsAsync();

            return Ok(documents);
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UploadDocument(DocumentModel document)
        {
            var documents = await _documentService.UploadDocumentAsync(document);

            return Ok(documents);
        }

        [HttpGet]
        [Route("Download")]
        public async Task<IActionResult> DownloadDocument(Guid id)
        {
            var document = await _documentService.GetDocumentAsync(id);
            var fileName = $"{document.Name}.pdf"; // Filename can be determined based on requirement

            return File(document.FileContent.Content, "application/octet-stream", fileName);
        }

        [HttpGet]
        [Route("Delete")]
        public IActionResult DeleteDocument(Guid document)
        {
            var doc = _documentService.GetDocumentAsync(document)
                .GetAwaiter()
                .GetResult();

            if (doc == null)
            {
                return NotFound();
            }

            _documentService.DeleteDocument(document);

            return Ok();
        }
    }
}