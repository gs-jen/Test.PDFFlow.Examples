using Gehtsoft.PDFFlow.Builder;
using Gehtsoft.PDFFlow.Models.Shared;
using Gehtsoft.PDFFlow.Models.Enumerations;
using Gehtsoft.PDFFlow.Utils;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace TravelInsurance
{
    static class TravelInsuranceFormBuilder
    {
        internal static readonly string CheckboxPath = Path.Combine(
            Directory.GetCurrentDirectory(), "images", "TravelInsurance_Checkbox.png");

        public static TableBuilder CreateTable(SectionBuilder sectionBuilder, 
            int columnNumber, float topMargin = 13)
        {
            return sectionBuilder
                .AddTable(Enumerable.Repeat(XUnit.FromPercent(100f / columnNumber), 
                columnNumber).ToArray())
                    .SetMarginTop(topMargin)
                    .SetContentRowStyleFont(Fonts.Helvetica(7))
                    .SetBorder(Stroke.None)
                    .SetContentRowBorderWidth(0, 0, 0, 0);
        }

        public static void AddTitle(TableBuilder tableBuilder, string title, int columnNumber = 3)
        {
            tableBuilder
                .AddRow()
                    .SetBorderWidth(0, 0, 0, 2)
                    .SetBorderStroke(Stroke.Solid)
                    .AddCell()
                        .SetColSpan(columnNumber)
                        .AddParagraph(title)
                            .SetFontSize(11)
                            .SetBold()
                            .SetLineSpacing(0.95f);
        }

        public static void CreateRow(TableBuilder tableBuilder, 
            Dictionary<string, int> rowContents, float bottomPadding = 17)
        {
            var rowBuilder = tableBuilder.AddRow()
                .SetBorderWidth(0, 0, 0, 0.5f)
                .SetBorderStroke(Stroke.Solid);

            foreach (KeyValuePair<string, int> cellContent in rowContents)
            {
                rowBuilder
                    .AddCell()
                        .SetColSpan(cellContent.Value)
                        .SetPadding(1, 1, 0, bottomPadding)
                        .SetFont(Fonts.Helvetica(7f))
                        .AddParagraph(cellContent.Key)
                            .SetLineSpacing(0.95f);
                    
            }
        }

    }
}
