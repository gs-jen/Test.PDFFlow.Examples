using System.Collections.Generic;
namespace AviationChecklistData.Model
{
    public class ShutdownData
    {
        public string Fuel { get; set; }
        public string ElectricalApuGpu { get; set; }
        public string FastenBelts { get; set; }
        public string WindowHeat { get; set; }
        public string ProbeHeat { get; set; }
        public string AntiIce{ get; set; }
        public string ElectricHydPumps { get; set; }
        public string VoiceRecorder { get; set; }
        public string AirConditioning { get; set; }
        public string ExteriorLights { get; set; }
        public string StartSwitches { get; set; }
        public string Autobrake { get; set; }
        public string Speedbrake{ get; set; }
        public string Flaps { get; set; }
        public string ParkingBrake { get; set; }
        public string StartLevers { get; set; }
        public string WeatherRadar { get; set; }
        public string Transponder { get; set; }
        public string CvrCb { get; set; }
        public string CockpitDoor { get; set; }

        public override string ToString()
        {
            return "ShutdownData{" +
                    ", Fuel =" + Fuel +
                    ", ElectricalApuGpu =" + ElectricalApuGpu +
                    ", FastenBelts =" + FastenBelts +
                    ", WindowHeat =" + WindowHeat +
                    ", ProbeHeat =" + ProbeHeat +
                    ", AntiIce =" + AntiIce +
                    ", ElectricHydPumps =" + ElectricHydPumps +
                    ", VoiceRecorder =" + VoiceRecorder +
                    ", AirConditioning =" + AirConditioning +
                    ", ExteriorLights =" + ExteriorLights +
                    ", StartSwitches =" + StartSwitches +
                    ", Autobrake =" + Autobrake +
                    ", Speedbrake =" + Speedbrake +
                    ", Flaps =" + Flaps +
                    ", ParkingBrake =" + ParkingBrake +
                    ", StartLevers =" + StartLevers +
                    ", WeatherRadar =" + WeatherRadar +
                    ", Transponder =" + Transponder +
                    ", CvrCb =" + CvrCb +
                                    "}";
        }
    }
}


