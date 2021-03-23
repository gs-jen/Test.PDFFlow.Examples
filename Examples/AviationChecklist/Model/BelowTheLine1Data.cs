using System.Collections.Generic;
namespace AviationChecklistData.Model
{
    public class BelowTheLine1Data
    {
        public string Mcp { get; set; }
        public string Transponder { get; set; }
        public string LandingLights { get; set; }
        public string Retracts { get; set; }

        public override string ToString()
        {
            return "BelowTheLine1Data{" +
                    ", Mcp =" + Mcp +
                    ", Transponder =" + Transponder +
                    ", LandingLights =" + LandingLights +
                    ", Retracts =" + Retracts +
                                    "}";
        }
    }
}


