using System.Collections.Generic;
namespace AviationChecklistData.Model
{
    public class GdFLData
    {
        public string EngineStartSwitches { get; set; }
        public string Recall { get; set; }
        public string Speedbrake { get; set; }
        public string LandingGear { get; set; }
        public string Autobrake { get; set; }


        public override string ToString()
        {
            return "GdFLData{" +
                    ", EngineStartSwitches =" + EngineStartSwitches +
                    ", Recall =" + Recall +
                    ", Speedbrake =" + Speedbrake +
                    ", LandingGear =" + LandingGear +
                    ", Autobrake =" + Autobrake +
                                    "}";
        }
    }
}


