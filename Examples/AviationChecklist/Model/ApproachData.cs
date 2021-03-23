using System.Collections.Generic;
namespace AviationChecklistData.Model
{
    public class ApproachData
    {
        public string AltimetersAndInstruments { get; set; }
        public string ApproachAids { get; set; }

        public override string ToString()
        {
            return "ApproachData{" +
                    ", AltimetersAndInstruments =" + AltimetersAndInstruments +
                    ", ApproachAids =" + ApproachAids +
                                    "}";
        }
    }
}


