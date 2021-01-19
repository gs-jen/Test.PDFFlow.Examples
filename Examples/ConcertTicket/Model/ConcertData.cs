using System.Collections.Generic;

namespace ConcertTicketData.Model
{
    public class ConcertData
    {
        public string title_rulesofpurchase { get; set; }
        public string title_rulesofattendance { get; set; }
        public string rulesofpurchase { get; set; }
        public List<string> rulesofattendance { get; set; }

        public string title_bandslist { get; set; }
        public string bandslist { get; set; }

        public string title_howtofind { get; set; }
        public string howtofind { get; set; }
        public string title_learn { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string instagram { get; set; }
        public string counterfoil { get; set; }


        public override string ToString()
        {
            return "{" + ", title_rulesofpurchase=" + title_rulesofpurchase +
                    ", title_rulesofattendance=" + title_rulesofattendance +
                    ", rulesofpurchase=" + rulesofpurchase +
                    ", rulesofattendance: [" + rulesofattendance.ToString() +  "]" +
                     "}";
        }

    }


}


