using System.Collections.Generic;
namespace AviationChecklistData.Model
{
    public class SafetyData
    {
        public string SurfacesAndChocks { get; set; }
        public string MaintenanceStatus { get; set; }
        public string Battery { get; set; }
        public string ElectricHydPumps { get; set; }
        public string ShipsLibrary { get; set; }

        public override string ToString()
        {
            return "SafetyData{" +
                    ", SurfacesAndChocks =" + SurfacesAndChocks +
                    ", MaintenanceStatus =" + MaintenanceStatus +
                    ", Battery =" + Battery +
                    ", ElectricHydPumps =" + ElectricHydPumps +
                    ", ShipsLibrary =" + ShipsLibrary +
                                    "}";
        }
    }
}


