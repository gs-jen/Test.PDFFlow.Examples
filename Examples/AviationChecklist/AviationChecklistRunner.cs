using AviationChecklistData.Model;
using Gehtsoft.PDFFlow.Builder;
using Newtonsoft.Json;
using System.IO;

namespace AviationChecklist
{
    public static class AviationChecklistRunner
    {
        public static DocumentBuilder Run()
        {
            string aviationJsonFile = CheckFile(Path.Combine("Content", "aviation-checklist.json"));
            string aviationJsonContent = File.ReadAllText(aviationJsonFile);

            AviationData aviationData =
               JsonConvert.DeserializeObject<AviationData>(aviationJsonContent);

            AviationChecklistBuilder AviationChecklistBuilder =
                new AviationChecklistBuilder();

            AviationChecklistBuilder.AviationData = aviationData;

            return AviationChecklistBuilder.Build();
        }
        private static string CheckFile(string file)
        {
            if (!File.Exists(file))
            {
                throw new IOException("File not found: " + Path.GetFullPath(file));
            }
            return file;
        }
    }
}