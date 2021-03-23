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

            string safetyJsonFile = CheckFile(Path.Combine("Content", "safety-inspection.json"));
            string safetyJsonContent = File.ReadAllText(safetyJsonFile);

            string beforeTaxiJsonFile = CheckFile(Path.Combine("Content", "before-taxi.json"));
            string beforeTaxiJsonContent = File.ReadAllText(beforeTaxiJsonFile);

            string beforeTakeoffJsonFile = CheckFile(Path.Combine("Content", "before-takeoff-to-the-line.json"));
            string beforeTakeoffJsonContent = File.ReadAllText(beforeTakeoffJsonFile);

            string belowTheLine1JsonFile = CheckFile(Path.Combine("Content", "below-the-line-1.json"));
            string belowTheLine1JsonContent = File.ReadAllText(belowTheLine1JsonFile);

            string afterTakeoffJsonFile = CheckFile(Path.Combine("Content", "after-takeoff.json"));
            string afterTakeoffJsonContent = File.ReadAllText(afterTakeoffJsonFile);

            string beforeStartJsonFile = CheckFile(Path.Combine("Content", "before-start-to-the-line.json"));
            string beforeStartJsonContent = File.ReadAllText(beforeStartJsonFile);


            string belowTheLine2JsonFile = CheckFile(Path.Combine("Content", "below-the-line-2.json"));
            string belowTheLine2JsonContent = File.ReadAllText(belowTheLine2JsonFile);

            string descentJsonFile = CheckFile(Path.Combine("Content", "descent.json"));
            string descentJsonContent = File.ReadAllText(descentJsonFile);

            string approachJsonFile = CheckFile(Path.Combine("Content", "approach.json"));
            string approachJsonContent = File.ReadAllText(approachJsonFile);

            string gdFLJsonFile = CheckFile(Path.Combine("Content", "gear-down-flaps-landing.json"));
            string gdFLJsonContent = File.ReadAllText(gdFLJsonFile);

            string completeJsonFile = CheckFile(Path.Combine("Content", "complete.json"));
            string completeJsonContent = File.ReadAllText(completeJsonFile);

            string shutdownJsonFile = CheckFile(Path.Combine("Content", "shutdown.json"));
            string shutdownJsonContent = File.ReadAllText(shutdownJsonFile);

            string secureJsonFile = CheckFile(Path.Combine("Content", "secure.json"));
            string secureJsonContent = File.ReadAllText(secureJsonFile);

            AviationData aviationData =
               JsonConvert.DeserializeObject<AviationData>(aviationJsonContent);

            SafetyData safetyData =
                JsonConvert.DeserializeObject<SafetyData>(safetyJsonContent);

            BeforeTaxiData beforeTaxiData =
                JsonConvert.DeserializeObject<BeforeTaxiData>(beforeTaxiJsonContent);

            BeforeTakeoffData beforeTakeoffData =
                JsonConvert.DeserializeObject<BeforeTakeoffData>(beforeTakeoffJsonContent);

            BelowTheLine1Data belowTheLine1Data =
                JsonConvert.DeserializeObject<BelowTheLine1Data>(belowTheLine1JsonContent);

            AfterTakeoffData afterTakeoffData =
                JsonConvert.DeserializeObject<AfterTakeoffData>(afterTakeoffJsonContent);

            BeforeStartData beforeStartData =
                JsonConvert.DeserializeObject<BeforeStartData>(beforeStartJsonContent);


            BelowTheLine2Data belowTheLine2Data =
                JsonConvert.DeserializeObject<BelowTheLine2Data>(belowTheLine2JsonContent);

            DescentData descentData =
                JsonConvert.DeserializeObject<DescentData>(descentJsonContent);

            ApproachData approachData =
                JsonConvert.DeserializeObject<ApproachData>(approachJsonContent);

            GdFLData gdLFData =
                JsonConvert.DeserializeObject<GdFLData>(gdFLJsonContent);

            CompleteData completeData =
                JsonConvert.DeserializeObject<CompleteData>(completeJsonContent);

            ShutdownData shutdownData =
                JsonConvert.DeserializeObject<ShutdownData>(shutdownJsonContent);

            SecureData secureData =
                JsonConvert.DeserializeObject<SecureData>(secureJsonContent);



            AviationChecklistBuilder AviationChecklistBuilder =
                new AviationChecklistBuilder();


            AviationChecklistBuilder.AviationData = aviationData;
            AviationChecklistBuilder.SafetyData = safetyData;
            AviationChecklistBuilder.BeforeTaxiData = beforeTaxiData;
            AviationChecklistBuilder.BeforeTakeoffData = beforeTakeoffData;
            AviationChecklistBuilder.BelowTheLine1Data = belowTheLine1Data;
            AviationChecklistBuilder.AfterTakeoffData = afterTakeoffData;
            AviationChecklistBuilder.BeforeStartData = beforeStartData;

            AviationChecklistBuilder.BelowTheLine2Data = belowTheLine2Data;
            AviationChecklistBuilder.DescentData = descentData;
            AviationChecklistBuilder.ApproachData = approachData;
            AviationChecklistBuilder.GdFLData = gdLFData;
            AviationChecklistBuilder.CompleteData = completeData;
            AviationChecklistBuilder.ShutdownData = shutdownData;
            AviationChecklistBuilder.SecureData = secureData;
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