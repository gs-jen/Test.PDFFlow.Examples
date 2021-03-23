using System.Collections.Generic;
namespace AviationChecklistData.Model
{
    public class BeforeStartData
    {
        public string Phones { get; set; }
        public string IrsModeSelectors { get; set; }
        public string GearPins { get; set; }
        public string LightTest { get; set; }
        public string Oxygen { get; set; }
        public string YawDamper { get; set; }
        public string DisplaySwitches { get; set; }
        public string Fuel { get; set; }
        public string CabinUtilIfe { get; set; }
        public string ExitLights { get; set; }
        public string PassSigns { get; set; }
        public string WindowHeat { get; set; }
        public string Hydraulics { get; set; }
        public string ACP { get; set; }
        public string PressurizationMode { get; set; }
        public string Instruments { get; set; }
        public string Autobrake { get; set; }
        public string SpeedbraleLevel { get; set; }
        public string ParkingBrake { get; set; }
        public string StabTrimSwitches { get; set; }
        public string WheelWellFireWarning { get; set; }
        public string RadiosRadarXponder { get; set; }
        public string PudderAileronTrim { get; set; }
        public string TakeoffBriefing{ get; set; }
        public string Pa { get; set; }

        public override string ToString()
        {
            return "BeforeStartData{" +
                    ", Phones =" + Phones +
                    ", IrsModeSelectors =" + IrsModeSelectors +
                    ", GearPins =" + GearPins +
                    ", LightTest =" + LightTest +
                    ", Oxygen =" + Oxygen +
                    ", YawDamper =" + YawDamper +
                    ", DisplaySwitches =" + DisplaySwitches +
                    ", Fuel =" + Fuel +
                    ", CabinUtilIfe =" + CabinUtilIfe +
                    ", ExitLights =" + ExitLights +
                    ", PassSigns =" + PassSigns +
                    ", WindowHeat =" + WindowHeat +
                    ", Hydraulics =" + Hydraulics +
                    ", ACP =" + ACP +
                    ", PressurizationMode =" + PressurizationMode +
                    ", Instruments =" + Instruments +
                    ", Autobrake =" + Autobrake +
                    ", SpeedbraleLevel =" + SpeedbraleLevel +
                    ", ParkingBrake =" + ParkingBrake +
                    ", StabTrimSwitches =" + StabTrimSwitches +
                    ", WheelWellFireWarning =" + WheelWellFireWarning +
                    ", RadiosRadarXponder =" + RadiosRadarXponder +
                    ", PudderAileronTrim =" + PudderAileronTrim +
                    ", TakeoffBriefing =" + TakeoffBriefing +
                    ", Pa =" + Pa +
                                    "}";
        }
    }
}


