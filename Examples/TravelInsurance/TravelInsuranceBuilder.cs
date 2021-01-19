using Gehtsoft.PDFFlow.Builder;
using Gehtsoft.PDFFlow.Models.Shared;
using Gehtsoft.PDFFlow.Models.Enumerations;
using System.IO;

namespace TravelInsurance
{
    internal class TravelInsuranceBuilder
    {
        internal const PageOrientation Orientation = PageOrientation.Portrait;
        internal static readonly Box Margins = new Box(29, 21, 29, 0);
        

        public DocumentBuilder CreateDocumentBuilder()
        {
            //Create document builder:
            DocumentBuilder documentBuilder = DocumentBuilder.New();

            //Build Front page
            new TravelInsuranceFrontBuilder()
                .Build(documentBuilder);

            //Build Back page
            new TravelInsuranceBackBuilder()
                .Build(documentBuilder);
            return documentBuilder;
        }
    }
}