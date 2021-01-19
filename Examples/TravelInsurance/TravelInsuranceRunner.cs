using Gehtsoft.PDFFlow.Builder;

namespace TravelInsurance
{
    public static class TravelInsuranceRunner
    {
        public static DocumentBuilder Run()
        {
            TravelInsuranceBuilder travelInsuranceBuilder = new TravelInsuranceBuilder() { };

            DocumentBuilder doc = travelInsuranceBuilder
                .CreateDocumentBuilder();

            return doc;
        }
    }
}