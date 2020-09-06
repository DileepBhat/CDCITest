using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ArithematicAPIService.v1
{
    [DataContract]
    public class ArithematicAdditionRequest
    {
        [DataMember]
        public int A { get; set; }

        [DataMember]
        public int B { get; set; }
    }
}
