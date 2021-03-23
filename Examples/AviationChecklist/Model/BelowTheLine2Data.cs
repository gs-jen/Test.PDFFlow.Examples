using System.Collections.Generic;
namespace AviationChecklistData.Model
{
    public class BelowTheLine2Data
    {
        public string APumps { get; set; }
        public string AirConditioningPacks { get; set; }
        public string AntiCollisionLights { get; set; }
        public string ParkingBrake { get; set; }
        public string Transponder { get; set; }

        public override string ToString()
        {
            return "BelowTheLine2Data{" +
                    ", APumps =" + APumps +
                    ", AirConditioningPacks =" + AirConditioningPacks +
                    ", AntiCollisionLights =" + AntiCollisionLights +
                    ", ParkingBrake =" + ParkingBrake +
                    ", Transponder =" + Transponder +
                                    "}";
        }
    }
}


