This sample set consists of prebuild release version of
Gehtsoft.PDFFlow library.

-------------
Prerequisites
-------------

1) Visual Studio 2017 or above is installed.

To install a community version of Visual Studio use
the following link:

https://visualstudio.microsoft.com/vs/community/

Please make sure that the way you are going to use Visual
Studio is allowed by the community license. You may need
to buy Standard or Professional Edition.

2) .NET Core Framework SDK 2.1 or above is installed.
To install the framework use the following link:

https://dotnet.microsoft.com/download

-------------------------------------
What is Gehtsoft.PDFFlow library for?
-------------------------------------

Gehtsoft.PDFFlow is made to simplify generation of the PDF
documents from .NET applications.

It is build on the base of Haru library (http://libharu.org/) and provides
the set of classes that allows the user to define a true document
(as a sequence of sections with their own layouts, paragraphs, images,
tables) and takes care on layouting the document content into PDF document.

The major benefit of this library is that the developer does not need
any special document publishing knowledge except the knowledge that any
qualified office user already has and the developer concentrates on
solving the business task (which exact information needs to be printed)
rather than fighting with complex repetitive drawing and layouting
"magic" operation that are involved into of hand-making of a PDF document.

The documentation for the library is available by the link below
http://docs.gehtsoftusa.com/pdfflow/web-content.html

-------
License
-------

The source code of the examples is
provided under Apache license
(https://en.wikipedia.org/wiki/Apache_License).

The Haru.Net package located in .nuget folder
is provided under zLib license
(https://github.com/libharu/libharu/blob/master/LICENCE)

Gehtsoft.PDFFlow package located in .nuget folder is provided
to build and evaluate examples ONLY. Using this package
in any application, even if such application is derived under
Apache license from the provided examples, is
strictly prohibited and violates conditions of use.

You must obtain Gehtsoft.PDFFlow package either under
free community license for open source projects or for
development purposes, or you must buy a commercial license in
order to use in a real business process, even if the product is
used for internal business processes or for marketing
purposes (e.g. for demonstration to customers).

Should you have any question about the licensing or prices please
feel free to contact Gehtsoft USA LLC via contact@gehtsoftusa.com

------------------------------------
The following examples are included:
------------------------------------

1) Gehtsoft.PDFFlow.Contract

An example of the home rent contract generation.

The example demonstrates a simple textual multi-page document that
includes repeating footer with automatic page numbering and consists of two
distinctive sections with different content of a footer area (initials area
on the all pages of the contract except the page with signatures).

The contract content is located in the file Content/contract.txt

The values for the contract fields are located in the file Content/contract_dictionary.json

The example creates the file Contract.pdf in the output (bin/(debug|release)/netcoreapp2.1 folder.

2) Gehtsoft.PDFFlow.Invoice

The example demonstrates a simple document that uses a table to customize layout
of the information on a page.

The invoice source data is located in the file Content/invoice.json

The example creates the file Invoice.pdf in the output (bin/(debug|release)/netcoreapp2.1 folder.

3) Gehtsoft.PDFFlow.LogBook

The example demonstrates a multi-page document that consists of a complex table
that spreads into two-pages layout (i.e. half of a table is printed on the left page
and half of a table is printed on the right page).

Pay attention that the developer just defines the table data, all complex work related
to layouting the data, including a complex job of making rows on the left and right sides
of the table matching by the position and height, is made by the library.

The mock data used to generate the table is located in the file Content/operations_log.json

The example creates the file LogBook.pdf in the output (bin/(debug|release)/netcoreapp2.1 folder.

4) Gehtsoft.PDFFlow.TutorialC

The example demonstrates an example of programmer's documentation made as multi-page document
with complex formatting.

The example creates the file TutorialC.pdf in the output (bin/(debug|release)/netcoreapp2.1 folder.