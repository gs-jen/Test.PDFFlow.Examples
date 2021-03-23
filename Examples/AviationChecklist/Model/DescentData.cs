using System.Collections.Generic;
namespace AviationChecklistData.Model
{
    public class DescentData
    {
        public string Pressurization { get; set; }
        public string AntiIce { get; set; }
        public string ApproachBriefAndFuel { get; set; }
        public string IasAndAltBugs { get; set; }
        public override string ToString()
        {
            return "DescentData{" +
                    ", Pressurization =" + Pressurization +
                    ", AntiIce =" + AntiIce +
                    ", ApproachBriefAndFuel =" + ApproachBriefAndFuel +
                    ", IasAndAltBugs =" + IasAndAltBugs +
                                    "}";
        }
    }
}


