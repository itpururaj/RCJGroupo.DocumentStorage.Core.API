Feature: Document
	In order to provide upload and download feature to the client
	As a publisher
	I would like to upload, manually re-order, download and delete pdf's
    So, I can place a list of documents on my client apps and website for users to download
    And in an arbitrary order of my choosing

@documentUpload
Scenario: Given I have a PDF to upload
When I send the PDF to the API
Then it is uploaded successfully
 
@documentUpload
Scenario: Given I have a non-pdf to upload
When I send the non-pdf to the API
Then the API does not accept the file and returns the appropriate messaging and status
 
@documentUpload
Scenario: Given I have a max pdf size of 5MB
When I send the pdf to the API
Then the API does not accept the file and returns the appropriate messaging and status
 
@documentListing
Scenario: Given I call the new document service API
When I call the API to get a list of documents
Then a list of PDFs’ is returned with the following properties: name, location, file-size
 
@documentReorder
Scenario: Given I have a list of PDFs’
When I choose to re-order the list of PDFs’
Then the list of PDFs’ is returned in the new order for subsequent calls to the API
 
@documentDownload
Scenario: Given I have chosen a PDF from the list API
When I request the location for one of the PDF's
Then PDF is downloaded
 
@documentDeletion
Scenario: Given I have selected a PDF from the list API that I no longer require
When I request to delete the PDF
Then the PDF is deleted and will no longer return from the list API and can no longer be downloaded from its location directly
 
@documentDeletion
Scenario: Given I attempt to delete a file that does not exist
When I request to delete the non-existing pdf
Then the API returns an appropriate response
