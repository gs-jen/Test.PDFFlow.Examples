using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Gehtsoft.PDFFlow.MultilevelList.Model;
using Gehtsoft.PDFFlow.Builder;
using Gehtsoft.PDFFlow.Models.Shared;
using Gehtsoft.PDFFlow.Models.Enumerations;
using Gehtsoft.PDFFlow.Models.Content;
using Gehtsoft.PDFFlow.Models.Document;

namespace Gehtsoft.PDFFlow.MultilevelList
{
    internal static class MultilevelListExample
    {
        #region Fields

        private static readonly string PdfFile;
        private static readonly string ProjectDir;
        private static readonly string MultilevelListJsonFile;
        private static readonly string MultilevelListJsonContent;
        public static List<MultilevelListData> MultilevelListData { get; }
        private static readonly Font DocumentFont;
        private static readonly Font ItalicFont;
        private static readonly Font BoldFont;
        private static readonly Font TitleFont;
        private static readonly string ImageUrl;

        #endregion Fields

        #region Constructors

        static MultilevelListExample()
        {
            PdfFile = Path.Combine(Environment.CurrentDirectory, "MultilevelList.pdf");
            ProjectDir = Directory.GetCurrentDirectory();
            MultilevelListJsonFile = Path.Combine(ProjectDir, "Content", "MultilevelList.json");
            MultilevelListJsonContent = File.ReadAllText(MultilevelListJsonFile);
            MultilevelListData = JsonConvert.DeserializeObject<List<MultilevelListData>>(MultilevelListJsonContent);
            DocumentFont = new Font { Name = FontNames.Courier, Size = 14f, Color = Color.Black };
            ItalicFont = DocumentFont.Clone(); ItalicFont.Name = "Times-Italic";
            BoldFont = DocumentFont.Clone(); BoldFont.Name = "Courier-Bold";
            TitleFont = BoldFont.Clone(); TitleFont.Size = 28f;
            ImageUrl = Path.Combine(ProjectDir, "Images", "Product.png");
        }

        #endregion Constructors

        #region Methods

        internal static void GenerateExample()
        {
            Console.WriteLine("Generating file " + PdfFile);
            if (File.Exists(PdfFile))
                File.Delete(PdfFile);
            DocumentBuilder
                .New()
                .AddMultilevelListSection()
                .Build(PdfFile);
        }

        internal static DocumentBuilder AddMultilevelListSection(this DocumentBuilder builder)
        {
            builder.AddSection(s =>
            {
                SetSectionSettings(s);

                AddMultilevelListTitle(s);

                AddMultilevelListData(s);                                
            });
            return builder;
        }

        internal static void SetSectionSettings(Section s)
        {
            s.SetMargins(30).SetSize(PaperSize.A4).SetOrientation(PageOrientation.Portrait).SetNumerationStyle(NumerationStyle.Arabic);
        }

        internal static void AddMultilevelListTitle(Section s)
        {            
            s.AddParagraph("Warehouse shipments").SetMargins(20, 0, 0, 10).SetFont(TitleFont).SetAlignment(HorizontalAlignment.Center);
            s.AddLine().SetColor(Color.FromRgba(0.6, 0.3, 0.0)).SetStyle(Stroke.Solid).SetWidth(2);
        }

        internal static void AddMultilevelListData(Section s)
        {
            void AddLevel(uint level, string text)
            {
                Font font;
                ListBullet listBullet = ListBullet.Bullet;
                switch (level)
                {
                    case 0:
                        font = new Font
                        {
                            Name = "Times-Italic",
                            Size = 20f,
                            Color = Color.FromRgba(1, 0.3, 0.0)
                        };
                        break;
                    case 1:
                        font = new Font
                        {
                            Name = FontNames.Times,
                            Size = 16f,
                            Color = Color.FromRgba(0.8, 0.3, 0.0)
                        };
                        break;
                    case 2:
                        font = new Font
                        {
                            Name = FontNames.Times,
                            Size = 14f,
                            Color = Color.FromRgba(0.5, 0.3, 0.0)
                        };                        
                        break;
                    case 3:
                        font = new Font
                        {
                            Name = FontNames.Times,
                            Size = 10f,
                            Color = Color.Black
                        };
                        listBullet = ListBullet.Dash;
                        break;
                    default:
                        return;
                }
                    s.AddParagraph(p =>
                    {
                        p.AddText((element) =>
                        {
                            element.SetFont(font);
                            element.AddContent(text);
                        });
                        if (level == 2)
                        {
                            p.SetListNumbered(NumerationStyle.Arabic, level, 20f);
                            p.AddInlineImage(ImageUrl, ScalingMode.Normal, 32, 13);
                        }
                        else
                        {
                            p.SetListBulleted(listBullet, level, 20f);
                        }
                    });                
            }

            foreach (var shipment in MultilevelListData)
                {
                    AddLevel(0, "Shipment "+shipment.Shipment);
                    if (shipment.Orders != null)
                        foreach (var order in shipment.Orders)
                        {
                            AddLevel(1, "Order " + order.Order + ", " + order.Customer);
                            if (order.Products != null)
                            foreach (var product in order.Products)
                            {                                    
                                AddLevel(2, "");
                                AddLevel(3, "Product Code: " + product.Code);
                                AddLevel(3, "Product Name: " + product.Name);
                            }
                        }
                }                       
        }       

        #endregion Methods
    }
}
