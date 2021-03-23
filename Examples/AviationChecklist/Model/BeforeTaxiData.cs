using System.Collections.Generic;
namespace AviationChecklistData.Model
{
    public class BeforeTaxiData
    {
        public string Generators { get; set; }
        public string ProbeHeat { get; set; }
        public string AntiIce { get; set; }
        public string APumps { get; set; }
        public string AirConditioning { get; set; }
        public string IsolationValve { get; set; }
        public string StartSwitches { get; set; }
        public string Apu { get; set; }
        public string Recall { get; set; }
        public string FlightControls { get; set; }
        public string Flaps { get; set; }
        public string StabTrim { get; set; }
        public string StartLevers { get; set; }

        public override string ToString()
        {
            return "BeforeTaxiData{" +
                    ", Generators =" + Generators +
                    ", ProbeHeat =" + ProbeHeat +
                    ", AntiIce =" + AntiIce +
                    ", APumps =" + APumps +
                    ", AirConditioning =" + AirConditioning +
                    ", IsolationValve =" + IsolationValve +
                    ", StartSwitches =" + StartSwitches +
                    ", Apu =" + Apu +
                    ", Recall =" + Recall +
                    ", FlightControls =" + FlightControls +
                    ", Flaps =" + Flaps +
                    ", StabTrim =" + StabTrim +
                    ", StartLevers =" + StartLevers +
                                    "}";
        }
    }
}


