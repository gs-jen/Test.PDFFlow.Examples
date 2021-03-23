using System.Collections.Generic;
namespace AviationChecklistData.Model
{
    public class BeforeTakeoffData
    {
        public string Config { get; set; }
        public string Flaps { get; set; }
        public string StabTrim { get; set; }
        public string TakeoffBriefing { get; set; }
        public string Cabin { get; set; }

        public override string ToString()
        {
            return "BeforeTakeoffData{" +
                    ", Config =" + Config +
                    ", Flaps =" + Flaps +
                    ", StabTrim =" + StabTrim +
                    ", TakeoffBriefing =" + TakeoffBriefing +
                    ", Cabin =" + Cabin +
                                    "}";
        }
    }
}


