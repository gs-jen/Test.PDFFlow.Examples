using System.Collections.Generic;
namespace AviationChecklistData.Model
{
    public class SecureData
    {
        public string IrsModeSelectors { get; set; }
        public string CabUtilIfe { get; set; }
        public string AirConditioningPacks { get; set; }
        public string EmergencyExitLights { get; set; }
        public string ApuGpu { get; set; }
        public string Battery { get; set; }


        public override string ToString()
        {
            return "SecureData{" +
                    ", IrsModeSelectors =" + IrsModeSelectors +
                    ", CabUtilIfe =" + CabUtilIfe +
                    ", AirConditioningPacks =" + AirConditioningPacks +
                    ", EmergencyExitLights =" + EmergencyExitLights +
                    ", ApuGpu =" + ApuGpu +
                    ", Battery =" + Battery +
                                    "}";
        }
    }
}


