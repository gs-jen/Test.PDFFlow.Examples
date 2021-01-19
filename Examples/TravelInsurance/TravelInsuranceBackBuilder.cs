using Gehtsoft.PDFFlow.Builder;
using static TravelInsurance.TravelInsuranceBuilder;

namespace TravelInsurance
{
    internal class TravelInsuranceBackBuilder
    {
        internal void Build(DocumentBuilder documentBuilder)
        {
            var sectionBuilder = documentBuilder.AddSection();
            sectionBuilder
                .SetOrientation(Orientation)
                .SetMargins(Margins);

            new TravelInsuranceSectionCBuilder().Build(sectionBuilder);
            new TravelInsuranceSectionDBuilder().Build(sectionBuilder);
            new TravelInsuranceSectionEBuilder().Build(sectionBuilder);
            new TravelInsuranceSectionFBuilder().Build(sectionBuilder);
        }
    }
}