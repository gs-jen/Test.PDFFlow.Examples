using System.Collections.Generic;
namespace AviationChecklistData.Model
{
    public class AfterTakeoffData
    {
        public string AirConditioning { get; set; }
        public string AutoBrake { get; set; }
        public string StartSwitches { get; set; }
        public string Flaps { get; set; }
        public string LandingGear { get; set; }
        public string Altimeters { get; set; }

        public override string ToString()
        {
            return "AfterTakeoffData{" +
                    ", AirConditioning =" + AirConditioning +
                    ", AutoBrake =" + AutoBrake +
                    ", StartSwitches =" + StartSwitches +
                    ", Flaps =" + Flaps +
                    ", LandingGear =" + LandingGear +
                    ", Altimeters =" + Altimeters +
                                    "}";
        }
    }
}


