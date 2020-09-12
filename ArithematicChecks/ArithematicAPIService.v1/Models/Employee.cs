using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ArithematicAPIService.v1.Models
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public long EmployeeId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Address Address { get; set; }

        [DataMember]
        public long AddressId { get; set; }
    }
}
