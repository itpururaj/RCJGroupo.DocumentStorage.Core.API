using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using RJCGroup.DocumentStorage.Controllers;
using RJCGroup.DocumentStorage.Service;
using RJCGroup.DocumentStorage.Service.Models;
using System;
using System.Threading.Tasks;

namespace RJCGroup.DocumentStorage.UnitTests
{
    public class DocumentControllerTests
    {
        private DocumentController _documentController;
        private readonly Mock<IDocumentService> _documentServiceMock;
        private readonly Mock<ILogger<DocumentController>> _loggerMock;

        public DocumentControllerTests()
        {
            _documentServiceMock = new Mock<IDocumentService>();
            _loggerMock = new Mock<ILogger<DocumentController>>();
        }

        [SetUp]
        public void Setup()
        {
            _documentController = new DocumentController(_documentServiceMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task Should_Upload_File_Successfully()
        {
            // Arrange
            var documentId = Guid.NewGuid();
            var document = new DocumentModel(); // // We can set the value in DocumentModel

            _documentServiceMock.Setup(x => x.GetDocumentAsync(documentId))
                .Returns(Task.FromResult<DocumentModel>(document));

            // Act
            var result = await _documentController.GetDocument(documentId);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);

            var objectResult = (ObjectResult)result;
            Assert.IsTrue(objectResult.StatusCode.Equals(200));
            Assert.IsInstanceOf<DocumentModel>(objectResult.Value);

            // We can check the value in DocumentModel
        }
    }
}