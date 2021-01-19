using Gehtsoft.PDFFlow.Builder;
using System.IO;
using static TravelInsurance.TravelInsuranceBuilder;

namespace TravelInsurance
{
    internal class TravelInsuranceFrontBuilder
    {
        public void Build(DocumentBuilder documentBuilder)
        {
            var sectionBuilder = documentBuilder.AddSection()
                .SetOrientation(Orientation)
                .SetMargins(Margins);

            new TravelInsuranceHeaderBuilder().Build(sectionBuilder);
            new TravelInsuranceGeneralInfoBuilder().Build(sectionBuilder);
            new TravelInsuranceSectionABuilder().Build(sectionBuilder);
            new TravelInsuranceSectionBBuilder().Build(sectionBuilder);
        }
    }
}