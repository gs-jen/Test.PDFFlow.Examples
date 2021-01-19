using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Gehtsoft.PDFFlow.MultilevelList.Model
{
    [DataContract]
    public class MultilevelListData
    {
        [DataMember]
        public string Shipment { get; set; }
        [DataMember]
        public List<OrderData> Orders { get; set; }
    }

    [DataContract]
    public class OrderData
    {
        [DataMember]
        public string Order { get; set; }
        [DataMember]
        public string Customer { get; set; }
        [DataMember]
        public List<ProductData> Products { get; set; }
    }

    [DataContract]
    public class ProductData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }        
    }

}
