using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RJCGroup.DocumentStorage.Tests.Steps
{
    [Binding]
    public sealed class Document
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public Document(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [When(@"I send the PDF to the API")]
        public void WhenISendThePDFToTheAPI()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"it is uploaded successfully")]
        public void ThenItIsUploadedSuccessfully()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I send the non-pdf to the API")]
        public void WhenISendTheNon_PdfToTheAPI()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the API does not accept the file and returns the appropriate messaging and status")]
        public void ThenTheAPIDoesNotAcceptTheFileAndReturnsTheAppropriateMessagingAndStatus()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I send the pdf to the API")]
        public void WhenISendThePdfToTheAPI()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I call the API to get a list of documents")]
        public void WhenICallTheAPIToGetAListOfDocuments()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"a list of PDFs’ is returned with the following properties: name, location, file-size")]
        public void ThenAListOfPDFsIsReturnedWithTheFollowingPropertiesNameLocationFile_Size()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I choose to re-order the list of PDFs’")]
        public void WhenIChooseToRe_OrderTheListOfPDFs()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the list of PDFs’ is returned in the new order for subsequent calls to the API")]
        public void ThenTheListOfPDFsIsReturnedInTheNewOrderForSubsequentCallsToTheAPI()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I request the location for one of the PDF's")]
        public void WhenIRequestTheLocationForOneOfThePDFS()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"PDF is downloaded")]
        public void ThenPDFIsDownloaded()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I request to delete the PDF")]
        public void WhenIRequestToDeleteThePDF()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the PDF is deleted and will no longer return from the list API and can no longer be downloaded from its location directly")]
        public void ThenThePDFIsDeletedAndWillNoLongerReturnFromTheListAPIAndCanNoLongerBeDownloadedFromItsLocationDirectly()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I request to delete the non-existing pdf")]
        public void WhenIRequestToDeleteTheNon_ExistingPdf()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the API returns an appropriate response")]
        public void ThenTheAPIReturnsAnAppropriateResponse()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
