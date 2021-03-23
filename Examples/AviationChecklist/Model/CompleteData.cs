using System.Collections.Generic;
namespace AviationChecklistData.Model
{
    public class CompleteData
    {
        public string Flaps { get; set; }
        public string LandingLights { get; set; }


        public override string ToString()
        {
            return "CompleteData{" +
                    ", Flaps =" + Flaps +
                    ", LandingLights =" + LandingLights +
                                    "}";
        }
    }
}


