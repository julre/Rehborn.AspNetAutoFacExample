using System;
using System.Runtime.Serialization;

namespace Rehborn.AspNetAutoFacExample.Application.Values
{
    [DataContract]
    public class ValueDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Text { get; set; }  
    }
}