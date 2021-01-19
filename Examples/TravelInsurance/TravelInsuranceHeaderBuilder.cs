using System.IO;
using Gehtsoft.PDFFlow.Builder;
using Gehtsoft.PDFFlow.Models.Enumerations;
using Gehtsoft.PDFFlow.Models.Shared;
using Gehtsoft.PDFFlow.Utils;

namespace TravelInsurance
{
    internal class TravelInsuranceHeaderBuilder
    {
        internal void Build(SectionBuilder sectionBuilder)
        {
            sectionBuilder
                .AddTable()
                    .SetContentRowStyleFont(Fonts.Helvetica(20f))
                    .SetBorder(Stroke.None)
                    .SetWidth(XUnit.FromPercent(100))
                    .AddColumnPercentToTable("", 50)
                    .AddColumnPercentToTable("", 50)
                    .AddRow()
                        .AddCell()
                            .SetPadding(2, 4, 0, 0)
                            .SetBold()
                            .AddParagraph("Travel Insurance")
                            .SetLineSpacing(0.8f)
                            .AddText("\nClaim Form")
                            .SetFontColor(Color.Gray)
                    .ToRow()
                        .AddCell()
                            .AddImage(Path.Combine(Directory.GetCurrentDirectory(), 
                                        "images", "TravelInsurance_Logo.png"))
                            .SetAlignment(HorizontalAlignment.Right)
                            .SetScale(ScalingMode.UserDefined)
                            .SetWidth(250)
                .ToTable()
                    .AddRow()
                        .AddCell()
                            .SetColSpan(2)
                            .SetPadding(0, 13, 0, 8)
                            .SetFontSize(7)
                            .AddParagraphToCell("PLEASE COMPLETE ALL SECTIONS TO FACILITATE " +
                                                "THE PROCESSING OF YOUR APPLICATION ")
                .ToTable()
                    .AddRow()
                        .AddCell()
                            .SetColSpan(2)
                            .SetBorder(Stroke.Solid, Color.Black, 0.5f)
                            .SetPadding(8)
                            .SetFontSize(8)
                            .AddParagraph()
                                .AddTextToParagraph("Required documents – For all travel claims " +
                                                    "please submit air tickets and boarding pass. " +
                                                    "For annual plans, please provide a copy of " +
                                                    "the passport showing duration of trip. " +
                                                    "We reserve the right to request for " +
                                                    "additional information. To enable us to " +
                                                    "process your claim expeditiously, " +
                                                    "please return the duly completed Claim Form" +
                                                    " with supporting documents." +
                                                     "\nPlease direct the claim form and all " +
                                                     "correspondence to:" +
                                                     "\nSample Company Travel Claims Unit" +
                                                     "\nc/o Sample Company Ltd, No. 5 Streenname " +
                                                     "#33-01, Sample city 12345" +
                                                     "\n\nThe acceptance of this Form is NOT an " +
                                                     "admission of liability on the part of " +
                                                     "Sample Compan(“the Company”)." +
                                                     "Any documentary proof or report required " +
                                                     "by the Company shall be furnished at the " +
                                                     "expense of the Policyholder or Claimant.\n");

        }
    }
}
