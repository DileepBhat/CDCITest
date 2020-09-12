using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ArithematicAPIService.v1.Models
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public long AddressId { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string City { get; set; }
    }
}
